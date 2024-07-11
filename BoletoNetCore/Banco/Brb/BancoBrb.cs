using System.Collections.Generic;

namespace BoletoNetCore
{
    public sealed class BancoBrb : BancoFebraban<BancoBrb>, IBanco
    {
        public BancoBrb()
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

        public string GerarMensagemRemessa(TipoArquivo tipoArquivo, Boleto boleto, ref int numeroRegistro)
        {
            return null;
        }
    }
}
