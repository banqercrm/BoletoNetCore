using System;
using System.IO;

namespace BoletoNetCore.QuestPDF.AppTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var currentDir = Directory.GetCurrentDirectory();
                Console.Write("Informe o diretório para gerar o pdf: ");
                currentDir = Console.ReadLine();
                if (!Directory.Exists(currentDir))
                    throw new Exception("O diretório informado não existe: " + currentDir);

                Console.WriteLine("Aguarde, gerando pdf...");

                var contaBancaria = new ContaBancaria
                {
                    Agencia = "0156",
                    Conta = "85305",
                    DigitoConta = "4",
                    CarteiraPadrao = "1",
                    TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
                    //VariacaoCarteiraPadrao = "A",
                    TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
                    TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa,
                    OperacaoConta = "05"

                };
                var banco = Banco.Instancia(Bancos.Brb);
                banco.Beneficiario = Utils.GerarBeneficiario("85305", "", "", contaBancaria);
                banco.FormataBeneficiario();

                var boletos = Utils.GerarBoletos(banco, 4, "N", 10);
                boletos.TermoAcordo = "Nesta data fica regido o acordo de novação de dívida entre a empresa BRBCARD, pessoa jurídica de direito privado, inscrita no CNPJ/MF 01.984.199/0001-00, com sede em SAUN, Quadra 5, bloco C, Torre III, sala 701 e 801, Asa Norte, Brasília-DF, CEP: 70.040-250; e do outro lado, o(a) devedor(a) do cartão, Sr.(a) ALIALDO LEITE, pessoa física inscrita no 99928949204. As Partes firmam, livre e espontaneamente, a presente transação, concordando que os termos aqui pactuados são resultantes da livre negociação entre si, como resultado de composição amigável. A fim de regularizar o saldo em aberto, ambas as partes decidem que a dívida do cartão BRB VISA INTERNACIONAL, sob o contrato 1101272, será parcelada em 5 vezes de R$ 1.150,22, aplicada a taxa de juros de 1,50%, IOF no valor de R$ 59,90 e CET de 19,56%, mediante pagamento à vista/boletos bancários enviados pelo Credor ao e-mail do Devedor. O Devedor pagará ao Credor, a importância certa, ajustada e total de R$ 5751,1, com a primeira parcela da negociação com vencimento para 27/07/2024, e as demais parcelas sempre para o dia 27, de forma sucessiva. A partir do 30º dia de atraso no pagamento de 1 ou mais parcelas, haverá quebra do acordo, o que, por sua vez, ocasionará o vencimento antecipado das parcelas vincendas e inscrição nos cadastros de proteção ao crédito e/ou protesto, além da incidência de a) correção monetária; b) multa de 2% sobre o valor remanescente devido; c) de juros de 1% (um) por cento ao mês até o efetivo pagamento. O Devedor, por sua vez, aceita a presente novação, obrigando-se a efetuar os pagamentos nas condições e formas descritas neste documento, e, neste ato, renuncia a eventual processo judicial ou demanda administrativa perante os órgãos de proteção ao consumidor, caso existam, se comprometendo, portanto, a requerer a baixa e/ou desistência destas. Com o cumprimento do acordo, a CREDORA dá integral quitação ao objeto desta transação e ambas as partes declaram nada mais ter a reclamar, em Juízo ou fora dele, referente ao débito acordado. E por se acharem justo e pactuados, conforme os termos e condições aqui estabelecidas, firmam o presente Termo de Renegociação de Dívida.";
                var bytes = boletos.ImprimirCarnePdf();
                Console.WriteLine("Pdf gerado, salvando arquivo...");
                var fileName = Path.Combine(currentDir, "carne.pdf");
                File.WriteAllBytes(fileName, bytes);
                Console.WriteLine("Pdf gerado com sucesso: " + fileName);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
