using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace TestesFuncionaisComSelenium
{

    class PreencherEValidarUmCadastro
    {
        ChromeDriver driver = new ChromeDriver();
        private DLS dls;
        private CadastroCampoDeTreinamentoPage page;



        public void Inicialização()
        {
            //ABRINDO O SITE E COLOCANDO E MUDANDO SEU TAMANHO

            driver.Navigate().GoToUrl("file:///A:/CampoTreinamento/componentes.html");
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
        public void CadastroPreenchido()
        {
            Inicialização();

            // NOME E SOBRE NOME
            page.setNome("Marcos");
            page.setSobrenome("Vinicius");
            // SEXO F OU M 
            page.setSexoMasculino();
            // COMIDA FAVORITA
            page.setComidaCarne();

            // COMBOBOX ESCOLARIDADE

            var escolaridade = "Superior";
            page.setComboEscolariedade(escolaridade);

            // COMBOBOX ESPORTE
            var esporte = "Futebol";
            page.setComboEscportes(esporte);

            //BOTAO CADASTRAR
            page.Cadastrar();

            #region Verificações
            Assert.AreEqual("Cadastrado!", driver.FindElement(By.XPath("/html/body/center/div[2]/span")).Text);
            Assert.AreEqual($"Nome: Marcos", driver.FindElement(By.Id("descNome")).Text);
            Assert.AreEqual($"Sobrenome: Vinicius", driver.FindElement(By.Id("descSobrenome")).Text);
            Assert.AreEqual($"Sexo: Masculino", driver.FindElement(By.Id("descSexo")).Text);
            Assert.AreEqual($"Comida: Carne", driver.FindElement(By.Id("descComida")).Text);
            Assert.AreEqual($"Escolaridade: superior", driver.FindElement(By.Id("descEscolaridade")).Text);
            Assert.AreEqual($"Esportes: Futebol", driver.FindElement(By.Id("descEsportes")).Text);
            #endregion

            Finalização();

        }
    }
}
