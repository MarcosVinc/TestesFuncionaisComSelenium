using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestesFuncionaisComSelenium._2___PageObjects;
using TestesFuncionaisComSelenium._3___Serviços;

namespace TestesFuncionaisComSelenium._1___Testes
{
    public class TestExpciaonalUber
    {      
        ChromeDriver driver = new ChromeDriver();        
        private DLS dls;
        private UberPO page;
        Utilidades util = new Utilidades();
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
            string A, B, C, D, E, F, G, H, I, J, L, M, N, O, P, Q, R, S, T, U;
            Thread.Sleep(500);
            page.InserirEmail("SEU EMAIL", "useridInput");          
            page.ClicarNoBotaoXPath("/html/body/div[1]/div/div/div/div[1]/form/div[2]/button");
            Thread.Sleep(500);
            page.InserirSenha("password", "SUA SENHA");

            page.ClicarNoBotaoXPath("/html/body/div[1]/div/div/div/div/form/div[2]/button");
            Thread.Sleep(500);
            L = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[1]/div[1]/div[2]/div[2]");
            B = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[2]/div/div[2]/div[2]");
            C = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[3]/div/div[2]/div[2]");
            D = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[4]/div/div[2]/div[2]");
            E = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[5]/div/div[2]/div[2]");
            F = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[6]/div/div[2]/div[2]");
            G = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[6]/div/div[2]/div[2]");
            H = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[8]/div/div[2]/div[2]"); //6,24
            I = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[9]/div/div[2]/div[2]");
            J = page.PegarTexto("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div/div[2]/div[9]/div/div[2]/div[2]");

            #region Logica

            // Variaveis
            string  Aa, Ba, Ca, Da, Ea, Fa, Ga, Ha, Ia, Ja, La, Ma, Na, Oa, Pa, Qa, Ra, Sa, Ta, Ua;
            string  Ab, Bb, Cb, Db, Eb, Fb, Gb, Hb, Ib, Jb, Lb, Mb, Nb, Ob, Pb, Qb, Rb, Sb, Tb, Ub;
            string ItemASerCortado = "R$ ";
            string cancelado = "Cancelada";
            string surge;


            // CORTAR R$:
            La= util.ItemString(L, ItemASerCortado);
            Ba = util.ItemString(B, ItemASerCortado);
            Ca = util.ItemString(C, ItemASerCortado);
            Da = util.ItemString(D, ItemASerCortado);
            Ea = util.ItemString(E, ItemASerCortado);
            Ga = util.ItemString(G, ItemASerCortado);
            Ha = util.ItemString(H, ItemASerCortado);
            Ia = util.ItemString(I, ItemASerCortado);
            Ja = util.ItemString(J, ItemASerCortado);

            // VERIFICAR SE O ITEM FOI CANCELADO
            Lb = util.ItemASerVerificado(La, cancelado);
            Bb = util.ItemASerVerificado(Ba, cancelado);
            Cb = util.ItemASerVerificado(Ca, cancelado);
            Db = util.ItemASerVerificado(Da, cancelado);
            Eb = util.ItemASerVerificado(Ea, cancelado);
            Gb = util.ItemASerVerificado(Ga, cancelado);
            Hb = util.ItemASerVerificado(Ha, cancelado);
            Ib = util.ItemASerVerificado(Ia, cancelado);
            Jb = util.ItemASerVerificado(Ja, cancelado);

            //CONVERTER STRING PARA DOUBLE
            var Num1 = util.ConvercaoString(Lb);
            var Num2 = util.ConvercaoString(Bb);
            var Num3 = util.ConvercaoString(Cb);
            var Num4 = util.ConvercaoString(Db);
            var Num5 = util.ConvercaoString(Eb);
            var Num6 = util.ConvercaoString(Gb);
            var Num7 = util.ConvercaoString(Hb);
            var Num8 = util.ConvercaoString(Ib);
            var Num9 = util.ConvercaoString(Jb);

            //SOMA 
            double soma = Num1 + Num2 + Num3 + Num4 + Num5 + Num6 + Num7 + Num8 + Num9;
            Assert.AreEqual(soma , soma);

            #endregion
        }
    }
}
