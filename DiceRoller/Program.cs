using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Rolls = new List<int>();
            Random rnd = new Random();

            bool exiting = false;

            while (true)
            {
                Console.WriteLine("Would you like to: \"roll\", \"examine\" or \"exit\"?");

                switch (Console.ReadLine().ToLower()) {
                    case "roll":
                        int roll = D6(rnd);
                        Rolls.Add(roll);
                        Console.WriteLine("You rolled a {0}", roll);
                        break;

                    case "examine":
                        Console.WriteLine("How many rolls would you like to examine?");
                        Console.WriteLine("The number should be greater than 0 and less than or equal to the number of rolls already performed.");
                        Console.WriteLine("An invalid number will abort the examination and return to main menu.");

                        int examining = 0;
                        examining = GetNum();

                        if (examining > Rolls.Count)
                        {
                            Console.WriteLine("There are only {0} rolls so far.", Rolls.Count);
                            break;
                        }

                        if (examining < 1)
                        {
                            Console.WriteLine("That doesnt make sense.");
                            break;
                        }

                        int total = 0;

                        for (int i = 0; i < examining; i++)
                        {
                            total += Rolls[i];
                        }

                        float average = (float)total / (float)examining;

                        Console.WriteLine("Average: {0}", average);
                        Console.WriteLine("Total: {0}", total);
                        Console.WriteLine("Calculated from:");

                        for (int i = 0; i < examining; i++)
                        {
                            Console.WriteLine(Rolls[i]);
                        }

                        break;

                    case "exit":
                        exiting = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                Console.WriteLine();

                if (exiting)
                {
                    break;
                }
            }

            Console.WriteLine("Thanks for using Dice Roller: 9000");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static int GetNum()
        {
            int num = 0;

            while (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Please enter a number!");
            }

            return num;
        }

        public static int D6(Random rnd)
        {
            return rnd.Next(6) + 1;
        }
    }
}
