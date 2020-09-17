using System;

namespace TesteDiaADia
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Entendendo Enums
            Classe classe = new Classe();

            Console.WriteLine($"Numero: {classe.Numero}");
            Console.WriteLine($"Tipo: {classe.Tipo}");
            Console.WriteLine($"Validação: {classe.Tipo == 0}");
            Console.WriteLine($"Nome da classe: {nameof(Classe)}");
            #endregion

            #region Entendendo keywords: ref e out
            int x = 0;
            UpdateValue(ref x);
            Console.WriteLine($"x = {x}");

            Console.WriteLine("Nova branch");

            Console.WriteLine("Conteúdo para stash");
            #endregion

            #region Convertendo string para "tipo que eu quiser"
            int integer = ConvertTo<int>("1");
            Console.WriteLine($"Saída: {integer}");

            classe = ConvertTo<Classe>("10");
            Console.WriteLine($"Saída: {classe.Numero}");
            #endregion

        }

        /// <summary>
        /// Converte a entrada para o tipo passado por generics
        /// </summary>
        /// <typeparam name="T">Tipo informado</typeparam>
        /// <param name="outVariable">Variável externa que receberá resultado</param>
        /// <param name="text">Texto de entrada</param>
        /// <returns>true se a conversão funcionou, false caso contrário</returns>
        private static dynamic ConvertTo<T>(string text)
        {
            dynamic response = 0;

            Type type = typeof(T);

            if (type == typeof(int))
            {
                response = Int32.Parse(text);
            }
            else if (type == typeof(Classe))
            {
                response = new Classe()
                {
                    Numero = Int32.Parse(text)
                };
            }

            return response;
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
