using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static PacoteServiços.DriverFactory;

namespace TestesFuncionaisComSelenium._2___PageObjects
{
    public class UberPage
    {
        private DLS dls;

        public string PegarTexto(string nome)
        {
            dls.DeveUtilizarAEsperaImplicita();
            return dls.ObterTexto(nome);
        }
        public void ClicarNoBotaoXPath(string xp_Botao)
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.CadastarButtonXPath(xp_Botao);
        }
        public void ClicarNoBotaoId(string id_string) 
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.CadastarButtonId(id_string);
        }
        public void InserirEmail(string email, string id) 
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.InserirEmail(email, id);
        }
        public void InserirSenha(string id, string senha) 
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.InserirSenha(id, senha);
        }
        public void CliqueBotaoProximaPagina() 
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.ClickByCssSelector("div[data-identity='pagination-next']");
        }
        public void ObterOTextoClassName(string nome) 
        {
            dls.DeveUtilizarAEsperaImplicita();
            dls.ObterTextoClassName(nome);
        }
        public void Espera() 
        {
            dls.DeveUtilizarAEsperaImplicita();
        }

    }
}
