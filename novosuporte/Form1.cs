using NixPDC;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;

namespace botmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void btn_iniciar_Click(object sender, EventArgs e)
        {
            //-----------------------LEMBRAR DE COLOCAR AS SENHAS QUE ESTÃO FALTANDO ANTES DE BUILDAR OU RODAR--------------------------

            //Credenciais Klist, pode ser qualquer conta.
            string email = "arthur.quintanilha@hotmail.com";
            string senhaklist = "";


            //Credenciais conta google (que vai enviar o email).
            string email2 = "delfos.suporteinterno@gmail.com";
            string senhaemail = ""; // (senha do root)
            
            //Lista de emails que vão receber o chamado. (emails separados por virgulas, sempre manter uma no final)
            string listaemailsti = "arthur.quintanilha@hotmail.com,";



            //---------------------------------------------------------------------------------------------------------------------------


            //Entra no google 
            IWebDriver driver = SeleniumMetodos.criaDriver(Constantes.headless);
            SeleniumMetodos.navegarPara(driver, "https://klist.app/#welcome");

            //prenche form 
            string pesquisa = txt_nome.Text + " / " + txt_dep.Text + " : " + txt_oco.Text ;

            

            int i = 0;

            

            
                //tenta clicar no botão de login ("entrar")
                SeleniumMetodos.clickPorClasse(driver, "NavBar_loginButton_x8Qd2YkIc5");
                FuncoesUteis.pausa(2000);
                SeleniumMetodos.clickPorId(driver, "TextField16");
                FuncoesUteis.pausa(2000);

                
                    //preenche os campos login e senha
                    char[] login = email.ToCharArray();
                    Random rnd = new Random();
                    int zero = 0;
                    foreach (var lo in login)
                    {
                        int time = rnd.Next(1, 13);
                        FuncoesUteis.pausa(time + zero + zero + zero);
                        SeleniumMetodos.preencherTextPorName(driver, lo.ToString(), "email");
                    }
                    FuncoesUteis.pausa(1);
                    char[] senha = senhaklist.ToCharArray();
                    foreach (var se in senha)
                    {
                        int time = rnd.Next(1, 13);
                        FuncoesUteis.pausa(time + zero + zero + zero);
                        SeleniumMetodos.preencherTextPorName(driver, se.ToString(), "password");
                    }


            
            SeleniumMetodos.clickPorClasse(driver, "ms-Checkbox-checkmark"); //permanecer conectado
                SeleniumMetodos.clickPorClasse(driver, "ms-Button--primary"); //botão de logar


            //preenche o campo do suporte
            char[] textosuporte = pesquisa.ToCharArray();
            foreach (var tx in textosuporte)
            {
                int time = rnd.Next(1, 13);
                FuncoesUteis.pausa(time + zero + zero + zero);
                SeleniumMetodos.preencherTextPorName(driver, tx.ToString(), "title");
            }
            FuncoesUteis.pausa(1);
            //envia o suporte
            SeleniumMetodos.clickPorClasse(driver, "ContentPage_submit_2LplJyFqAT");


            FuncoesUteis.pausa(2000);
            SeleniumMetodos.navegarPara(driver, "https://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&service=mail&sacu=1&rip=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");


            //preenche campo email
            FuncoesUteis.pausa(5000);
            char[] textoemail = email2.ToCharArray();
            foreach (var tx in textoemail)
            {
                int time = rnd.Next(1, 13);
                FuncoesUteis.pausa(time + zero + zero + zero);
                SeleniumMetodos.preencherTextPorName(driver, tx.ToString(), "identifier");
            }
            FuncoesUteis.pausa(1);
            //clica no botão "proxima" na pagina de login do gmail
            SeleniumMetodos.clickPorClasse(driver, "VfPpkd-vQzf8d");
            FuncoesUteis.pausa(2000);

            //preenche campo senha
            char[] textosenha = senhaemail.ToCharArray();
            foreach (var tx in textosenha)
            {
                int time = rnd.Next(1, 13);
                FuncoesUteis.pausa(time + zero + zero + zero);
                SeleniumMetodos.preencherTextPorName(driver, tx.ToString(), "password");
            }
            FuncoesUteis.pausa(1);
            //clica no botão "proxima" na pagina de senha do gmail
            SeleniumMetodos.clickPorClasse(driver, "VfPpkd-vQzf8d");
            FuncoesUteis.pausa(2000);

            //para evitar o google pedindo celular, redirecionamento direto para o inbox
            SeleniumMetodos.navegarPara(driver, "https://mail.google.com/mail/u/0/#inbox");

            //clicar no "novo email"
            SeleniumMetodos.clickPorClasse(driver, "T-I-KE");

            //preenche campo de emails para onde serão enviados os suportes
            try
            {
                SeleniumMetodos.clickPorXPATH(driver, "/html/body/div[24]/div/div/div/div[1]/div[3]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/form/div[2]");
            }
            catch { }

            char[] textolistaemail = listaemailsti.ToCharArray();
            foreach (var tx in textolistaemail)
            {
                int time = rnd.Next(1, 13);
                FuncoesUteis.pausa(time + zero + zero + zero);
                SeleniumMetodos.preencherTextPorName(driver, tx.ToString(), "to");
            }
            FuncoesUteis.pausa(1);

            string mula = "suporte";

            try
            {
                SeleniumMetodos.clickPorXPATH(driver, "/html/body/div[24]/div/div/div/div[1]/div[3]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/form/div[3]/div/input");
            }
            catch { }

            //preenche o campo do assunto
            char[] textosuporte2 = mula.ToCharArray();
            foreach (var tx in textosuporte2)
            {
                int time = rnd.Next(1, 13);
                FuncoesUteis.pausa(time + zero + zero + zero);
                SeleniumMetodos.preencherTextPorName(driver, tx.ToString(), "subjectbox");
            }
            FuncoesUteis.pausa(1);

            try
            {
                SeleniumMetodos.clickPorXPATH(driver, "/html/body/div[24]/div/div/div/div[1]/div[3]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/table/tbody/tr[1]/td/div/div[1]/div[2]/div[1]/div/table/tbody/tr/td[2]/div[2]/div");
            }
            catch { }

            //preenche o corpo do email
            char[] textosuporte3 = pesquisa.ToCharArray();
            foreach (var tx in textosuporte3)
            {
                int time = rnd.Next(1, 13);
                FuncoesUteis.pausa(time + zero + zero + zero);
                SeleniumMetodos.preencherTextPorClasse(driver, tx.ToString(), "LW-avf");
            }
            FuncoesUteis.pausa(1);


            

            try
            {
                SeleniumMetodos.clickPorId(driver, ":82");//clica no botão de login para verificar se ja saiu da tela de login (se não tem botão de login, não está na tela de login! GE-NI-AL kkk)


            }

            catch (Exception ex)
            {

                if (ex is OpenQA.Selenium.NoSuchElementException)//caso não esteja na tela de login, a falta do botão vai causar um erro que vai somar +1 no contador e sair do laço
                {

                    try
                    {
                        SeleniumMetodos.clickPorId(driver, ":88");//clica no botão de login para verificar se ja saiu da tela de login (se não tem botão de login, não está na tela de login! GE-NI-AL kkk)


                    }

                    catch (Exception ex2)
                    {

                        if (ex2 is OpenQA.Selenium.NoSuchElementException)//caso não esteja na tela de login, a falta do botão vai causar um erro que vai somar +1 no contador e sair do laço
                        {
                            
                            SeleniumMetodos.clickPorClasse(driver, "T-I-atl");

                        }
                        else
                        {

                        }



                    }


                }
                else
                {

                }



            }


            //salvar variaveis em arquivo TXT
            string data = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            StreamWriter tw = new StreamWriter("c://suportLog/" + data + "-" + txt_nome.Text + "-" + txt_dep.Text + ".txt");
            tw.WriteLine(pesquisa);
            tw.Close();
            // fim do acript do arquivo


            FuncoesUteis.pausa(5500);


            SeleniumMetodos.fecharDriver(driver);

            MessageBox.Show("Seu pedido foi encaminhado ao TI, aguarde!", "Status do suporte", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            




















        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_regiao_Click(object sender, EventArgs e)
        {

        }

        private void txt_publicoAlvo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbl_obs_Click(object sender, EventArgs e)
        {

        }

        private void txt_obs_TextChanged(object sender, EventArgs e)
        {

        }

        //parar execução

    }

    
}
