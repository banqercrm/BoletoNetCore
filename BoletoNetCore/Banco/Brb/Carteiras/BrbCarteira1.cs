using System;

namespace BoletoNetCore
{
    [CarteiraCodigo("1")]
    public class BrbCarteira1 : ICarteira<BancoBrasilia>
    {
        internal static Lazy<ICarteira<BancoBrasilia>> Instance { get; } =
            new Lazy<ICarteira<BancoBrasilia>>(() => new BrbCarteira1());

        public void FormataNossoNumero(Boleto boleto)
        {
            boleto.NossoNumeroFormatado = $"{boleto.NossoNumero}{boleto.NossoNumeroDV}";
        }

        public string FormataCodigoBarraCampoLivre(Boleto boleto)
        {
            return boleto.CampoLivre;
        }
    }
}
