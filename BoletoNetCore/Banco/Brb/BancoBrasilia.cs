using System.Collections.Generic;

namespace BoletoNetCore
{
    internal sealed class BancoBrasilia : BancoFebraban<BancoBrasilia>, IBanco
    {
        public BancoBrasilia()
        {
            this.Codigo = 70;
            this.Digito = string.Empty;
            this.Nome = "BRB - Banco de Brasília";
            this.IdsRetornoCnab400RegistroDetalhe = new List<string> { "1" };
            this.RemoveAcentosArquivoRemessa = true;
        }

        public void FormataBeneficiario()
        {
            var contaBancaria = this.Beneficiario.ContaBancaria;
            this.Beneficiario.CodigoFormatado = $"{contaBancaria.Agencia}/{int.Parse(contaBancaria.Conta)}{contaBancaria.DigitoConta}";
        }
    }
}
