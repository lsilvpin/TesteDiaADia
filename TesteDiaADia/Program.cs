using System;

namespace TesteDiaADia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entendendo os Enums
            Classe classe = new Classe();

            Console.WriteLine($"Numero: {classe.Numero}");
            Console.WriteLine($"Tipo: {classe.Tipo}");
            Console.WriteLine($"Validação: {classe.Tipo == 0}");
            Console.WriteLine($"Nome da classe: {nameof(Classe)}");

            // Entendendo ref e out
            int x = 0;
            UpdateValue(ref x);
            Console.WriteLine($"x = {x}");
        }

        /// <summary>
        /// Modifica o valor da variável x pertencente ao escopo onde esta função foi chamada
        /// </summary>
        /// <param name="x">Variável sendo tratada</param>
        private static void UpdateValue(ref int x)
        {
            x = 12;
        }
    }
}
