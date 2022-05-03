using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static PacoteServiços.DriverFactory;

namespace TestesFuncionaisComSelenium
{
    public class DLS
    {
        public void escreve(String id_campo, string texto)
        {
            getDriver().FindElement(By.Id(id_campo)).Clear();
            getDriver().FindElement(By.Id(id_campo)).SendKeys(texto);
        }
        public void escreveAttribute(String id_campo, string att)
        {
            getDriver().FindElement(By.Id(id_campo)).GetAttribute(att);
        }
        public void escreveXPath(String id_campo, string texto)
        {
            getDriver().FindElement(By.XPath(id_campo)).SendKeys(texto);
        }
        public void escreveComClick(String id_campo)
        {
            getDriver().FindElement(By.Id(id_campo)).Click();
        }
        public void PreencherCombo(string id, string valor)
        {
            WebElement element = (WebElement)getDriver().FindElement(By.Id(id));
            var combo = new SelectElement((IWebElement)element);
            combo.SelectByText(valor);
        }
        public void PreencherComboXpath(string xpath, string valor)
        {
            WebElement element = (WebElement)getDriver().FindElement(By.XPath(xpath));
            var combo = new SelectElement((IWebElement)element);
            combo.SelectByText(valor);
        }
        public string ObterTexto(string texto)
        {
            return getDriver().FindElement(By.XPath(texto)).Text;
        }

        public void CadastarButtonId(string id_campo)
        {
            getDriver().FindElement(By.Id(id_campo)).Click();
        }
        public void ClickByCssSelector(string selector_campo)
        {
            getDriver().FindElement(By.CssSelector(selector_campo)).Click();
        }
        public void CadastarButtonXPath(string xp_campo)
        {
            getDriver().FindElement(By.XPath(xp_campo)).Click();
        }
        public void InserirEmail(string email, string id_campo) 
        {
            getDriver().FindElement(By.Id(id_campo)).SendKeys(email);
        }
        public void InserirSenha(string id_campo, string texto) 
        {
            getDriver().FindElement(By.Id(id_campo)).SendKeys(texto);
        }
        public void DeveUtilizarAEsperaImplicita() 
        {
            getDriver().Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(50);
        }
        public void DeveVerificarSeOElementoEstaVisivel(string nome) 
        {
            getDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _ = getDriver().FindElement(By.CssSelector(nome)).Displayed;
            //div[data-identity='pagination-next']
        }
        public string ObterTextoClassName(string texto)
        {
            return getDriver().FindElement(By.ClassName(texto)).Text;
        }

        //FindElement(By.ClassName("c9")).Text;
    }
}