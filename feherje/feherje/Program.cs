using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace feherje
{
    class Program
    {
        private static List<List<string>> aminoacids = new List<List<string>>();
        static int carbon = 12;
        static int hydrogen = 1;
        static int oxygen = 16;
        static int nitrogen = 14;
        static int sulphur = 32;

        struct lofasz
        {
            private static string faszlo;
            private static string geci;
        }

        lofasz aminosavak = new lofasz();


        static void Main(string[] args)
        {
            F1();
            F2();

            Console.ReadKey();
        

        }
        static void F1()
        {
            using (var reader = new StreamReader(@"D:\erettsegik\info_erettsegi\2006_tavasz\e_infoforras_06maj_fl\Forrasok\4_Feherje\aminosav.txt"))
            {
                while (!reader.EndOfStream)
                {
                    List<string> acids = new List<string>();

                    for (int i = 0; i < 7; i++)
                    {
                        acids.Add(reader.ReadLine());

                    }
                    aminoacids.Add(acids);
                    //acids.Clear();
                }
            }
        }
        static void F2()
        {
            Console.WriteLine("2. feladat: ");
            
            for (int i = 0; i < aminoacids.Count; i++)
            {
                Console.WriteLine($"A(z) {aminoacids[i][0]} relatív atomtömege: {getWeight(Convert.ToInt32(aminoacids[i][2]), Convert.ToInt32(aminoacids[i][3]), Convert.ToInt32(aminoacids[i][4]), Convert.ToInt32(aminoacids[i][5]), Convert.ToInt32(aminoacids[i][6]))}");
            }
            
                
            
        }

        static void F3()
        {
            List<string> nameAndWeight = new List<string>();

            for (int i = 0; i < aminoacids.Count; i++)
            {
                string temp = aminoacids[i][0] + Convert.ToString(getWeight(Convert.ToInt32(aminoacids[i][2]), Convert.ToInt32(aminoacids[i][3]), Convert.ToInt32(aminoacids[i][4]), Convert.ToInt32(aminoacids[i][5]), Convert.ToInt32(aminoacids[i][6])));
                nameAndWeight.Add(temp);
            }
        }
        static int getWeight(int c, int h, int o, int n, int s)
        {
            int weight = c * carbon + h * hydrogen + o * oxygen + n * nitrogen + s * sulphur;
            return weight;
        }
        static void writeToScreenAndFile(string input)
        {
            using (var writer = new StreamWriter(@"D:\erettsegik\info_erettsegi\2006_tavasz\e_infoforras_06maj_fl\Forrasok\4_Feherje\eredmeny.txt", false))
            {
                writer.WriteLine(input);
            }
            Console.WriteLine(input);
        }
    }
}
