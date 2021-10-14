using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoNetCore
{
    [CarteiraCodigo("1")]
    public class SorocredCarteira1 : ICarteira<BancoSorocred>
    {
        internal static Lazy<ICarteira<BancoSorocred>> Instance { get; } =
            new Lazy<ICarteira<BancoSorocred>>(() => new SorocredCarteira1());

        public void FormataNossoNumero(Boleto boleto)
        {
        }

        public string FormataCodigoBarraCampoLivre(Boleto boleto)
        {
            return "0".PadLeft(25, '0');
        }
    }
}
