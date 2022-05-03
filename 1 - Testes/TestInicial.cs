using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PacoteServiços;
using System;

using System.Threading;
using TestesFuncionaisComSelenium._3___Serviços;
using static PacoteServiços.DriverFactory;

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
        private DLS dls;
        public void Iniciar()
        {
            //ABRINDO O SITE E COLOCANDO E MUDANDO SEU TAMANHO
            getDriver().Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
            dls = new DLS();
        }

        public void Fechar()
        {
            //FINALIZANDO O TESTE

            killDriver();
        }

        [Test]
        public void TesteGeral()
        {
            // Abrir O formulario com a tela maximizada
            Iniciar();
            //ELEMENTOS TXT
            getDriver().FindElement(By.Id("elementosForm:nome")).SendKeys("Marcos");
            getDriver().FindElement(By.Id("elementosForm:sobrenome")).SendKeys("Vinicius");
            getDriver().FindElement(By.Id("elementosForm:nome")).GetAttribute("value");
            getDriver().FindElement(By.Id("elementosForm:sobrenome")).GetAttribute("value");

            // AREA
            getDriver().FindElement(By.Id("elementosForm:sugestoes")).SendKeys("teste");
            getDriver().FindElement(By.Id("elementosForm:sugestoes")).GetAttribute("value");

            // RadioButton
            getDriver().FindElement(By.Id("elementosForm:sexo:0")).Click();
            Assert.IsTrue(getDriver().FindElement(By.Id("elementosForm:sexo:0")).Selected);

            //ComboBox
            var superior = "Superior";
            WebElement element = (WebElement)getDriver().FindElement(By.Name("elementosForm:escolaridade"));
            var combo = new SelectElement(element);
            combo.SelectByText(superior);

            //Interagir com botões
            getDriver().FindElement(By.Id("buttonSimple")).Click();
            WebElement botao = (WebElement)getDriver().FindElement(By.Id("buttonSimple"));
            botao.Click();
            Assert.AreEqual("Obrigado!", botao.GetAttribute("value"));

            //Interagir com um Link sem ID

            getDriver().FindElement(By.LinkText("Voltar")).Click();

            // Buscar um Texto Na Pagina

            Assert.AreEqual("Campo de Treinamento", getDriver().FindElement(By.XPath("/html/body/center/form/h3")).Text);

            // Interafir com um button de alerta simples

            getDriver().FindElement(By.Id("alert")).Click();
            IAlert alert = getDriver().SwitchTo().Alert();
            Assert.AreEqual("Alert Simples", alert.Text);
            string _textoDeAlerta = alert.Text;
            alert.Accept();
            getDriver().FindElement(By.Id("elementosForm:nome")).SendKeys($"Teste de Click {_textoDeAlerta}");

            // Interafir com um button de alerta Confirm
            getDriver().FindElement(By.Id("confirm")).Click();
            IAlert alertConfirm = getDriver().SwitchTo().Alert();
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
            getDriver().Navigate().GoToUrl("https://www.google.com.br/");
            getDriver().Manage().Window.FullScreen();
            Thread.Sleep(500);
            getDriver().Quit ();
        }
        [Test]
        public void testeAbrirFormulario()
        {
            // Formulario
            getDriver().Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");

            System.Drawing.Size _tamanhoDeTela = new System.Drawing.Size(950, 710);
            getDriver().Manage().Window.Size = _tamanhoDeTela;
            Thread.Sleep(500);
            getDriver().Quit();

        }
        [Test]
        public void testeElementosTxt()
        {
            // ELEMENTOS TXT
            Iniciar();
            getDriver().FindElement(By.Id("elementosForm:nome")).SendKeys("Marcos");
            getDriver().FindElement(By.Id("elementosForm:sobrenome")).SendKeys("Vinicius");
            getDriver().FindElement(By.Id("elementosForm:nome")).GetAttribute("value");
            getDriver().FindElement(By.Id("elementosForm:sobrenome")).GetAttribute("value");
            Thread.Sleep(500);

            Fechar();
        }
        [Test]
        public void testeArea()
        {
            //Area
            Iniciar();
            getDriver().FindElement(By.Id("elementosForm:sugestoes")).SendKeys(" O metodo PASS()Lança um SuccessException com a mensagem e os argumentos que são passados.Isso permite que um teste seja interrompido, com um resultado de sucesso retornado para NUnit." +
             " Marcos");
            getDriver().FindElement(By.Id("elementosForm:sugestoes")).GetAttribute("value");
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
            getDriver().FindElement(By.Id("buttonSimple")).Click();
            WebElement botao = (WebElement)getDriver().FindElement(By.Id("buttonSimple"));
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
            getDriver().FindElement(By.LinkText("Voltar")).Click();
            Thread.Sleep(500);
            Fechar();

        }
        [Test]
        public void DeveBuscarUmTextoNaPagina()
        {
            // Buscar um Texto Na Pagina

            Iniciar();
            Assert.AreEqual("Campo de Treinamento", getDriver().FindElement(By.XPath("/html/body/center/form/h3")).Text);
            Thread.Sleep(500);
            Fechar();

        }
    }
}
