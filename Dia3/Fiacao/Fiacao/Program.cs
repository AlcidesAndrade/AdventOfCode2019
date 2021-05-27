using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fiacao
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

        public static string[] leitor(string caminho)
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
            String aux = leitor_var.ReadLine();
            string[] cortada = cortaString(aux);
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

        public static string [] leitorsecundario(string caminho)
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
            String aux = leitor_var.ReadLine();
            aux = leitor_var.ReadLine();
            string[] cortada = cortaString(aux);
            leitor_var.Close();
            return cortada;
        }

        public static List<int> listIntConvert(List<String> textos)
        {
            List<int> intermediaria = textos.ConvertAll(new Converter<String, int>(convertToInt));
            return intermediaria;
        }

        public static int[] vStringtovInt(string[] entrada)
        {
            int[] saida = new int[entrada.Length];
            for (int i = 0; i < entrada.Length; i++)
            {
                saida[i] = Convert.ToInt16(entrada[i]);
            }
            return saida;
        }

        public static int seta(string ponto)
        {
            if(ponto[0] == 'U')
            {
                return 8;
            }
            else if(ponto[0] == 'D')
            {
                return 2;
            }
            else if(ponto[0] == 'L')
            {
                return 4;
            }
            else if(ponto[0] == 'R')
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }

        public static List<int[]> direcao(string [] fio)
        {
            List<int[]> lis = new List<int[]>();

            int[] aux = { 0, 0 };
    
            int dir = seta(fio[0]);
            switch (dir)
            {
                case 8:
                    fio[0].Substring(0,fio.Length);
                    for (int i = 1; i < fio[0].Length; i++)
                    {
                        aux[1] = int.Parse(fio[0]);
                        lis.Add(aux);
                    }
                    break;
                case 2:
                    fio[0].Substring(0, fio.Length);
                    for (int i = 1; i < fio[0].Length; i++)
                    {
                        aux[1] = 0 - int.Parse(fio[0]);
                        lis.Add(aux);
                    }
                    break;
                case 4:
                    fio[0].Substring(0, fio.Length);
                    for (int i = 1; i < fio[0].Length; i++)
                    {
                        aux[0] = 0 - int.Parse(fio[0]);
                        lis.Add(aux);
                    }
                    break;
                case 6:
                    fio[0].Substring(0, fio.Length);
                    for (int i = 1; i < fio[0].Length; i++)
                    {
                        aux[0] = int.Parse(fio[0]);
                        lis.Add(aux);
                    }
                    break;
                default:
                    break;
            }
            
            return lis;
        }

        public static List<int> colisao(List<int> a, List<int> b)
        {
            List<int> colisao = new List<int>();
            foreach (var item in a)
            {
                if(b.Contains(item))
                {
                    colisao.Add(item);
                }
            }
            return colisao;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Startei");
            Console.WriteLine("Comecei mesmo, vai fazer o que?");
            Console.WriteLine("Não aguento mais testar");
            string [] fio1 = leitor("input.txt");
            string [] fio2 = leitorsecundario("input.txt");
            for (int i = 0; i < fio1.Length; i++)
            {
                Console.WriteLine(fio1[i]);
            }       
            List<int> fio_1 = new List<int>(direcao(fio1));
            List<int> fio_2 = new List<int>(direcao(fio2));
            List<int> inter = new List<int>(colisao(fio_1, fio_2));
            Console.WriteLine("Até ai nada bem, mas se...");
            Console.ReadLine();
        }
    }
}
