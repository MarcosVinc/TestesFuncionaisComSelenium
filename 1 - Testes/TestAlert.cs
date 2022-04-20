using NUnit.Framework;
using NUnit.Framework.Internal;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestesFuncionaisComSelenium
{
    class TestAlert
    {
        [Test]
        public void _deveInteragirComAlertSimples()
        {
            // Interafir com um button de alerta simples


            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
            var _tamanhoDaTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaTela;
            //

            driver.FindElement(By.Id("alert")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.AreEqual("Alert Simples", alert.Text);
            string _textoDeAlerta = alert.Text;
            alert.Accept();
            driver.FindElement(By.Id("elementosForm:nome")).SendKeys($"Teste de Click {_textoDeAlerta}");

            driver.Quit();

        }

        [Test]
        public void _deveInteragirComAlertConfirm()
        {
            // Interafir com um button de alerta Confirm
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
            var _tamanhoDaTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaTela;

            driver.FindElement(By.Id("confirm")).Click();
            IAlert alertConfirm = driver.SwitchTo().Alert();
            Assert.AreEqual("Confirm Simples", alertConfirm.Text);
            alertConfirm.Accept();
            Assert.AreEqual("Confirmado", alertConfirm.Text);
            alertConfirm.Accept();

            driver.Quit();
        }

        [Test]
        public void _deveInteragirComPrompt()
        {
            // Formulario
            string numeroParaPreencher = "6000";
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
            var _tamanhoDaTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaTela;

            driver.FindElement(By.Id("prompt")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.AreEqual("Digite um numero", alert.Text);
            alert.SendKeys(numeroParaPreencher);
            alert.Accept();
            Assert.AreEqual($"Era {numeroParaPreencher}?", alert.Text);
            alert.Accept();
            Assert.AreEqual(":D", alert.Text);
            alert.Accept();

            driver.Quit();


        }
    }
}
