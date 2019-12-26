using System;

namespace Quiz.Services
{
    public static class RandomNumbersHelper
    {
        /// <summary>
        /// Retorna um numero aleatório
        /// </summary>
        /// <param name="max">Numero máximo a ser gerado</param>
        /// <returns></returns>
        public static int Random(int max) => new Random().Next(max);
    }
}