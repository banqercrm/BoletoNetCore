using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoNetCore
{
    public class BoletoBancarioBanpara : BoletoBancario
    {
        public override string GeraHtmlReciboPagador()
        {
            try
            {
                var html = new StringBuilder();
                html.Append(GetResourceHypertext("BoletoNetCore.Banco.Banpara.Impressao.ReciboPagador.html"));
                return html.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a execução da transação.", ex);
            }
        }

        public override string GeraHtmlReciboBeneficiario()
        {
            try
            {
                var html = new StringBuilder();
                html.Append(GetResourceHypertext("BoletoNetCore.Banco.Banpara.Impressao.ReciboBeneficiario.html"));
                html.Append(GetResourceHypertext("BoletoNetCore.Banco.Banpara.Impressao.DivisorParaUsoAgencia.html"));
                html.Append(GetResourceHypertext("BoletoNetCore.Banco.Banpara.Impressao.ReciboBeneficiario.html"));
                return html.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na execução da transação.", ex);
            }
        }

        protected override string GerarEnderecoPagador()
        {
            var enderecoPagador = string.Empty;
            if (!OcultarEnderecoPagador)
            {
                enderecoPagador = $"{Boleto.Pagador.Endereco.FormataLogradouro(0)} {Boleto.Pagador.Endereco.Bairro} - " +
                                  $"{Boleto.Pagador.Endereco.Cidade}/{Boleto.Pagador.Endereco.UF}";
                if (Boleto.Pagador.Endereco.CEP != String.Empty)
                    enderecoPagador += $" - CEP: {Utils.FormataCEP(Boleto.Pagador.Endereco.CEP)}";
            }

            return enderecoPagador;
        }

        protected override string GerarEnderecoAvalista()
        {
            var enderecoAvalista = string.Empty;
            if (!OcultarEnderecoAvalista)
            {
                enderecoAvalista = Boleto.Avalista.Endereco.FormataLogradouro(0) + $"{Boleto.Avalista.Endereco.Bairro} - {Boleto.Avalista.Endereco.Cidade}/{Boleto.Avalista.Endereco.UF}";
                if (Boleto.Avalista.Endereco.CEP != String.Empty)
                    enderecoAvalista += $" - CEP: {Utils.FormataCEP(Boleto.Avalista.Endereco.CEP)}";
            }

            return enderecoAvalista;
        }

        protected override string GerarCpfCnpjBeneficiario()
        {
            var cpfCnpjBeneficiario = string.Empty;
            switch (Boleto.Banco.Beneficiario.TipoCPFCNPJ("A"))
            {
                case "F":
                    cpfCnpjBeneficiario = Utils.FormataCPF(Boleto.Banco.Beneficiario.CPFCNPJ);
                    break;
                case "J":
                    cpfCnpjBeneficiario = Utils.FormataCNPJ(Boleto.Banco.Beneficiario.CPFCNPJ);
                    break;
            }

            return cpfCnpjBeneficiario;
        }
    }
}
