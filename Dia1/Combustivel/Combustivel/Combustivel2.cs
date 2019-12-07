using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Combustivel
{
    class Combustivel2
    {
        public static int convertToInt(String p)
        {
            return System.Convert.ToInt32(p);
        }

        public static List<String> leitor(string caminho)
        {
            StreamReader leitor_var = null;
            try
            {
                leitor_var = new StreamReader(caminho);
            }
            catch (IOException e)
            {
                Console.WriteLine("Não consegui abrir o arquivo");
            }
            List<String> linhas = new List<String>();
            String aux = leitor_var.ReadLine();
            //Salvando numa lista
            while (aux != null)
            {
                linhas.Add(aux);
                aux = leitor_var.ReadLine();
            }
            return linhas;
        }

        public static void escritor(string mensagem)
        {
            StreamWriter escritor_var = null;
            try
            {
                escritor_var = new StreamWriter("output.txt", true);
            }
            catch (IOException e)
            {
                Console.WriteLine("Não consegui abrir o arquivo");
            }
            escritor_var.Write("Output: " + mensagem);
        }

        public static List<int> listIntConvert(List<String> textos)
        {
            List<int> intermediaria = textos.ConvertAll(new Converter<String, int>(convertToInt));
            return intermediaria;
        }

        public static int operaRecursivo(int elemento)
        {
            if (elemento <= 0)
            {
                return 0;
            }
            elemento = elemento / 3 - 2;
            return elemento + operaRecursivo(elemento);
        }

        public static void Main(string[] args)
        {
            List<int> valores = listIntConvert(leitor("input.txt"));
            List<int> resultados = new List<int>();
            foreach (var elemento in valores)
            {
                Console.WriteLine(operaRecursivo(elemento));
                resultados.Add(operaRecursivo(elemento));
                //Thread.Sleep(7000);
            }

            int somafinal = 0;
            foreach(var elemento in resultados)
            {
                somafinal += elemento;
            }
            Console.WriteLine("A soma final é: " + somafinal);
            string mensagem = "A soma final é: " + somafinal;
            escritor(mensagem);
            Console.ReadLine();
        }
    }
}
