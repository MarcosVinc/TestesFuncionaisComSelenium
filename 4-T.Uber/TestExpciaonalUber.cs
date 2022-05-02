using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private UberPage page;
        UberLogica ubl = new UberLogica();

        public void Inicialização()
        {
            //ABRINDO O SITE E COLOCANDO E MUDANDO SEU TAMANHO

            driver.Navigate().GoToUrl("https://riders.uber.com/trips?state=pS87G4_VXaxj_RmyJKWnZ0bOrFVXl2Pk_UVZBEN4KiA%3D&_csid=dKvTM2Qhe3P4crKzzulNMQ");
            System.Drawing.Size _tamanhoDeTela = new System.Drawing.Size(1200, 980);
            driver.Manage().Window.Size = _tamanhoDeTela;
            dls = new DLS(driver);
            page = new UberPage(driver);
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
            //Login
            page.InserirEmail("marcos.viniciuswac@outlook.com", "useridInput");
            page.ClicarNoBotaoXPath("/html/body/div[1]/div/div/div/div[1]/form/div[2]/button"); ;
            page.InserirSenha("password", "marcos454");
            page.ClicarNoBotaoXPath("/html/body/div[1]/div/div/div/div/form/div[2]/button");


            // Pegar e somar viagens 


            while (true) // Enquanto o botão de proximo estiver visivel esse while estara em circuito fechado
            {

                page.Espera();
                var btnProximoEstaHabilitado = driver.FindElement(By.CssSelector("div[data-identity='pagination-next']")).GetAttribute("disabled");

                if (string.IsNullOrEmpty(btnProximoEstaHabilitado))// Nessa linha eu vejo e o botão proximo esta disponivel para clicar
                {

                    var ListaDeViagens = driver.FindElement(By.CssSelector("div[data-identity='trip-list']")); // Eu encontro a grid do site.
                    var viagens = ListaDeViagens.FindElements(By.CssSelector("div[data-identity='trip-container']")); // Com o grid selecionado/encontrado eu entro no container´s.

                    page.Espera();
                    foreach (var viagem in viagens) // A variavel 'VIAGENS' são os containe´s encontrados. Atente para o fato que assim posso ter varias viagens no grid, elas vão ser contadas.
                    {
                        var objetoViagem = new UberViagem();
                        var valorDaViagem = viagem.FindElement(By.ClassName("c9")).Text; // Entro no valor da viagens e pego o seu texto
                        var DataDaViagem = viagem.FindElement(By.ClassName("an")).Text; // Entro no texto do primeiro container. Como a data nao tem identificador especifico eu tenho que pegar todo o texto do container e trabalhar nele.

                        //
                        var obterData = ubl.ObterAData(DataDaViagem); // Uso o metodo ObterAData ele corta o texto com obeservando onde tem um ',';
                        var itemAserRemovido = ubl.CortarValor(valorDaViagem); // Uso o metodo CortarValor para obter so a string que contem o valor, retirando o textos que não servem em primeiro momento para o objetivo da tarefa.
                        objetoViagem.Valor = ubl.Conversao(itemAserRemovido); // Converto a string para DECIMAL que ja foi trabalhada no item acima 'itemAserRemovido' usando o metodo 'Conversao'.E coloco o valor dentro da variavel objetoViagem.
                        objetoViagem.Data = obterData; // Coloco a DATA dentro da variavel objetoViagem
                        //
                        objetosViagem.Add(objetoViagem); // Coloco os valores dentro do OBJETO 'objetosViagem'.
                    }
                    page.CliqueBotaoProximaPagina(); // Clico no botao proxima pagina, se ela estiver disponivel.

                }
                else
                {
                    break;
                } // Se caso o  botão proxima pagina nao estiver disponivel o laço de repetição sera quebrado e seguira.
            }
            var total = objetosViagem.Sum(x => x.Valor);
            Finalização();

        }
    }
}

// var total = objetosViagem.Sum(x => x.Valor);
//Finalização();