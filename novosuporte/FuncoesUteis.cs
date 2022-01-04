using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NixPDC
{
    class FuncoesUteis
    {

        public static bool criarArquivo(string nomeComExtensao, string path, string conteudo = "")
        {
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path + "/"+ nomeComExtensao))
                {
                    if (conteudo != "")
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(conteudo);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    return true;
                }            
            }

            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public static string leArquivo(string path)
        {
            string dados = "";
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        dados += s + Environment.NewLine;
                    }
                }
                return dados;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        public static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }

        public static void deletarArquivo(string arquivo, bool obrigatorioDeletar = false, bool verificarSeAberto = false, string path = "")
        {
            path = path == "" ? AppDomain.CurrentDomain.BaseDirectory : "path";
            bool reiniciar = false;

            if (!verificarSeAberto)
            {
                File.Delete(path + arquivo);
            }
            else
            {
                try
                {
                    File.Delete(path + arquivo);
                }
                catch (Exception e)
                {
                    var result = MessageBox.Show("Erro ao deletar arquivo. Feche o arquivo aberto e tente novamente." + Environment.NewLine +
                    "Caso o erro persistir contate o administrador" + Environment.NewLine +
                    "Local: " + path + Environment.NewLine +
                    "Arquivo: " + arquivo
                    , "Erro ao deletar arquivo", MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);

                    // If the no button was pressed ...
                    if (result == DialogResult.Retry)
                    {
                        deletarArquivo(arquivo, obrigatorioDeletar, true);
                    }
                    else
                    {
                        if (obrigatorioDeletar)
                        {
                            var result2 = MessageBox.Show("É necessário deletar o arquivo para continuar o processo" + Environment.NewLine +
                      "Deseja tentar deletar o arquivo novamente?" + Environment.NewLine +
                      "Caso clique em NÃO o processo será interrompido."                      
                      , "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result2 == DialogResult.No || result2 == DialogResult.Cancel)
                            {
                                reiniciar = true;
                            }
                            else
                            {
                                deletarArquivo(arquivo, obrigatorioDeletar, true);
                            }
                        }                     
                    }
                }
            }
            if (reiniciar)
            {
                encerraPrograma();
            }
        }

        public static void encerraPrograma()
        {
            //Application.Restart();
            Environment.Exit(0);
        }
        public static void reiniciaPrograma()
        {
            Application.Restart();
            Environment.Exit(0);
        }

        public static void pausa(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

    }
}
