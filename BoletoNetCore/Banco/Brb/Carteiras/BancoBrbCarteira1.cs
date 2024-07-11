using System;

namespace BoletoNetCore
{
    [CarteiraCodigo("1")]
    public class BancoBrbCarteira1 : ICarteira<BancoBrb>
    {
        internal static Lazy<ICarteira<BancoBrb>> Instance { get; } =
            new Lazy<ICarteira<BancoBrb>>(() => new BancoBrbCarteira1());

        public void FormataNossoNumero(Boleto boleto)
        {
            boleto.NossoNumeroFormatado = $"{boleto.NossoNumero}{boleto.NossoNumeroDV}";
        }

        public string FormataCodigoBarraCampoLivre(Boleto boleto)
        {
            return boleto.CodigoBarra?.CampoLivre ?? string.Empty;
        }
    }
}
