using System.Collections.Generic;

namespace BoletoNetCore
{
    public class Boletos : List<Boleto>
    {
        public string TermoAcordo { get; set; }
        public IBanco Banco { get; set; }
    }
}
