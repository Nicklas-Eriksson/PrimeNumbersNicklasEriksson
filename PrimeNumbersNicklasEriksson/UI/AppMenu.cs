using System;
using System.Collections.Generic;
using System.Threading;
using PrimeNumbersNicklasEriksson.App;

namespace PrimeNumbersNicklasEriksson.UI
{
    public class AppMenu
    {
        /// <summary>
        /// Access the PrimeNumberCalculations.
        /// </summary>
        readonly PrimeNumberCalculator C = new PrimeNumberCalculator();

        /// <summary>
        /// Prompts user the user for a menu option.
        /// </summary>
        internal void Menu()
        {
            PrintMenu();
            Console.Write("\nOption: ");
            CheckAnswer(Console.ReadLine().Trim());
        }

        /// <summary>
        /// Prints the alternatives to the console.
        /// </summary>
        private void PrintMenu()
        {
            Console.Clear();
            Logo();
            Console.WriteLine("========================================");
            Console.WriteLine("|| 1. Check if number is a prime      ||");
            Console.WriteLine("|| 2. Print out our prime numbers     ||");
            Console.WriteLine("|| 3. Print out our composite numbers ||");
            Console.WriteLine("|| 4. Generate next prime number      ||");
            Console.WriteLine("|| 5. Exit application                ||");
            Console.WriteLine("========================================");
        }

        /// <summary>
        /// Checks if the answers corresponds with given alternatives.
        /// </summary>
        /// <param name="input">User input as a string</param>
        private void CheckAnswer(string input)
        {
            if (Int32.TryParse(input, out int nr))
            {
                if (nr == 1) AskForNumber();
                else if (nr == 2) PrintOutList("prime", C.PrimeNumbers);
                else if (nr == 3) PrintOutList("composite", C.CompositeNumbers);
                else if (nr == 4) C.GenerateNextPrime(C.PrimeNumbers);
                else if (nr == 5) ExitApplication();
            }
            else WrongInput();

            Menu();
        }              

        /// <summary>
        /// Prints out all numbers from any given list.
        /// </summary>
        /// <param name="type">Type of list (primary / composite).</param>
        /// <param name="list">List to be printed.</param>
        private void PrintOutList(string type, List<int> list)
        {
            Console.Clear();
            if (list.Count < 1)
            {
                Console.WriteLine("Your list is empty. Try adding some numbers to it!");
            }
            else
            {
                Console.WriteLine($"Here are our {type} numbers");
                foreach (var number in list)
                {
                    Console.WriteLine(number);
                }
            }

            Console.WriteLine("\nPress any key when you want to go back.");
            Console.ReadLine();
            Menu();
        }

        /// <summary>
        /// Asks for a number and checks if the number given is a prime or a composite number.
        /// After check is done user is prompted to go again or return back to menu.
        /// </summary>
        private void AskForNumber()
        {
            Console.Clear();
            bool loop;

            do
            {
                Logo();
                Console.Write("Enter a number: ");
                var number = C.CheckForPrime(C.CheckIfNumber(Console.ReadLine().Trim()));

                if (number == -1) Console.WriteLine($"\n{C.InputNumber} is a composite number.");
                else if (number == 0) 
                {
                    WrongInput();
                    AskForNumber();
                }
                else Console.WriteLine($"\n{C.InputNumber} is a prime number.");

                if (AskUserToGoAgain()) loop = true;
                else loop = false;

            } while (loop);

            Menu();
        }

        private void WrongInput()
        {
            Console.WriteLine("\nWrong inut. Try again.");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Asks user to go again with y / n.
        /// </summary>
        /// <returns>true if user wants to go again.</returns>
        private bool AskUserToGoAgain()
        {
            Console.WriteLine("\nWanna go again?");
            Console.Write("y/n: ");
            return CheckToGoAgain(Console.ReadLine().ToLower().Trim());
        }

        /// <summary>
        /// If user enters a invalid input it gets asked again.
        /// </summary>
        /// <param name="input">user input, "y" / "n".</param>
        /// <returns>true if user wants to go again.</returns>
        private bool CheckToGoAgain(string input)
        {
            Console.Clear();

            if (input == "y") return true;
            else if (input != "n")
            {
                WrongInput();
                AskUserToGoAgain();
            }

            return false;
        }

        /// <summary>
        /// Exits application with exit code 0.
        /// </summary>
        private static void ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("Exiting application...");
            Thread.Sleep(2500);
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints out an ascii-logo.
        /// </summary>
        private void Logo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"______     _                  _   _                 _                 _____       _            _       _             
| ___ \   (_)                | \ | |               | |               /  __ \     | |          | |     | |            
| |_/ / __ _ _ __ ___   ___  |  \| |_   _ _ __ ___ | |__   ___ _ __  | /  \/ __ _| | ___ _   _| | __ _| |_ ___  _ __ 
|  __/ '__| | '_ ` _ \ / _ \ | . ` | | | | '_ ` _ \| '_ \ / _ \ '__| | |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|
| |  | |  | | | | | | |  __/ | |\  | |_| | | | | | | |_) |  __/ |    | \__/\ (_| | | (__| |_| | | (_| | || (_) | |   
\_|  |_|  |_|_| |_| |_|\___| \_| \_/\__,_|_| |_| |_|_.__/ \___|_|     \____/\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   
                                                                                                                     
                                                                                                                     ");
            Console.ResetColor();
        }
   }
}
