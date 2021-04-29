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
                return html.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na execução da transação.", ex);
            }
        }
    }
}
