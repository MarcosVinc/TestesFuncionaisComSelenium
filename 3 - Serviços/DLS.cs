using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestesFuncionaisComSelenium
{
    public class DLS
    {
        private WebDriver driver;

        public DLS(WebDriver driver)
        {
            this.driver = driver;
        }

        public void escreve(String id_campo, string texto)
        {
            driver.FindElement(By.Id(id_campo)).Clear();
            driver.FindElement(By.Id(id_campo)).SendKeys(texto);
        }
        public void escreveAttribute(String id_campo, string att)
        {
            driver.FindElement(By.Id(id_campo)).GetAttribute(att);
        }
        public void escreveXPath(String id_campo, string texto)
        {
            driver.FindElement(By.XPath(id_campo)).SendKeys(texto);
        }
        public void escreveComClick(String id_campo)
        {
            driver.FindElement(By.Id(id_campo)).Click();
        }
        public void PreencherCombo(string id, string valor)
        {
            WebElement element = (WebElement)driver.FindElement(By.Id(id));
            var combo = new SelectElement((IWebElement)element);
            combo.SelectByText(valor);
        }
        public void ObterTexto(string texto)
        {
            string text = driver.FindElement(By.Id(texto)).Text;
        }

        public void CadastarButton(string id_campo)
        {
            driver.FindElement(By.Id(id_campo)).Click();
        }
        public void EntrarEmDiferentesAbas()
        {
            Thread.Sleep(500);
        }
    }
}