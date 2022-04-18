using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesFuncionaisComSelenium._1___Testes
{
    class TestFrame
    {
        [Test]

        public void DeveInteragirComFrameButton()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Users/Marcos%20Vinicius/Desktop/campo_treinamento/componentes.html");
            var _tamanhodeTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhodeTela;

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

            driver.Quit();
            #endregion
        }
    }
}
