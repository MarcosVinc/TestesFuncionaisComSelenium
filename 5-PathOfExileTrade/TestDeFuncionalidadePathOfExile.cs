using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TestesFuncionaisComSelenium._2___PageObjects;

namespace TestesFuncionaisComSelenium._5_PathOfExileTrade
{
    public class TestDeFuncionalidadePathOfExile
    {
        ChromeDriver driver = new ChromeDriver();
        private TradePathPage page;
        public void Inicializar()
        {
            driver.Navigate().GoToUrl("https://www.pathofexile.com/");
            System.Drawing.Size _tamanhoDaAba = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDaAba;
            page = new TradePathPage(driver);
        }
        public void Fechar()
        {
            driver.Quit();
        }

        [Test]

        public void PathOfExileTRADE() 
        {
            Inicializar();
            string item = "Sceptre";

            page.ClicarElemento("/html/body/div[1]/div[1]/ul/li[5]/a/span");
            page.ClicarNoCombo("//*[@id=trade]/div[4]/div/div[2]/div/div[1]/div[1]/div[2]/div[1]/span/div[2]/div[2]/input", item);

            Fechar();


        }
    }
}
