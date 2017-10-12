using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace nezoter
{
    class Program
    {
        static int first = 0;
        static int second = 0;
        static int third = 0;
        static int fourth = 0;
        static int fifth = 0;

        static char[,] seats = new char[15, 20];
        static int[,] prices = new int[15, 20];

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
            using(var reader = new StreamReader(@"C:\Users\Bence\Downloads\e_inffor_14okt_fl\Forrasok\4_Nezoter\foglaltsag.txt"))
            {
                for (int i = 0; i < 15; i++)
                {
                    string line = reader.ReadLine();

                    for (int j = 0; j < 20; j++)
                    {
                        seats[i, j] = line[j];
                    }
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Bence\Downloads\e_inffor_14okt_fl\Forrasok\4_Nezoter\kategoria.txt"))
            {
                for (int i = 0; i < 15; i++)
                {
                    string line = reader.ReadLine();

                    for (int j = 0; j < 20; j++)
                    {
                        //nem tom miért 48, de csak így működik
                        prices[i, j] = Convert.ToInt32(line[j]) - 48;
                    }
                }
            }


        }
        static void F2()
        {
            Console.WriteLine("2. feladat");
            Console.Write("Adjon meg egy sor számot: ");
            int row = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Adjon meg egy szék számot: ");
            int seat = Convert.ToInt32(Console.ReadLine()) - 1;

            if (seats[row, seat] == 'x')
            {
                Console.WriteLine("Az adott hely foglalt.");
            }
            else if (seats[row, seat] == 'o')
            {
                Console.WriteLine("Az adott hely üres.");
            }
        }
        static void F3()
        {
            Console.WriteLine("3. feladat");
            int count = 0;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (seats[i, j] == 'x')
                    {
                        count++;
                    }
                }
            }
            double percent = Convert.ToDouble(count) / 300 *100;
            Console.WriteLine($"Az előadásra eddig {count} jegyet adtak el, ez a nézőtér {Math.Round(percent, 0)}%-a.");
        }
        static void F4()
        {
            Console.WriteLine("4. feladat");
            
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (seats[i, j] == 'x')
                    {
                        switch (prices[i, j])
                        {
                            case 1:
                                first++;
                                break;
                            case 2:
                                second++;
                                break;
                            case 3:
                                third++;
                                break;
                            case 4:
                                fourth++;
                                break;
                            case 5:
                                fifth++;
                                break; 
                        }
                    }
                }
            }
            Console.WriteLine($"A legtöbb jegyet a(z) {getMax(first, second, third, fourth, fifth) + 1}. árkategóriában adták el.");

        }
        static int getMax(int a, int b, int c, int d, int e)
        {
            List<int> numbers = new List<int>();
            numbers.Add(a);
            numbers.Add(b);
            numbers.Add(c);
            numbers.Add(d);
            numbers.Add(e);
            int index = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[index])
                {
                    index = i;
                }
            }
            return index;
        }
        static void F5()
        {
            Console.WriteLine("5. feladat");
            Console.WriteLine($"A színház pillanatnyi bevétele: {first*5000+second*4000+third*3000+fourth*2000+fifth*1500} Ft.");
            
        }
        static void F6()
        {
            Console.WriteLine("6. feladat:");

            int count = 0;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    if (seats[i, j - 1] =='x' && seats[i, j] == 'o' && seats[i, j + 1] == 'x')
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"Összesen {count} egyedülálló hely van.");
                
        }
        static void F7()
        {
            using (var writer = new StreamWriter(@"C:\Users\Bence\Downloads\e_inffor_14okt_fl\Forrasok\4_Nezoter\szabad.txt"))
            {
                string[,] combined = new string[15, 20];

                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (seats[i, j] == 'x')
                        {
                            combined[i, j] = "x";
                        }
                        else
                        {
                            combined[i, j] = Convert.ToString(prices[i, j]);
                        }
                    }
                }

                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        writer.Write(combined[i, j]);
                        
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
