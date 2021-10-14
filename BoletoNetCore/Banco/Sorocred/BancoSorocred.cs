using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoNetCore
{
    internal sealed class BancoSorocred : BancoFebraban<BancoSorocred>, IBanco
    {

        public BancoSorocred()
        {
            this.Codigo = 299;
            this.Nome = "Sorocred";
            this.Digito = "2";
            this.IdsRetornoCnab400RegistroDetalhe = new List<string> { "1" };
            this.RemoveAcentosArquivoRemessa = true;
        }
        public void FormataBeneficiario()
        {
            var contaBancaria = this.Beneficiario.ContaBancaria;
            //contaBancaria.FormatarDados("PAGAR PREFERENCIALMENTE EM AGÊNCIA DO SOROCRED", string.Empty, string.Empty, 10);
            this.Beneficiario.CodigoFormatado = $"{contaBancaria.Agencia}/{int.Parse(contaBancaria.Conta)}{contaBancaria.DigitoConta}";
        }
    }
}
