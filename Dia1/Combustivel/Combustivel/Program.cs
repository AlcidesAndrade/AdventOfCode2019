using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Combustivel
{
    class Program
    {
        public static int StringToInt(String p)
        {
              return System.Convert.ToInt32(p);
        }
        public static void Main(string[] args)
        {
            //Lendo as informações do arquivo
            StreamReader leitor = new StreamReader("input.txt");
            List<String> linhas = new List<String>();
            String aux = leitor.ReadLine();
            //Salvando numa lista
            while (aux != null)
            {
                linhas.Add(aux);
                aux = leitor.ReadLine();
            }
            //Printando elementos
            foreach (var elemento in linhas)
            {
                Console.WriteLine(elemento);
            }
            //apenas a conversão de string para int
            List<int> intermediaria = linhas.ConvertAll(new Converter<String, int>(StringToInt));

            List<int> resposta = new List<int>();

            //Realizando a operação de calculo (divide por 3, trunca e subtrae 2)
            Console.WriteLine("*************************************");
            foreach (var elemento in intermediaria)
            {
                int conta = elemento / 3 - 2;
                resposta.Add(conta);
            }

            foreach (var elemento in resposta)
            {
                Console.WriteLine(elemento);
            }
            int soma = 0;
            foreach (var elemento in resposta)
            {
                soma += elemento;
            }

            Console.WriteLine("\nA soma final é: " + soma);
            Console.ReadLine();
        }
    }
}