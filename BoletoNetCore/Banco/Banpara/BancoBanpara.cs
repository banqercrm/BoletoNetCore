using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoletoNetCore.Exceptions;

namespace BoletoNetCore
{
    internal sealed partial class BancoBanpara : BancoFebraban<BancoBanrisul>, IBanco
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

            contaBancaria.FormatarDados("PAGÁVEL EM QUALQUER BANCO ATÉ O VENCIMENTO.", "SAC BANRISUL: 0800 646 1515<br>OUVIDORIA BANRISUL: 0800 644 2200", "", 8);

            Beneficiario.CodigoFormatado = $"{contaBancaria.Agencia}/{contaBancaria.Conta}{contaBancaria.DigitoConta}/{Beneficiario.Convenio}"; // falta incluir convenio.
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
