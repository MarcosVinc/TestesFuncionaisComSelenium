using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace TestesFuncionaisComSelenium
{
    class RegrasDeNegocioFormulario
    {
        [Test]
        public void RDN_Formulario()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
            var _tamanhoDaTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaTela;

            driver.FindElement(By.Id("elementosForm:nome")).SendKeys("Marcos");
            driver.FindElement(By.Id("elementosForm:sobrenome")).SendKeys("Vinicius");
            driver.FindElement(By.Id("elementosForm:sexo:0")).Click();

            // CONFICIONANTES COMIDA FAVORITA

            driver.FindElement(By.Id("elementosForm:comidaFavorita:0")).Click();

            /*   if (Assert.AreEqual($"Carne", driver.FindElement(By.Id("descNome")).Text);) 
              { 


              }*/

            driver.Quit();

        }
    }
}
