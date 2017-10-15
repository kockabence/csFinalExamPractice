using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2005tavasz
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Feladat1();
            Feladat2(input);
            Feladat34();
            Console.ReadKey();

        }

        static string[] Feladat1()
        {
            Console.WriteLine("Please enter the lotto numbers:");
            string[] input = Console.ReadLine().Split(' ');
            return input;

        }

        static void Feladat2(string[] input)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(Convert.ToInt32(input[i]));
            }

            //List<int> ordered = numbers.OrderBy(x => x).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers.OrderBy(n => n).ToList()[i]);
                Console.Write(" ");
            }

           
        }

        static void Feladat34()
        {
            Console.WriteLine("enter a number:");
            int rowNumber = Convert.ToInt32(Console.ReadLine());

            using (var reader = new StreamReader(@"C:\Users\Bence\Documents\info_erettsegi\2005_tavasz\forrasok\4lotto\lottosz.dat"))
            {
                for (int i = 0; i < rowNumber - 1; i++)
                {
                    Console.ReadLine();
                }

                string appropiateRow = Console.ReadLine();
                Console.WriteLine(appropiateRow);
            }
        }
    }
}
