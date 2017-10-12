using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fejvagyiras
{
    class Program
    {
        private static List<char> throws = new List<char>();
        private static List<List<char>> fs = new List<List<char>>();

        static void Main(string[] args)
        {

            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            Console.ReadKey();
        }

        static char coinToss()
        {
            Random rnd = new Random();
            char ret;
            int side = rnd.Next(0, 2);
            if (side == 0)
            {
                ret = 'F';
            }
            else
            {
                ret = 'I';
            }
            return ret;
        }
        static void F1()
        {
            Console.WriteLine("1. feladat");
            Console.WriteLine($"A pénzfeldobás eredménye: {coinToss()}");
            Console.WriteLine();
        }
        static void F2()
        {
            Console.WriteLine("2. feladat: ");
            Console.Write("Tippeljen (F/I)= ");
            char input = Convert.ToChar(Console.ReadLine());

            char thrown = coinToss();
            Console.WriteLine($"A tipp {input}, a dobás eredménye {thrown} volt.");

            if (input == thrown)
            {
                Console.WriteLine("Ön eltalálta!");
            }
            else
            {
                Console.WriteLine("Ön balfasz!");
            }
            Console.WriteLine();


        }
        static void F3()
        {
            using (var reader = new StreamReader(@"C:\Users\Bence\Downloads\e_inffor_15okt_fl\Forrasok\4_Fej_vagy_iras\kiserlet.txt"))
            {
                while (!reader.EndOfStream)
                {
                    throws.Add(Convert.ToChar(reader.ReadLine()));
                }
            }

            Console.WriteLine("3. feladat: ");
            Console.WriteLine($"A kísérlet {throws.Count} dobásból állt.");
            Console.WriteLine();
        }
        static void F4()
        {
            int fcount = 0;
            for (int i = 0; i < throws.Count; i++)
            {
                if (throws[i] == 'F')
                {
                    fcount++;
                }
            }
            double freq = Convert.ToDouble(fcount) / Convert.ToDouble(throws.Count);
            freq = Math.Round(freq * 100, 2);

            Console.WriteLine("4. feladat:");
            Console.WriteLine($"A kísérlet során a fej relatív gyakorisága {freq}% volt");
            Console.WriteLine();

        }
        static void F5()
        {
            int count = 0;
            for (int i = 0; i < throws.Count - 2; i += 2)
            {
                if (throws[i] == 'F' && throws[i + 1] == 'F' && throws[i+2] != 'F')
                {
                    count++;
                }
            }
            Console.WriteLine("5. feladat");
            Console.WriteLine($"A kísérlet során {count} alkalommal fordult elő, hogy pontosan két fejet dobtak egymás után.");
        }
        static void F6()
        {
            int inc = 0;
            List<char> charlist = new List<char>();

            for (int i = 0; i < throws.Count; i++)
            {
                if (throws[i] == 'F')
                {
                    charlist.Add(throws[i]);
                }
                else
                {
                    fs.Add(charlist);
                }
            }

        }
    }
}
