using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoNetCore.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Arredendamento de 2 casas descartando as demais.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal MidpointRoundingToZero(this decimal d)
        {
            return Math.Floor(d * 100M) / 100M;
        }
    }
}
