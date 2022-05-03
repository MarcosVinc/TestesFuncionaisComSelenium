using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacoteServiços
{
     public class DriverFactory
    {
        private static WebDriver driver;

        private DriverFactory() { }
        public static WebDriver getDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                System.Drawing.Size _tamanhoDeTela = new System.Drawing.Size(1200, 980);
                driver.Manage().Window.Size = _tamanhoDeTela;
            }
            return driver;
        }
        public static void killDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
