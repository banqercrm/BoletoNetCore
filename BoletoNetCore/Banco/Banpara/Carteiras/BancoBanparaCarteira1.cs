using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoNetCore.Extensions;

namespace BoletoNetCore
{
    [CarteiraCodigo("1")]
    public class BancoBanparaCarteira1 : ICarteira<BancoBanpara>
    {
        internal static Lazy<ICarteira<BancoBanpara>> Instance { get; } = new Lazy<ICarteira<BancoBanpara>>(() => new BancoBanparaCarteira1());

        public BancoBanparaCarteira1()
        {
        }

        public void FormataNossoNumero(Boleto boleto)
        {
            if (string.IsNullOrEmpty(boleto.NossoNumero))
                throw new Exception("Nosso Número não informado.");

            // Devido a limitações sistêmicas no Banpará a quantidade de dígitos do Nosso Número deve ser no máximo 13
            // e os demais espaços deve ficar em branco.
            if (boleto.NossoNumero.Length > 13)
                throw new Exception($"Nosso Número ({boleto.NossoNumero}) deve conter até 13 dígitos.");

            boleto.NossoNumero = boleto.NossoNumero;
            boleto.NossoNumeroDV = string.Empty;
            boleto.NossoNumeroFormatado = boleto.NossoNumero;
        }

        public string FormataCodigoBarraCampoLivre(Boleto boleto)
        {
            if (boleto.Banco.Beneficiario.Convenio.Length > 5)
                throw new Exception("Convênio deve conter até 5 dígitos.");

            var sb = new StringBuilder();
            sb.Append("0000999"); // Fixo.
            sb.Append(boleto.Banco.Beneficiario.Convenio); // Número do Convênio.
            sb.Append(boleto.NossoNumero.PadLeft(13, '0')); // Nosso número com zeros a esquerda.
            return sb.ToString();
        }
    }
}
