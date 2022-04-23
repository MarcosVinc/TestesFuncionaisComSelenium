using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesFuncionaisComSelenium._3___Serviços
{
     public class UberLogica
    {
        Utilidades util = new Utilidades();
        string ItemASerCortado = "R$ ";
        string cancelado = "Cancelada";
        public string CortarValor(string variavel) 
        {
            // CORTAR R$:
            return variavel.Replace(ItemASerCortado, "").Replace(cancelado, "");
        }
        public string ObterAData(string variavel)
        {
            // Obter Data:
            char[] demilitar = { ',' };
            string[] palavras = variavel.Split(demilitar);
            return palavras[0];
        }
        public string ItemVerificar(string variavel) 
        {
            // VERIFICAR SE O ITEM FOI CANCELADO
            return util.ItemASerVerificado(variavel, cancelado);
        }
        public decimal Conversao(string num) 
        {
            //CONVERTER STRING PARA DOUBLE
            return util.ConvercaoString(num);
        }
        public double SomarItens(double x, double y) 
        {
            return x + y;
        }

    }
}
