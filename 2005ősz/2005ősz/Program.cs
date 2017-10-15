using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2005ősz
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = getString();
            var formattedInput = formatString(input);
            Console.WriteLine(formattedInput);
            var key = getKey();
            var multiply = multiplyString(input, key);
            Console.WriteLine(multiply);
            Console.ReadKey();


        }

        static string getString()
        {
            string input = null;
            while (input == null)
            {


                Console.WriteLine("Írd be te fasz");
                input = Console.ReadLine();


                if (input.Length == 0)
                {
                    input = null;
                }
                else if (input.Length > 255)
                {
                    input = null;
                }
            }
            return input;
        }

        static string formatString(string input)
        {
            return input.ToUpper();
        }

        static string getKey()
        {
            string key = null;
            while (key == null)
            {


                Console.WriteLine("Írd be a kulcsot, te fasz:");
                key = Console.ReadLine();


                if (key.Length == 0)
                {
                    key = null;
                }
                else if (key.Length > 5)
                {
                    key = null;
                }
            }
            return key.ToUpper();
        }

        static string multiplyString(string input, string key)
        {

            var times = input.Length / key.Length;
            var timesRemainder = input.Length % key.Length;
            string full = null;

            for (int i = 0; i < times; i++)
            {

                char character = key[i];
                full = full + key[i];



            }
            return full;
        }

        static string getCodedText(char actual)
        {
            string encoded = "";
            using (var reader = new StreamReader(@"C:\Users\Bence\Documents\info_erettsegi\2005_ősz\4_Vigenere\Vtabla.dat"))
            {
                int length = 0;
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    length++;
                }
                for (int i = 0; i < length; i++)
                {
                    var currentLine = reader.ReadLine();
                    if (currentLine[0] == actual)
                    {
                        encoded = encoded + currentLine[0];
                    }
                }
            }
        }

    }
}
