using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TestesFuncionaisComSelenium._2___PageObjects;
using TestesFuncionaisComSelenium._3___Serviços;
using TestesFuncionaisComSelenium.Entidade;

namespace TestesFuncionaisComSelenium._1___Testes
{
    public class TestExpciaonalUber
    {
        ChromeDriver driver = new ChromeDriver();
        private DLS dls;
        private UberPO page;
        UberLogica ubl = new UberLogica();
        public void Inicialização()
        {
            //ABRINDO O SITE E COLOCANDO E MUDANDO SEU TAMANHO

            driver.Navigate().GoToUrl("https://riders.uber.com/trips?state=pS87G4_VXaxj_RmyJKWnZ0bOrFVXl2Pk_UVZBEN4KiA%3D&_csid=dKvTM2Qhe3P4crKzzulNMQ");
            System.Drawing.Size _tamanhoDeTela = new System.Drawing.Size(950, 710);
            driver.Manage().Window.Size = _tamanhoDeTela;
            dls = new DLS(driver);
            page = new UberPO(driver);
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
            var objetosViagem = new List<UberViagem>();
            string A, B, C, D, E, F, G, H, I, J, L, M, N, O, P, Q, R, S, T, U;
            Thread.Sleep(500);
            page.InserirEmail("Seu email", "useridInput");
            page.ClicarNoBotaoXPath("/html/body/div[1]/div/div/div/div[1]/form/div[2]/button");
            Thread.Sleep(500);
            page.InserirSenha("password", "Sua senha");
            page.ClicarNoBotaoXPath("/html/body/div[1]/div/div/div/div/form/div[2]/button");
            Thread.Sleep(500);
            // PAGINA 1

            while (true)
            {
                if (driver.FindElement(By.CssSelector("div[data-identity='pagination-next']")).Displayed)
                {
                    var ListaDeViagens = driver.FindElement(By.CssSelector("div[data-identity='trip-list']"));
                    var viagens = ListaDeViagens.FindElements(By.CssSelector("div[data-identity='trip-container']"));

                    foreach (var viagem in viagens)
                    {
                        var objetoViagem = new UberViagem();

                        var valorDaViagem = viagem.FindElement(By.ClassName("c9")).Text;
                        //
                        var itemAserRemovido = ubl.Cortar(valorDaViagem);
                        objetoViagem.Valor = ubl.Conversao(itemAserRemovido);
                        //
                        objetosViagem.Add(objetoViagem);

                    }
                    page.CliqueBotaoProximaPagina();

                }
                else { break; }
                    

            }          
        }
    }
}

