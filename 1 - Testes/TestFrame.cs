using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestesFuncionaisComSelenium._1___Testes
{
    class TestFrame
    {
        ChromeDriver driver = new ChromeDriver();

        public void Inicializar() {
            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
            var _tamanhodeTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhodeTela;
        }
        public void Fechar() {
            driver.Quit();
        }
        
        [Test]

        public void DeveInteragirComFrameButton()
        {

            Inicializar();

            //INTERAGIR COM O FRAME

            // 1a - Levar o foco para o FRAME
            driver.SwitchTo().Frame("frame1");
            // 1b - Interação com o FRAME
            driver.FindElement(By.Id("frameButton")).Click();
            IAlert alertConfirm = driver.SwitchTo().Alert();
            Assert.AreEqual("Frame OK!", alertConfirm.Text);
            string TituloDoAlerta = alertConfirm.Text;
            alertConfirm.Accept();

            #region Botao
            //Colocar o titulo do alerta na aba NOME!  

            //2a- Trazer novamente o foco para a pagina principal
            driver.SwitchTo().DefaultContent();
            //2b - Colocar o titulo do alerta do Frame na aba NOME
            driver.FindElement(By.Id("elementosForm:nome")).SendKeys(TituloDoAlerta);

            Fechar();
            #endregion
        }

        [Test]
        public void InteragirComOFrameEscondido() 
        {
            
            Inicializar();

            driver.SwitchTo().Frame("frame2");
            driver.FindElement(By.Id("frameButton")).Click();
            IAlert alertConfirm = driver.SwitchTo().Alert();
            Assert.AreEqual("Frame OK!", alertConfirm.Text);
            alertConfirm.Accept();
            Thread.Sleep(600);
            Fechar();

        }
    }
}
