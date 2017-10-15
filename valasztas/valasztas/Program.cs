using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace valasztas
{
    class candidate
    {
        public int district;
        public int voters;
        public string lastName;
        public string firstName;
        public string party;
    }

    class Program
    {
        private static List<candidate> candidates = new List<candidate>();
        private static double sumVoters = 0;
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
            using (var reader = new StreamReader(@"C:\Users\Bence\Downloads\e_inffor_13maj_fl\Forrasok\4_Valasztasok\szavazatok.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var cand = new candidate();
                    var line = reader.ReadLine();
                    var splitted = line.Split(' ');
                    cand.district = Convert.ToInt32(splitted[0]);
                    cand.voters = Convert.ToInt32(splitted[1]);
                    cand.lastName = splitted[2];
                    cand.firstName = splitted[3];
                    cand.party = splitted[4];
                    candidates.Add(cand);
                }
            }
        }
        static void F2()
        {
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"A helyhatósági választáson {candidates.Count} képviselőjelölt indult");
        }
        static void F3()
        {
            Console.WriteLine("3. feladat");
            Console.Write("Adjon meg egy vezetéknevet: ");
            string lname = Console.ReadLine();
            Console.Write("Adjon meg egy utónevet: ");
            string fname = Console.ReadLine();

            int index = 0;

            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].firstName == fname && candidates[i].lastName == lname)
                {
                    index = i;
                    break;
                }
            }
            if (index == 0)
            {
                Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
            }
            else
            {
                Console.WriteLine($"Az illető {candidates[index].voters} szavazatot kapott.");
            }
        }
        static void F4()
        {
            

            for (int i = 0; i < candidates.Count; i++)
            {
                sumVoters += candidates[i].voters;
            }

            Console.WriteLine("4. feladat");
            Console.WriteLine($"A válastáson {sumVoters} állampolgár, a jogosultak {Math.Round((sumVoters / 12345)*100, 2)}%-a vett részt.");
        }
        static void F5()
        {
            double gyep = 0;
            double hep = 0;
            double tisz = 0;
            double zep = 0;
            double fugg = 0;

            for (int i = 0; i < candidates.Count; i++)
            {
                switch (candidates[i].party)
                {
                    case "GYEP":
                        gyep += candidates[i].voters;
                        break;
                    case "TISZ":
                        tisz += candidates[i].voters;
                        break;
                    case "HEP":
                        hep += candidates[i].voters;
                        break;
                    case "ZEP":
                        zep += candidates[i].voters;
                        break;
                    case "-":
                        fugg += candidates[i].voters;
                        break;
                }
            }
            Console.WriteLine("5. feladat:");
            Console.WriteLine($"Gyümölcsevők pártja: {Math.Round(gyep / sumVoters*100, 2)}%");
            Console.WriteLine($"Húsevők pártja: {Math.Round((hep / sumVoters) * 100, 2)}%");
            Console.WriteLine($"Tejivók szövetsége: {Math.Round((tisz / sumVoters) * 100, 2)}%");
            Console.WriteLine($"Zöldségevők pártja: {Math.Round((zep / sumVoters) * 100, 2)}%");
            Console.WriteLine($"Független jelöltek: {Math.Round((fugg / sumVoters) * 100, 2)}%");
        }
        static void F6()
        {
            Console.WriteLine("6. feladat:");
            int compare = 0;
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].voters > compare)
                {
                    compare = candidates[i].voters;
                }
            }

            List<int> indexes = new List<int>();
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].voters == compare)
                {
                    indexes.Add(i);
                }
            }
            for (int i = 0; i < indexes.Count; i++)
            {
                
                    Console.WriteLine($"{candidates[i].lastName} {candidates[i].firstName} {convertToFugg(candidates[i].party)}");
                
            }
        }
        static void F7()
        {
            List<candidate> first = new List<candidate>();
            List<candidate> second = new List<candidate>();
            List<candidate> third = new List<candidate>();
            List<candidate> fourth = new List<candidate>();
            List<candidate> fifth = new List<candidate>();
            List<candidate> sixth = new List<candidate>();
            List<candidate> seventh = new List<candidate>();
            List<candidate> eighth = new List<candidate>();

            for (int i = 0; i < candidates.Count; i++)
            {
                switch (candidates[i].district)
                {
                    case 1:
                        first.Add(candidates[i]);
                        break;
                    case 2:
                        second.Add(candidates[i]);
                        break;
                    case 3:
                        third.Add(candidates[i]);
                        break;
                    case 4:
                        fourth.Add(candidates[i]);
                        break;
                    case 5:
                        fifth.Add(candidates[i]);
                        break;
                    case 6:
                        sixth.Add(candidates[i]);
                        break;
                    case 7:
                        seventh.Add(candidates[i]);
                        break;
                    case 8:
                        eighth.Add(candidates[i]);
                        break;
                }
            }

            candidate firstWinner = getHighest(first);
            candidate secondWinner = getHighest(second);
            candidate thirdWinner = getHighest(third);
            candidate fourthWinner = getHighest(fourth);
            candidate fifthWinner = getHighest(fifth);
            candidate sixthWinner = getHighest(sixth);
            candidate seventhWinner = getHighest(seventh);
            candidate eighthWinner = getHighest(eighth);

            using (var writer = new StreamWriter(@"C:\Users\Bence\Downloads\e_inffor_13maj_fl\Forrasok\4_Valasztasok\kepviselok.txt"))
            {
                writer.WriteLine($"{firstWinner.district} {firstWinner.lastName} {firstWinner.firstName} {convertToFugg(firstWinner.party)}");
                writer.WriteLine($"{secondWinner.district} {secondWinner.lastName} {secondWinner.firstName} {convertToFugg(secondWinner.party)}");
                writer.WriteLine($"{thirdWinner.district} {thirdWinner.lastName} {thirdWinner.firstName} {convertToFugg(thirdWinner.party)}");
                writer.WriteLine($"{fourthWinner.district} {fourthWinner.lastName} {fourthWinner.firstName} {convertToFugg(fourthWinner.party)}");
                writer.WriteLine($"{fifthWinner.district} {fifthWinner.lastName} {fifthWinner.firstName} {convertToFugg(fifthWinner.party)}");
                writer.WriteLine($"{sixthWinner.district} {sixthWinner.lastName} {sixthWinner.firstName} {convertToFugg(sixthWinner.party)}");
                writer.WriteLine($"{seventhWinner.district} {seventhWinner.lastName} {seventhWinner.firstName} {convertToFugg(seventhWinner.party)}");
                writer.WriteLine($"{eighthWinner.district} {eighthWinner.lastName} {eighthWinner.firstName} {convertToFugg(eighthWinner.party)}");
            }

        }
        static candidate getHighest(List<candidate> input)
        {
            
            
            int index = 0;
            int compare = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].voters > compare)
                {
                    compare = input[i].voters;
                    index = i;
                }
            }
            return input[index];

        }
        static string convertToFugg(string input)
        {
            if (input == "-")
            {
                return "független";
            }
            else
            {
                return input;
            }
        }
    }
}
