using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radiozas
{
    class Program
    {
        private static List<int> days = new List<int>();
        private static List<int> senders = new List<int>();
        private static List<string> messages = new List<string>();
        private static List<int> bigWolves = new List<int>();
        private static List<int> smallWolves = new List<int>();

        static void Main(string[] args)
        {
            feladat1();
            Feladat2();
            Console.WriteLine();
            Feladat3();
            Console.ReadLine();
        }

        public static void feladat1()
        {
            using (var reader = new StreamReader(@"C:\Users\Bence\Downloads\e_inffor_15maj_fl\Forrasok\4_Expedicio\veetel.txt"))
            {
            
                while (!reader.EndOfStream)
                {

                    
                    var dayAndSender = reader.ReadLine().Split(' ');
                    days.Add(Convert.ToInt32(dayAndSender[0]));
                    senders.Add(Convert.ToInt32(dayAndSender[1]));
                    var message = reader.ReadLine();
                    messages.Add(message);
                    if (char.IsNumber(message[0]))
                    {
                        bigWolves.Add(message[0]);
                        smallWolves.Add(message[2]);
                    }

                }
            }
        }

        public static void Feladat2()
        {
            Console.WriteLine(senders[0]);
            Console.WriteLine(senders[senders.Count - 1]);
        }

        public static void Feladat3()
        {
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].Contains("farkas"))
                {
                    Console.WriteLine(days[i] + " " + senders[i]);
                    Console.WriteLine();
                }
            }
        }

        public static bool szame(string szo)
        {
            var valasz =  true;
            for (int i = 1; i < szo.Length; i++)
            {
                if (szo[i] < '0' || szo[i] > '9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }
    }
}
