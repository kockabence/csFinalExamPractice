using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace jaror
{
    class ellenorzes
    {
        public DateTime time;
        public string licensePlate;
    }

    class Program
    {
        private static List<ellenorzes> data = new List<ellenorzes>();

        static void Main(string[] args)
        {
            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            Console.ReadKey();

        }

        static void F1()
        {
            using (var reader = new StreamReader(@"C:\Users\Bence\Downloads\e_inffor_13okt_fl\Forrasok\4_Kozuti_ellenorzes\jarmu.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var temp = reader.ReadLine();
                    var splitted = temp.Split(' ');
                    ellenorzes current = new ellenorzes();
                    DateTime temptime = new DateTime();
                    temptime = temptime.AddHours(Convert.ToInt32(splitted[0]));
                    temptime = temptime.AddMinutes(Convert.ToInt32(splitted[1]));
                    temptime = temptime.AddSeconds(Convert.ToInt32(splitted[2]));
                    current.time = temptime;
                    current.licensePlate = splitted[3];
                    data.Add(current);


                }
            }
        }
        static void F2()
        {
            DateTime beginning = data[0].time;
            DateTime end = data[data.Count - 1].time;
            TimeSpan span = end - beginning;
            Console.WriteLine("2. feladat: ");
            Console.WriteLine($"Legalább ennyi óra hosszat dolgoztak: {span.Hours + 1}");
        }
        static void F3()
        {
            List<string> toPrint = new List<string>();
            List<int> hours = new List<int>();

            for (int i = 0; i < data.Count; i++)
            {
                if (!hours.Contains(data[i].time.Hour))
                {
                    string print = $"{data[i].time.Hour} óra: {data[i].licensePlate}";
                    toPrint.Add(print);
                    hours.Add(data[i].time.Hour);

                }
            }
            Console.WriteLine("3. feladat: ");
            for (int i = 0; i < toPrint.Count; i++)
            {
                Console.WriteLine(toPrint[i]);
            }
        }
        static void F4()
        {
            int countB = 0;
            int countK = 0;
            int countM = 0;

            for (int i = 0; i < data.Count; i++)
            {
                switch (data[i].licensePlate[0])
                {
                    case 'B':
                        countB++;
                        break;
                    case 'K':
                        countK++;
                        break;
                    case 'M':
                        countM++;
                        break;

                }
            }
            Console.WriteLine("4. feladat: ");
            Console.WriteLine($"Autóbuszból {countB} db., kamionból {countK} db. és motorból {countM} db. haladt át az ellenőrző pont előtt.");
        }
        static void F5()
        {
            List<TimeSpan> gaps = new List<TimeSpan>();

            for (int i = 0; i < data.Count - 1; i++)
            {
                TimeSpan gap = data[i + 1].time - data[i].time;
                gaps.Add(gap);
            }

            TimeSpan compare = new TimeSpan(0, 0, 0);
            int index = 0;

            for (int i = 0; i < gaps.Count; i++)
            {
                if (gaps[i] > compare)
                {
                    compare = gaps[i];
                    index = i;
                }
            }
            Console.WriteLine("5. feladat: ");
            Console.WriteLine($"A leghosszabb forgalommentes időszak: {data[index].time.TimeOfDay} - {data[index+1].time.TimeOfDay}");

        }
        static void F6()
        {
            Console.WriteLine("6. feladat: ");
            Console.Write("Adja meg a keresendő rendszámot: ");
            string input = Console.ReadLine();
            List<string> matches = new List<string>();
            for (int i = 0; i < data.Count; i++)
            {
                int charMatch = 0;

                for (int j = 0; j < data[i].licensePlate.Length; j++)
                {
                    

                    if (input[j] == data[i].licensePlate[j] || input[j] == '*')
                    {
                        charMatch++;
                    }
                }
                if (charMatch == data[i].licensePlate.Length)
                {
                    matches.Add(data[i].licensePlate);
                }
            }
            Console.WriteLine("Megfelelő rendszámok: ");
            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine(matches[i]);
            }
        }
        static void F7()
        {
            List<ellenorzes> checks = new List<ellenorzes>();
            ellenorzes lastChecked = data[0];
            checks.Add(data[0]);

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i].time >= lastChecked.time.AddMinutes(5))
                {
                    checks.Add(data[i]);
                    lastChecked = data[i];
                }
            }

            using (var writer = new StreamWriter(@"C:\Users\Bence\Downloads\e_inffor_13okt_fl\Forrasok\4_Kozuti_ellenorzes\vizsgalt.txt"))
            {
                for (int i = 0; i < checks.Count; i++)
                {
                    writer.WriteLine($"{checks[i].time.Hour} {addZero(checks[i].time.Minute)} {addZero(checks[i].time.Second)} {checks[i].licensePlate}");
                }
            }
        }

        static int addZero(int input)
        {
            int ret = 0;
            string temp = Convert.ToString(input);
            if (temp.Length == 2)
            {
                ret = Convert.ToInt32(temp);
            }
            else
            {
                ret = Convert.ToInt32('0' + temp);
            }
            return ret;
        }
    }
}
