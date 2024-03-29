﻿
using Data.Constants;

namespace Data.InputOutputUtils
{
    public class Utils
    {
        public static void ConsoleClearAndContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static GameLoop ConfirmationDialog()
        {
            string choice;
            do
            {
                choice = Console.ReadLine()!.ToLower();
                if (choice == "" || (choice != "yes" && choice != "no"))
                {
                    Console.WriteLine("Invalid input, try again\n");
                    continue;
                }
                break;
            } while (true);

            if (choice!.ToLower() == "yes")
                return GameLoop.CONTINUE;

            return GameLoop.EXIT;
        }

        public static string InputNonEmptyStringFormat(string message = "Input")
        {
            string? input;
            bool isError;
            do
            {
                Console.WriteLine(message + ": \n");
                input = Console.ReadLine();
                isError = string.IsNullOrWhiteSpace(input);
                if (isError)
                    Console.WriteLine(message + "cannot be a empty string, try again...\n");
            } while (isError);
            return input!;
        }

        public static int InputIntFormat(string message = "Input")
        {
            int input;
            bool isError;
            do
            {
                Console.WriteLine(message + ": \n");
                isError = !int.TryParse(Console.ReadLine(), out input);
                if (isError)
                    Console.WriteLine(message + "must be a number, try again...\n");
            } while (isError);
            return input;
        }
        public static EnemyType EnemyChoiceProbability()
        {
            var random = new Random();
            var choice = random.Next(1, 101);
            if (choice < 50)
                return EnemyType.Goblin;
            else if (choice >= 50 && choice < 80)
                return EnemyType.Brute;
            else
                return EnemyType.Witch;
        }

    }
}
