using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestesFuncionaisComSelenium._2___PageObjects
{
    public class UberPO
    {
        private DLS dls;

        public UberPO(WebDriver driver)
        {
            dls = new DLS(driver);
        }
        public string PegarTexto(string nome)
        {
            return dls.ObterTexto(nome);
        }
        public void ClicarNoBotaoXPath(string xp_Botao)
        {
            Thread.Sleep(500);
            dls.CadastarButtonXPath(xp_Botao);
        }
        public void ClicarNoBotaoId(string id_string) 
        {
            dls.CadastarButtonId(id_string);
        }
        public void InserirEmail(string email, string id) 
        {
            dls.InserirEmail(email, id);
        }
        public void InserirSenha(string id, string senha) 
        {
            dls.InserirSenha(id, senha);
        }
        public void CliqueBotaoProximaPagina() 
        {
            dls.ClickByCssSelector("div[data-identity='pagination-next']");
        }
        public void EsperaImplicita() 
        {
            dls.DeveUtilizarAEsperaImplicita();
        }

    }
}
