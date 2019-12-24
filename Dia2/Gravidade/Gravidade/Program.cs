using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gravidade
{
    class Program
    {
        public static int convertToInt(String p)
        {
            return System.Convert.ToInt32(p);
        }

        public static string[] cortaString(String p)
        {
            string[] corte = p.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return corte;
        }

        public static string [] leitor(string caminho)
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
            //List<String> linhas = new List<String>();
            String aux = leitor_var.ReadLine();
            string [] cortada = cortaString(aux);
            //Salvando numa lista
            for (int i = 0; i < cortada.Length; i++)
            {
                Console.WriteLine("\nElemento " + i + " valor: " + cortada[i]);
                //linhas.Add(cortada[i]);
            }
            Console.WriteLine("Oia, o tamanho da tua lista é: " + cortada.Length);
            leitor_var.Close();
            return cortada; 
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

        public static int [] vStringtovInt(string [] entrada)
        {
            int[] saida = new int[entrada.Length];
            for (int i = 0; i < entrada.Length; i++)
            {
                saida[i] = Convert.ToInt16(entrada[i]);
            }
            return saida;
        }
        public static int[] andor(int [] valores)
        {
            
            for (int i = 0; i < valores.Length; i+=4)
            {
                int j,k,m = 0;
                if (valores[i] == 1)
                {
                    j = valores[i + 3];
                    k = valores[i + 1];
                    m = valores[i + 2];
                    try
                    {
                        valores[j] = valores[k] + valores[m];
                    }
                    catch(Exception e)
                    {
                        return valores;
                    }
                }
                else if(valores[i] == 2)
                {
                    j = valores[i + 3];
                    k = valores[i + 1];
                    m = valores[i + 2];
                    try
                    {
                        valores[j] = valores[k] * valores[m];
                    }
                    catch(Exception e)
                    {
                        return valores;
                    }
                }
                else if(valores[i] == 99)
                {
                    Console.WriteLine("PAREI!");
                    Console.WriteLine("O valor na posição zero foi esse aqui ó: " + valores[0]);
                    Console.WriteLine("Valor de 1: " + valores[1] + "Valor de 2: " + valores[2]);
                    return valores;
                }
                else
                {
                    Console.WriteLine("Sei o que é isso não! Não me enche porra!");
                }
            }
            return valores;
        }

        public static void testandor(int [] aux)
        {
            int [] valores = aux;
            for (int a = 1; a < 99; a++)
            {
                for (int b = 1; b < 99; b++)
                {
                    valores[1] = a;
                    valores[2] = b;
                    andor(valores);
                    if(valores[0] == 19690720)
                    {
                        Console.WriteLine("a: " + a + " \nb:" + b);
                        a = 100;
                    }
                    valores = aux;
                }
            }
        }

        static void Main(string[] args)
        {
            //escritor("input.txt");
            string [] entrada = leitor("input.txt");
            int[] aux = vStringtovInt(entrada);
            //andor(aux);
            testandor(aux);
            //for (int i = 0; i < aux.Length; i++)
            //{
            //    Console.WriteLine(aux[i]);
            //}
            Console.ReadLine();
        }
    }
}
