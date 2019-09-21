using System;
using System.Collections.Generic;
using System.Text;

namespace MobileQuiz.Services
{
    public static class RandomNumbers
    {
        /// <summary>
        /// Retorna um numero aleatório
        /// </summary>
        /// <param name="max">Numero máximo a ser gerado</param>
        /// <returns></returns>
        public static int Random(int max)
        {
            return new Random().Next(max);
        }
    }
}
