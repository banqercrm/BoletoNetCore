using System;
using System.Drawing;
using System.Globalization;
using BoletoNetCore.Util;
using Microsoft.VisualBasic;

namespace BoletoNetCore
{
    public class CodigoBarra
    {
        /// <summary>
        /// Representa��o num�rica do C�digo de Barras, composto por 44 posi��es
        ///    01 a 03 - 3 - Identifica��o  do  Banco
        ///    04 a 04 - 1 - C�digo da Moeda
        ///    05 a 05 � 1 - D�gito verificador do C�digo de Barras
        ///    06 a 09 - 4 - Fator de vencimento
        ///    10 a 19 - 10 - Valor
        ///    20 a 44 � 25 - Campo Livre
        /// </summary>
        public string CodigoDeBarras
        {
            get
            {
                string codigoSemDv = string.Format("{0}{1}{2}{3}{4}",
                                                      CodigoBanco,
                                                      Moeda,
                                                      FatorVencimento,
                                                      ValorDocumento,
                                                      CampoLivre);
                return string.Format("{0}{1}{2}",
                                        codigoSemDv.Left(4),
                                        DigitoVerificador,
                                        codigoSemDv.Right(39));
            }
        }

        /// <summary>
        /// A linha digit�vel � composta por cinco campos:
        ///      1� campo
        ///          composto pelo c�digo de Banco, c�digo da moeda, as cinco primeiras posi��es do campo 
        ///          livre e o d�gito verificador deste campo;
        ///      2� campo
        ///          composto pelas posi��es 6� a 15� do campo livre e o d�gito verificador deste campo;
        ///      3� campo
        ///          composto pelas posi��es 16� a 25� do campo livre e o d�gito verificador deste campo;
        ///      4� campo
        ///          composto pelo d�gito verificador do c�digo de barras, ou seja, a 5� posi��o do c�digo de 
        ///          barras;
        ///      5� campo
        ///          Composto pelo fator de vencimento com 4(quatro) caracteres e o valor do documento com 10(dez) caracteres, sem separadores e sem edi��o.
        /// </summary>
        public string LinhaDigitavel { get; set; } = String.Empty;

        /// <summary>
        /// C�digo do Banco (3 d�gitos)
        /// </summary>
        public string CodigoBanco { get; set; } = String.Empty;

        /// <summary>
        /// C�digo da Moeda (9 = Real)
        /// </summary>
        public int Moeda { get; set; } = 9;

        /// <summary>
        /// Campo Livre - Implementado por cada banco.
        /// </summary>
        public string CampoLivre { get; set; } = String.Empty;

        public long FatorVencimento { get; set; } = 0;

        public string ValorDocumento { get; set; } = String.Empty;

        public string DigitoVerificador
        {
            get
            {
                string codigoSemDv = string.Format("{0}{1}{2}{3}{4}",
                                      CodigoBanco,
                                      Moeda,
                                      FatorVencimento,
                                      ValorDocumento,
                                      CampoLivre);

                // Calcula D�gito Verificador do C�digo de Barras
                // Array referencia com d�gitos do c�digo de barras.
                var a = Array.ConvertAll(codigoSemDv.ToCharArray(), c => (int)char.GetNumericValue(c));

                var sum = 0;
                for (var i = 0; i < a.Length; i++)
                {
                    // Indice para leitura reversa.
                    var ir = a.Length - 1 - i;

                    // seq: 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5 ...
                    var seq = i % 8 + 2;

                    // Soma produto de n�mero sequencial e d�gito do c�digo de barras.
                    sum += seq * a[ir];
                }

                // Calcula-se o DAC.
                var resto = 11 - sum % 11;

                // Se o resultado desta, for igual a: 0, 1, 10 ou 11, considere DAC = 1.
                return resto <= 1 || resto > 9 ? "1" : resto.ToString();
            }
        }
    }
}