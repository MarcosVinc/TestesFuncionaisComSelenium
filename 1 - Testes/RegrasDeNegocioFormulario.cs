using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesFuncionaisComSelenium
{
    class RegrasDeNegocioFormulario
    {
        [Test]
        public void RDN_Formulario()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Users/Marcos%20Vinicius/Desktop/campo_treinamento/componentes.html");
            var _tamanhoDaTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaTela;

            driver.FindElement(By.Id("elementosForm:nome")).SendKeys("Marcos");
            driver.FindElement(By.Id("elementosForm:sobrenome")).SendKeys("Vinicius");
            driver.FindElement(By.Id("elementosForm:sexo:0")).Click();

            // CONFICIONANTES COMIDA FAVORITA

            driver.FindElement(By.Id("elementosForm:comidaFavorita:0")).Click();
            Assert.AreEqual($"Carne", driver.FindElement(By.Id("elementosForm:comidaFavorita:0")).Text);

            /*   if (Assert.AreEqual($"Carne", driver.FindElement(By.Id("descNome")).Text);) 
              { 


              }*/



        }
    }
}
