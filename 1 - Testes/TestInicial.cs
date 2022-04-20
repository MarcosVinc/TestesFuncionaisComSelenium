using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

using System.Threading;

namespace TestesFuncionaisComSelenium
{ 
   class TestInicial

    {
        public bool IsSelected { get; set; }

        [SetUp]
        public void Setup()
        {


        }
    }

    public class _campoDeTeste
    {
        ChromeDriver driver = new ChromeDriver();
        private DLS dls;


        public void Iniciar()
        {
            //ABRINDO O SITE E COLOCANDO E MUDANDO SEU TAMANHO

            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");

            System.Drawing.Size _tamanhoDeTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDeTela;
            dls = new DLS(driver);
        }

        public void Fechar()
        {
            //FINALIZANDO O TESTE

            driver.Quit();
        }

        [Test]
        public void TesteGeral()
        {
            // Abrir O formulario com a tela maximizada
            Iniciar();
            //ELEMENTOS TXT
            driver.FindElement(By.Id("elementosForm:nome")).SendKeys("Marcos");
            driver.FindElement(By.Id("elementosForm:sobrenome")).SendKeys("Vinicius");
            driver.FindElement(By.Id("elementosForm:nome")).GetAttribute("value");
            driver.FindElement(By.Id("elementosForm:sobrenome")).GetAttribute("value");

            // AREA
            driver.FindElement(By.Id("elementosForm:sugestoes")).SendKeys("teste");
            driver.FindElement(By.Id("elementosForm:sugestoes")).GetAttribute("value");

            // RadioButton
            driver.FindElement(By.Id("elementosForm:sexo:0")).Click();
            Assert.IsTrue(driver.FindElement(By.Id("elementosForm:sexo:0")).Selected);

            //ComboBox
            var superior = "Superior";
            WebElement element = (WebElement)driver.FindElement(By.Name("elementosForm:escolaridade"));
            var combo = new SelectElement(element);
            combo.SelectByText(superior);

            //Interagir com botões
            driver.FindElement(By.Id("buttonSimple")).Click();
            WebElement botao = (WebElement)driver.FindElement(By.Id("buttonSimple"));
            botao.Click();
            Assert.AreEqual("Obrigado!", botao.GetAttribute("value"));

            //Interagir com um Link sem ID

            driver.FindElement(By.LinkText("Voltar")).Click();

            // Buscar um Texto Na Pagina

            Assert.AreEqual("Campo de Treinamento", driver.FindElement(By.XPath("/html/body/center/form/h3")).Text);

            // Interafir com um button de alerta simples

            driver.FindElement(By.Id("alert")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.AreEqual("Alert Simples", alert.Text);
            string _textoDeAlerta = alert.Text;
            alert.Accept();
            driver.FindElement(By.Id("elementosForm:nome")).SendKeys($"Teste de Click {_textoDeAlerta}");

            // Interafir com um button de alerta Confirm
            driver.FindElement(By.Id("confirm")).Click();
            IAlert alertConfirm = driver.SwitchTo().Alert();
            Assert.AreEqual("Confirm Simples", alertConfirm.Text);
            alertConfirm.Accept();
            Assert.AreEqual("Confirmado", alertConfirm.Text);
            alertConfirm.Accept();
            Fechar();

        }

        [Test]
        public void TestIrParaOGoogle()
        {

            
            //Browser Google.com
            driver.Navigate().GoToUrl("https://www.google.com.br/");
            driver.Manage().Window.FullScreen();
            Thread.Sleep(500);
            driver.Quit ();
        }
        [Test]
        public void testeAbrirFormulario()
        {
            // Formulario

            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
            System.Drawing.Size _tamanhoDeTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDeTela;
            Thread.Sleep(500);

            driver.Quit();
        }
        [Test]
        public void testeElementosTxt()
        {
            // ELEMENTOS TXT
            Iniciar();
            driver.FindElement(By.Id("elementosForm:nome")).SendKeys("Marcos");
            driver.FindElement(By.Id("elementosForm:sobrenome")).SendKeys("Vinicius");
            driver.FindElement(By.Id("elementosForm:nome")).GetAttribute("value");
            driver.FindElement(By.Id("elementosForm:sobrenome")).GetAttribute("value");
            Thread.Sleep(500);

            Fechar();
        }
        [Test]
        public void testeArea()
        {
            //Area
            Iniciar();
            driver.FindElement(By.Id("elementosForm:sugestoes")).SendKeys(" O metodo PASS()Lança um SuccessException com a mensagem e os argumentos que são passados.Isso permite que um teste seja interrompido, com um resultado de sucesso retornado para NUnit." +
             " Marcos");
            driver.FindElement(By.Id("elementosForm:sugestoes")).GetAttribute("value");
            Thread.Sleep(500);
            Fechar();
        }

        [Test]

        public void TesteComboBox()
        {
            //ComboBox
            var superior = "Superior";
            Iniciar();
            dls.PreencherCombo("elementosForm:escolaridade", superior);
            Thread.Sleep(500);

            Fechar();
        }


        [Test]
        public void DeveInteragirComOsBotoes()
        {
            //Botões
            Iniciar();
            driver.FindElement(By.Id("buttonSimple")).Click();
            WebElement botao = (WebElement)driver.FindElement(By.Id("buttonSimple"));
            botao.Click();
            Assert.AreEqual("Obrigado!", botao.GetAttribute("value"));

            Thread.Sleep(500);
            Fechar();

        }
        [Test]
        public void DeveInteragirComLinks()
        {
            // Interagir com um Link sem ID
            Iniciar(); ;
            driver.FindElement(By.LinkText("Voltar")).Click();
            Thread.Sleep(500);
            Fechar();

        }
        [Test]
        public void DeveBuscarUmTextoNaPagina()
        {
            // Buscar um Texto Na Pagina

            Iniciar();
            Assert.AreEqual("Campo de Treinamento", driver.FindElement(By.XPath("/html/body/center/form/h3")).Text);
            Thread.Sleep(500);
            Fechar();

        }
    }
}
