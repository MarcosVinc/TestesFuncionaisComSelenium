using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestesFuncionaisComSelenium._1___Testes
{
    class TestPopUp
    {
        [Test]
        public void InteragirComPopUp()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");

            var _tamanhoDaTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaTela;

            // POPUP  Abrir e inserir um texto
            string Texto = "ESTEVAM NABOTE";
            driver.FindElement(By.Id("buttonPopUpEasy")).Click();
            driver.SwitchTo().Window("Popup");
            driver.FindElement(By.XPath("/html/body/textarea")).SendKeys(Texto);
            driver.Close();

            //Inserir o texto na tela inicial
            driver.SwitchTo().Window("");
            driver.FindElement(By.Id("elementosForm:sugestoes")).SendKeys($"{Texto} come um pratasso de FEIJÃO");

            driver.Quit();
        }

        [Test]
        public void InteragirComPopUpSemTitulo()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");

            var _tamanhoDaTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaTela;
            driver.FindElement(By.Id("buttonPopUpHard")).Click();
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);
            driver.FindElement(By.TagName("textarea")).SendKeys("Deu certo");
            var newWindowHandle2 = driver.WindowHandles[0];
            driver.SwitchTo().Window(newWindowHandle2);
            driver.FindElement(By.Id("elementosForm:sugestoes")).SendKeys("E agora ?");
            driver.Quit();

        }
    }
}
