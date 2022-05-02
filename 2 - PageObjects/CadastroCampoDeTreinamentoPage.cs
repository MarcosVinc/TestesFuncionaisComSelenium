using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesFuncionaisComSelenium
{
    public class CadastroCampoDeTreinamentoPage
    {
        private DLS dls;
        public CadastroCampoDeTreinamentoPage(WebDriver driver)
        {
            dls = new DLS(driver);
        }
        public void setNome(string nome)
        {
            dls.escreve("elementosForm:nome", nome);
        }
        public void setSobrenome(string sobrenome)
        {
            dls.escreve("elementosForm:sobrenome", sobrenome);
        }
        public void setSexoMasculino()
        {
            dls.escreveComClick("elementosForm:sexo:0");
        }
        public void setSexoFeminino()
        {
            dls.escreveComClick("elementosForm:sexo:1");
        }
        public void setComidaCarne()
        {
            dls.escreveComClick("elementosForm:comidaFavorita:0");
        }
        public void setComboEscolariedade(string valor)
        {
            dls.PreencherCombo("elementosForm:escolaridade", valor);
        }
        public void setComboEscportes(string valor)
        {
            dls.PreencherCombo("elementosForm:esportes", valor);
        }
        public void Cadastrar()
        {
            dls.CadastarButtonId("elementosForm:cadastrar");
        }
    }
}
//Corrida