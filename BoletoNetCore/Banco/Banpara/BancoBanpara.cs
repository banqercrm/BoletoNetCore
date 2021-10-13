using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoletoNetCore.Exceptions;

namespace BoletoNetCore
{
    internal sealed class BancoBanpara : BancoFebraban<BancoBanpara>, IBanco
    {
        public BancoBanpara()
        {
            Codigo = 37;
            Nome = "Banpará";
            Digito = "0";
            IdsRetornoCnab400RegistroDetalhe = new List<string> { "1" };
            RemoveAcentosArquivoRemessa = true;
        }

        public void FormataBeneficiario()
        {
            var contaBancaria = Beneficiario.ContaBancaria;

            if (!CarteiraFactory<BancoBanrisul>.CarteiraEstaImplementada(contaBancaria.CarteiraComVariacaoPadrao))
                throw BoletoNetCoreException.CarteiraNaoImplementada(contaBancaria.CarteiraComVariacaoPadrao);

            contaBancaria.FormatarDados("PAGAR PREFERENCIALMENTE EM AGÊNCIA DO BANPARÁ", string.Empty, string.Empty, 10);

            Beneficiario.CodigoFormatado = $"{contaBancaria.Agencia}/{int.Parse(contaBancaria.Conta)}{contaBancaria.DigitoConta}/{Beneficiario.Convenio}";
        }

        public override string FormatarNomeArquivoRemessa(int numeroSequencial)
        {
            return "";
        }

        public override string FormataCodigoBarraCampoLivre(Boleto boleto)
        {
            return $"0000999{boleto.Banco.Beneficiario.Convenio}{boleto.NossoNumero.PadLeft(13, '0')}";
        }
    }
}
