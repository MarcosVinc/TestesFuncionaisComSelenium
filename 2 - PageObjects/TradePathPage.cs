using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesFuncionaisComSelenium._2___PageObjects
{
    public class TradePathPage
    {
        private DLS dls;

        public TradePathPage(WebDriver driver) 
        {
            dls = new DLS(driver);
        }

        public void ClicarElemento(string xpath) 
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.CadastarButtonXPath(xpath);
        }

        public void ClicarNoCombo(string xpath, string valor) 
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.PreencherComboXpath(xpath, valor);
        }

    }
}
