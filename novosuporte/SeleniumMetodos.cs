using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using System.Collections.ObjectModel;
using WebDriverManager.DriverConfigs.Impl;

//using Actions = OpenQA.Selenium.Interactions.Actions;


namespace NixPDC
{
    class SeleniumMetodos
    {
        public static IWebDriver criaDriver(bool headless, bool permitirDownload = false, string pastaDownload = "")
        {
            IWebDriver driver;
            try
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("headless");//começar minimizado
                chromeOptions.AddArguments("--start-maximized");//começar maximizado
                chromeOptions.AddArguments("--disable-blink-features");
                chromeOptions.AddArguments("--disable-blink-features=AutomationControlled");
                chromeOptions.AddExcludedArgument("enable-automation");//tirar barra de automação do chrome driver 


                chromeOptions.AddUserProfilePreference("download.default_directory", Constantes.path);

                ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;//colocar para deixar o console do chromedriver em segundo plano
                chromeOptions.AddArguments("--start-maximized");

                if (headless)
                {
                    //chromeOptions.AddArguments("headless");
                    chromeDriverService.HideCommandPromptWindow = true;
                    driver = new ChromeDriver(chromeDriverService, chromeOptions);
                }
                else
                {
                    driver = new ChromeDriver(chromeDriverService, chromeOptions);
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                if (permitirDownload)
                {
                    var enableDownloadCommandParameters = new Dictionary<string, object>
                {
                    { "behavior", "allow" },
                    { "downloadPath", Constantes.path + pastaDownload}
                };
                    var result = ((OpenQA.Selenium.Chrome.ChromeDriver)driver).ExecuteChromeCommandWithResult("Page.setDownloadBehavior", enableDownloadCommandParameters);
                }
            }
            catch (System.Exception e)
            {
                driver = criaDriver(Constantes.headless, permitirDownload);
            }

            return driver;
        }


        public static void enviarEnterSemElemento(IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.KeyDown(Keys.Return).Build().Perform();
            builder.KeyUp(Keys.Return).Build().Perform();

        }

        public static void limpaText(IWebDriver driver, string id)
        {
            driver.FindElement(By.Id(id)).Clear();
        }
        public static void clickTextoPorLink(IWebDriver driver, string link)
        {
            driver.FindElement(By.LinkText(link)).Click(); //PartialLinkText
        }

        public static string retornarTextoPorTag(IWebDriver driver, string tag)
        {
            return driver.FindElement(By.TagName(tag)).Text;
        }
        public static List<IWebElement> retornarTodosTextoPorTag(IWebDriver driver, string tag)
        {
            return driver.FindElements(By.TagName(tag)).ToList();
        }

        public static List<IWebElement> retornarTodosTextoPorClasse(IWebDriver driver, string classe)
        {
            return driver.FindElements(By.ClassName(classe)).ToList();
        }
        public static string retornarTextoPorClasse(IWebDriver driver, string classe)
        {
            return driver.FindElement(By.ClassName(classe)).Text;
        }
        public static string retornarTextoPorId(IWebDriver driver, string id)
        {
            return driver.FindElement(By.Id(id)).Text;
        }
        public static string retornarTextoPorIdTry(IWebDriver driver, string id)
        {
            //para casos onde o elemento pode nao existir
            try
            {
                return driver.FindElement(By.Id(id)).Text;
            }
            catch (System.Exception)
            {
                return "";
            }
        }
        public static string retornarValuePorName(IWebDriver driver, string tag)
        {
            var elemento = driver.FindElement(By.TagName(tag));
            return elemento.GetAttribute("value");
        }
        public static bool navegarPara(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            new WebDriverWait(driver, new TimeSpan(0, 0, 03)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return true;
        }
        public static void preencherTextPorId(IWebDriver driver, string texto, string id)
        {
            driver.FindElement(By.Id(id)).SendKeys(texto);
        }

        public static void preencherTextPorName(IWebDriver driver, string texto, string name)
        {
            driver.FindElement(By.Name(name)).SendKeys(texto);
        }
        public static void preencherTextPorClasse(IWebDriver driver, string texto, string classe)
        {
            driver.FindElement(By.ClassName(classe)).SendKeys(texto);
        }
        public static void clickPorId(IWebDriver driver, string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
        public static void clickPorClasse(IWebDriver driver, string classe)
        {
            driver.FindElement(By.ClassName(classe)).Click();
        }
        public static void clickPorTexto(IWebDriver driver, string texto, int numEle = 0)
        {
            var obj = driver.FindElements(By.XPath("//*[text()='" + texto + "']"))[numEle];
            obj.Click();
            //driver.FindElement(By.XPath("//*[text()='" + texto + "']")).Click();            
        }
        public static void clickPorXPATH(IWebDriver driver, string xpath, int numEle = 0)
        {



            var obj = driver.FindElement(By.XPath(xpath));
            //var obj = driver.FindElements(By.XPath(xpath));
            obj.Click();





        }



        public static void rClickPorXPATH(IWebDriver driver, string xpath, int numEle = 0)
        {
            Actions actions = new Actions(driver);
            var obj = driver.FindElement(By.XPath(xpath));
            actions.MoveToElement(driver.FindElement(By.XPath(xpath)))
                .ContextClick()
                .Build()
                .Perform();
            //var obj = driver.FindElements(By.XPath(xpath))[numEle];

            //obj.
            //.ContextClick(obj);
        }

        public static void preencherTextPorXPATH(IWebDriver driver, string xpath, string texto, int numEle = 0, int pausarAnterDoEnterMS = 500, bool enviarEnter = false)
        {
            driver.FindElements(By.XPath(xpath))[numEle].SendKeys(texto);
            if (enviarEnter)
            {
                FuncoesUteis.pausa(pausarAnterDoEnterMS);
                driver.FindElements(By.XPath(xpath))[numEle].SendKeys(Keys.Return);
            }
        }




        public static void back(IWebDriver driver)
        {
            driver.Navigate().Back();
        }
        public static void clickSubmit(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            new WebDriverWait(driver, new TimeSpan(0, 0, 03)).Until(
            d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public static void mudaUsuarioGedoc(IWebDriver driver, string abadas)
        {


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.body.setAttribute(\"sessionId\", csrfToken)");
            js.ExecuteScript("document.body.setAttribute(\"hostPath\", hostPath)");


            String sessionId = driver.FindElement(By.TagName("body")).GetAttribute("sessionId");
            String hostPath = driver.FindElement(By.TagName("body")).GetAttribute("hostPath");

            int pontoVenda = 0;
            switch (abadas)
            {
                case "10806": pontoVenda = 38328; break;
                case "10929": pontoVenda = 38893; break;
                case "10807": pontoVenda = 38329; break;
                case "10808": pontoVenda = 38330; break;
                case "10385": pontoVenda = 37485; break;
                case "10422": pontoVenda = 37669; break;
                case "15435": pontoVenda = 24318; break;
                case "10424": pontoVenda = 37670; break;
                case "15347": pontoVenda = 13177; break;
                case "10115": pontoVenda = 33485; break;
                case "10809": pontoVenda = 38331; break;
                case "10930": pontoVenda = 38890; break;
                case "10810": pontoVenda = 38332; break;
                case "11490": pontoVenda = 39841; break;
                case "11491": pontoVenda = 39859; break;
                case "11492": pontoVenda = 39860; break;
                case "11493": pontoVenda = 39861; break;
                case "11494": pontoVenda = 39862; break;
                //case "11102": pontoVenda = 39862; break;
                //TEORICAMENTE nao precisa mais mudar o ADABAS
                //cada usuario so pode ver as informacoes da sua propria loja
                //para isso implementamos a opção de mudar o usuario no form

                default:
                    break;
            }

            string post = "var xhr = new XMLHttpRequest();" +
                        //                        "xhr.open('POST', 'https://gedoc.vivo.com.br/usuario/send-atualizar-ponto-venda', true);" +  //era assim antes dos captcha
                        "xhr.open('POST', '" + hostPath + "usuario/send-atualizar-ponto-venda', true);" +
                        "xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); " +
                        "xhr.onload = function() {" +
                            "alert(this.responseText); " +
                        "}; " +

                        "xhr.send('csrfToken=" + sessionId + "&regional=6&regional_label=SP&uf=SP&uf_label=SP+-+S%C3%A3o+Paulo&ponto_venda=" + pontoVenda.ToString() + "& ponto_venda_label=" + abadas + "+-+LEVYCOM+TELECOMUNICACAO+LTDA+ME'); ";


            js.ExecuteScript(post);

        }

        internal static void fecharDriver(IWebDriver driver)
        {
            //driver.Close();
            driver.Quit();

        }

        internal static void selecionarSelectPorIdEValue(IWebDriver driver, string id, string value)
        {

            // select the drop down list
            var select = driver.FindElement(By.Id(id));
            //create select element object 
            var selectElement = new SelectElement(select);

            //select by value
            selectElement.SelectByValue(value);
        }
        internal static void executaJS(IWebDriver driver, string codigoJS)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(codigoJS);
        }
        public static bool buscaAtualizacoes(IWebDriver driver)
        {
            string validacao = "";
            try
            {
                validacao = retornarTextoPorClasse(driver, "h2");
            }
            catch (System.Exception)
            {
                return false;
            }

            if (validacao == "Buscando atualizações...")
            {
                return true;
            }
            return false;
        }

        internal static void alterarValueInputPorId(IWebDriver driver, string id, string value)
        {
            IWebElement element = driver.FindElement(By.Id(id)); // you can use any locator
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].value='" + value + "';", element);
        }

        internal static void alterarValueInputPorClasse(IWebDriver driver, string classe, string value)
        {
            IWebElement element = driver.FindElement(By.ClassName(classe)); // you can use any locator
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].value='" + value + "';", element);
        }


        internal static void alterarValueInputPorName(IWebDriver driver, string name, string value)
        {
            IWebElement element = driver.FindElement(By.Name(name)); // you can use any locator
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].value='" + value + "';", element);
        }


        internal static void limparCampoPorIdTeclado(IWebDriver driver, string id)
        {
            driver.FindElement(By.Id(id)).SendKeys(Keys.Control + "a");
            driver.FindElement(By.Id(id)).SendKeys(Keys.Delete);
        }
        internal static void limparCampoPorIdClear(IWebDriver driver, string id)
        {
            driver.FindElement(By.Id(id)).Clear();
        }

        internal static void limparCampoPorName(IWebDriver driver, string name)
        {
            driver.FindElement(By.Name(name)).Clear();
            driver.FindElement(By.Name(name)).SendKeys(Keys.Control + "a");
            driver.FindElement(By.Name(name)).SendKeys(Keys.Delete);
        }

        public static bool verificarSeExistePorClasse(IWebDriver driver, string classe)
        {
            try
            {
                driver.FindElement(By.ClassName(classe));
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
        public static bool verificarSeExistePorId(IWebDriver driver, string id)
        {
            bool existe = driver.FindElement(By.Id(id)).Displayed;
            return existe;
        }

        internal static void aceitaAlert(IWebDriver driver, int timeOutSeg = 20)
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (System.Exception e)
            {
                bool alertEncontrado = false;
                int tempoPassado = 0;
                while (!alertEncontrado)
                {
                    FuncoesUteis.pausa(1000);
                    tempoPassado++;
                    if (tempoPassado <= timeOutSeg)
                    {
                        try
                        {
                            driver.SwitchTo().Alert().Accept();
                            alertEncontrado = true;
                        }
                        catch (System.Exception f)
                        { }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        internal static void enviarEnterPorId(IWebDriver driver, string id)
        {
            driver.FindElement(By.Id(id)).SendKeys(Keys.Return);
        }
        internal static void enviarSetaPorId(IWebDriver driver, string id, int idSeta)
        {
            switch (idSeta)
            {
                case 1:
                    driver.FindElement(By.Id(id)).SendKeys(Keys.ArrowUp);
                    break;
                case 2:
                    driver.FindElement(By.Id(id)).SendKeys(Keys.ArrowRight);
                    break;
                case 3:
                    driver.FindElement(By.Id(id)).SendKeys(Keys.ArrowDown);
                    break;
                case 4:
                    driver.FindElement(By.Id(id)).SendKeys(Keys.ArrowLeft);
                    break;
                default:
                    break;
            }

        }

        public static string retornarTextoElementoClasseNaoExclusiva(IWebDriver driver, string classe, int numeroDoElemento)
        {
            string texto = driver.FindElements(By.ClassName(classe))[numeroDoElemento].Text;
            return texto;
        }

        public static string retornarTextoElementoClasseNaoExclusivaPorTextContext(IWebDriver driver, string classe, int numeroDoElemento)
        {
            string texto = driver.FindElements(By.ClassName(classe))[numeroDoElemento].GetAttribute("textContent");
            return texto;
        }

        public static string retornaURL(IWebDriver driver)
        {
            return driver.Url;
        }

        public static string retornarTextoPorXPATH(IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath)).Text;
        }

        public static void moverAteElementoPorClasse(IWebDriver driver, string classe)
        {
            var element = driver.FindElement(By.ClassName(classe));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public static void moverAteElementoPorXpath(IWebDriver driver, string xpath)
        {
            var element = driver.FindElement(By.XPath(xpath));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static string retornarHTMLPorClasse(IWebDriver driver, string classe)
        {
            return driver.FindElement(By.ClassName(classe)).GetAttribute("innerHTML");
        }

        public static string retornarHTMLPorCSSSelector(IWebDriver driver, string cssSelector)
        {
            return driver.FindElement(By.CssSelector(cssSelector)).GetAttribute("innerHTML");
        }


        internal static void clickRadioPorNamePorIndex(IWebDriver driver, string nome, int index)
        {
            IList<IWebElement> elements = driver.FindElements(By.Name(nome));
            elements[index].Click();
        }

        public static void mudarIframePorId(IWebDriver driver, string id)
        {
            driver.SwitchTo().Frame(id);
        }

        internal static int retornarQuantidadeDeElementosPorName(IWebDriver driver, string name)
        {
            IList<IWebElement> elements = driver.FindElements(By.Name(name));
            return elements.Count();
        }

        public static void mudarDeJanela(IWebDriver driver, int idJanela)
        {
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[idJanela]);
        }





        public static void printDeJanela(IWebDriver driver, string url, string nomeDoArquivo)
        {
            driver.Url = url;
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(nomeDoArquivo + ".png", ScreenshotImageFormat.Png);
        }
    }


}