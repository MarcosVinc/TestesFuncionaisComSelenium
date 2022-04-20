using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestesFuncionaisComSelenium._1___Testes
{
    public class TestExpciaonalUber
    {

        ChromeDriver driver = new ChromeDriver();
        private DLS dls;
        private CadastroCampoDeTreinamentoPage page;



        public void Inicialização()
        {
            //ABRINDO O SITE E COLOCANDO E MUDANDO SEU TAMANHO

            driver.Navigate().GoToUrl("https://riders.uber.com/trips?state=pS87G4_VXaxj_RmyJKWnZ0bOrFVXl2Pk_UVZBEN4KiA%3D&_csid=dKvTM2Qhe3P4crKzzulNMQ");
            System.Drawing.Size _tamanhoDeTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDeTela;
            dls = new DLS(driver);
            page = new CadastroCampoDeTreinamentoPage(driver);
        }

        public void Finalização()
        {
            //FINALIZANDO O TESTE

            driver.Quit();
        }

        [Test]
        public void ObterDatos()
        {
            Inicialização();
            Thread.Sleep(500);
            driver.FindElement(By.Id("useridInput")).SendKeys("Email: xxxxxxx");
            Thread.Sleep(300);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[1]/form/div[2]")).Click();
            dls.EntrarEmDiferentesAbas();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/form/input[2]")).SendKeys("Senha: xxxx");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/form/div[2]/button")).Click();
            dls.EntrarEmDiferentesAbas();
            string Valor1 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[1]/div[1]/div[2]/div[2]")).Text;
            string Valor2 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[2]/div/div[2]/div[2]")).Text;
            string Valor3 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[3]/div/div[2]/div[2]")).Text;
            string Valor4 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[4]/div/div[2]/div[2]")).Text;//Cancelada
            string Valor5 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[5]/div/div[2]/div[2]")).Text;//Cancelada
            string Valor6 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[6]/div/div[2]/div[2]")).Text; // Cancelada
            string Valor7 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[8]/div/div[2]/div[2]")).Text; //Canselada
            string valor8 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[10]/div/div[2]/div[2]")).Text;
            //var valorTotal = Valor1 + Valor2;
            // Console.WriteLine(valorTotal);
            Valor1.Split(" ");
            Valor2.Split(" ");
            Valor3.Split(" ");
            Valor4.Split(" ");
            Valor5.Split(" ");
            Valor6.Split(" ");
            Valor7.Split(" ");
            valor8.Split(" ");
        }
    }
}
