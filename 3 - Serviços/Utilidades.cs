using System;
using System.Collections.Generic;
using System.Text;

namespace TestesFuncionaisComSelenium._3___Serviços
{
    public class Utilidades
    {
        public string ItemString(string numero, string item)
        {
            var resultadoCortado = numero.Split(item);
            return resultadoCortado[1];

        }
        public string ItemASerVerificado(string nome, string nomeAserVerificado)
        {
            // Verificação
            var _aCancelado = nome;
            bool verificacao = _aCancelado.Contains(nomeAserVerificado);
            if (verificacao == true)
            {
                return nome = "0";
            }
            else
            {
                return nome;
            }
        }
        public double ConvercaoString(string nome)
        {
            double conver = Convert.ToDouble(nome);
            return conver;
        }
    }
}
