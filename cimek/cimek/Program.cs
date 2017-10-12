using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cimek
{
    class Program
    {

        private static List<string> ips = new List<string>();
        private static string full;

        static void Main(string[] args)
        {
            F1();
            F2();
            Console.WriteLine();
            F3();
            Console.WriteLine();
            F4();
            F5();
            Console.WriteLine();
            F6();
            Console.ReadKey();

        }

        static void F1()
        {
            using (var reader = new StreamReader(@"C:\Users\Bence\Downloads\e_inffor_14maj_fl\Forrasok\4_IPv6\ip.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();

                    if (temp != "" && (temp.Substring(0,2) == "fc" || temp.Substring(0, 2) == "fd" || temp.Substring(0,7) == "2001:0e" || temp.Substring(0,9) == "2001:0db8"))
                    {
                        ips.Add(temp);
                    }
                    
                }
            }
        }
        static void F2()
        {
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Az álllományban {ips.Count} darab adatsor van.");
        }
        static void F3()
        {
            List<int> counts = new List<int>();

            for (int i = 0; i < ips.Count; i++)
            {
                int count = 0;

                foreach (char c in ips[i])
                {
                    count += Convert.ToInt32(c);

                }
                counts.Add(count);
            }

            int lowest = counts.Min();
            int index = 0;
            for (int i = 0; i < counts.Count; i++)
            {
                if (counts[i] == lowest)
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine("3. feladat:");
            Console.WriteLine("A legalacsonyabb tárolt IP-cím::");
            Console.WriteLine(ips[index]);
        }
        static void F4()
        {
            int countdb8 = 0;
            int count0e = 0;
            int countfc = 0;


            for (int i = 0; i < ips.Count; i++)
            {
                if (ips[i].Substring(0, 9) == "2001:0db8")
                {
                    countdb8++;
                }
                else if (ips[i].Substring(0, 7) == "2001:0e")
                {
                    count0e++;
                }
                else if (ips[i].Substring(0, 2) == "fc" || ips[i].Substring(0, 2) == "fd")
                {
                    countfc++;
                }
            }
            Console.WriteLine("4. feladat:");
            Console.WriteLine($"Dokumentációs cím: {countdb8} darab");
            Console.WriteLine($"Globális egyedi cím: {count0e} darab");
            Console.WriteLine($"Helyi egyedi cím: {countfc} darab");




        }
        static void F5()
        {
            List<string> zeroes = new List<string>();

            foreach (string ip in ips)
            {
                int count = 0;

                foreach (char c in ip)
                {
                    if (c == '0')
                    {
                        count++;
                    }

                }
                if (count >= 18)
                {
                    zeroes.Add(ip);
                }
            }

            List<int> indexes = new List<int>();

            foreach (string ip in zeroes)
            {
                for (int i = 0; i < ips.Count; i++)
                {
                    if (ip == ips[i])
                    {
                        indexes.Add(i);
                    }
                }
            }

            using (var writer = new StreamWriter(@"C:\Users\Bence\Downloads\e_inffor_14maj_fl\Forrasok\4_IPv6\sok.txt"))
            {
                for (int i = 0; i < zeroes.Count; i++)
                {
                    writer.WriteLine($"{indexes[i] + 1} {zeroes[i]}");
                }
            }
        }
        static void F6()
        {
            Console.WriteLine("6. feladat: ");
            Console.Write("Kérek egy sorszámot: ");
            int input = Convert.ToInt32(Console.ReadLine()) - 1;

            full = ips[input];
            var split = full.Split(':');
            for (int i = 0; i < split.Length; i++)
            {
                
                if (split[i].Substring(0, 4) == "0000")
                {
                    split[i] = "0";
                }
                else if (split[i].Substring(0, 3) == "000")
                {
                    split[i] = "0" + split[i].Substring(3, 1);

                }
                else if (split[i].Substring(0, 2) == "00")
                {
                    split[i] = "0" + split[i].Substring(2, 2);

                }
                else if (split[i].Substring(0, 1) == "0")
                {
                    split[i] = split[i].Substring(1, 3);

                }

            }
            Console.WriteLine(full);
            for (int i = 0; i < split.Length - 1 ; i++)
            {
                Console.Write(split[i] + ":");
            }
            Console.Write(split[split.Length - 1]);
        }
        static void F7()
        {
            Console.WriteLine("7. feladat: ");
            var split = full.Split(':');
            for (int i = 0; i < split.Length; i++)
            {

                if (split[i].Substring(0, 4) == "0000")
                {
                    split[i] = "0";
                }
                else if (split[i].Substring(0, 3) == "000")
                {
                    split[i] = "0" + split[i].Substring(3, 1);

                }
                else if (split[i].Substring(0, 2) == "00")
                {
                    split[i] = "0" + split[i].Substring(2, 2);

                }
                else if (split[i].Substring(0, 1) == "0")
                {
                    split[i] = split[i].Substring(1, 3);

                }

            }
            List<List<int>> indexes = new List<List<int>>();
            int count = 0;
            for (int i = 0; i < split.Length; i++)
            {
                List<int> index = new List<int>();
                if (split[i] == "0")
                {
                    index.Add(i);
                    count++;
                }
                indexes.Add(index);
            }
        }

        static char[] remove0(string)
        {
            char[] lofasz = new char[5];
            return lofasz;
        }
    }
}
