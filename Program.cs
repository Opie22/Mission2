// See https://aka.ms/new-console-template for more information
// Dallen Openshaw

namespace diceRoll
{
    // Second class that simulates dice rolling
    public class DiceRoller
    {
        private static Random _random = new Random();

        public int[] RollDice(int numRolls)
        {
            // Array to keep track of totals (2 through 12)
            int[] results = new int[13]; // Index 0 and 1 are unused

            for (int i = 0; i < numRolls; i++)
            {
                int die1 = _random.Next(1, 7);
                int die2 = _random.Next(1, 7);
                int total = die1 + die2;

                results[total]++;
            }

            return results;
        }
    }

    // Main class
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dice Roll Simulation!");
            Console.Write("How many times do you want to roll the dice? ");
            int numOfRolls = int.Parse(Console.ReadLine());

            // Create an instance of the DiceRoller class
            DiceRoller roller = new DiceRoller();

            // Call the RollDice method to simulate the rolls
            int[] rollResults = roller.RollDice(numOfRolls);

            // Display the histogram
            Console.WriteLine("\nHistogram of Dice Rolls (each * represents 1%):\n");
            PrintHistogram(rollResults, numOfRolls);
        }

        static void PrintHistogram(int[] results, int totalRolls)
        {
            for (int i = 2; i <= 12; i++)
            {
                // Calculate the percentage
                double percentage = (results[i] / (double)totalRolls) * 100;

                // Generate asterisks based on percentage (1 * = 1%)
                string asterisks = new string('*', (int)Math.Round(percentage));

                // Print the result
                Console.WriteLine($"{i,2}: {asterisks} ({percentage:F2}%)");
            }
        }
    }
}

