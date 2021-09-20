using System;

namespace Palindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite uma palavra: ");
            string input = Console.ReadLine();

            //Convertendo para array de char para poder usar o método Reverse
            char [] array = input.ToCharArray();
            Array.Reverse(array);

            //Transformando o array invertido novamente em string
            string inverso = new string(array);
            Console.WriteLine($"A palavra {input} invertida é: {inverso}");
            Console.WriteLine();
            
            if (input.ToLower() == inverso.ToLower())
            {
                Console.WriteLine("É um palíndromo");
            }
            else
            {
                Console.WriteLine("Não é um palíndromo");
            }
        }
    }
}
