using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PrimeNumbersNicklasEriksson.App
{
    public class PrimeNumberCalculator
    {
        public List<int> PrimeNumbers = new List<int>();
        public List<int> CompositeNumbers = new List<int>();
        public int InputNumber;

        /// <summary>
        /// First checks if list of prime numbers is empty or not.
        /// If it contains numbers it returns the largest number (its already sorted from when it was added).
        /// If it's not in a list it generate the next prime from the lowest number.
        /// Break condition is when next prime number is found.
        /// </summary>
        /// <param name="primeNumbers">List of primeNumbers</param>
        public void GenerateNextPrime(List<int> primeNumbers)
        {
            int nextPrime;
            if (primeNumbers.Count() > 0)
            {
                nextPrime = CalculateNextPrime(primeNumbers[primeNumbers.Count - 1]);
            }
            else
            {
                nextPrime = CalculateNextPrime(1);
            }

            Console.WriteLine($"\nNext prime number: {nextPrime}");

            Thread.Sleep(1500);
        }

        /// <summary>
        /// Calculates the next prime number from the given number.
        /// </summary>
        /// <param name="largestPrime">Largest number in list of prime numbers.</param>
        /// <returns></returns>
        private int CalculateNextPrime(int largestPrime)
        {
            int nextPrime = 0;

            for (int i = largestPrime + 1; i < int.MaxValue; i++)
            {
                if (CalculatePrime(i))
                {
                    nextPrime = i;
                    break;
                }
            }
            return nextPrime;
        }       

        /// <summary>
        /// From user input (string) checks if input can be converted into int32.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>If input is number it is returend. Else 0 is returned.</returns>
        public int CheckIfNumber(string input) => (Int32.TryParse(input, out int number)) ? number : 0;

        /// <summary>
        /// First checks if given number to be checked is in one of the lists.
        /// 1 > Checks if number is nr 2 (only even prime number) or if number is in our list of prime numbers.
        /// 2 > Checks if number is nr 1 or if number is in our list of composite numbers.
        /// 3 > Calculates if number is a prim.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>-1 if number is not prime. Actual number if it is prime.</returns>
        public int CheckForPrime(int number)
        {
            int nr = 0;
            InputNumber = number;

            if (number != 0)
            {
                if (number == 2 || CheckAgainstList(number, PrimeNumbers))
                {
                    return number;
                }
                else if (number == 1 || CheckAgainstList(number, CompositeNumbers))
                {
                    return -1;
                }

                if (CalculatePrime(number))
                {
                    nr = number;
                }
                else nr = -1;
            }

            return nr;
        }

        /// <summary>
        /// Calculates if given number is a prime by using modulus.
        /// </summary>
        /// <param name="number">Number to be checked.</param>
        /// <returns>true if number is prime.</returns>
        private bool CalculatePrime(int number)
        {
            if (number < 1) return false;
            var isItPrime = new List<bool>();

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) isItPrime.Add(false);
                else isItPrime.Add(true);
            }

            if (isItPrime.Contains(false))
            {
                CompositeNumbers.Add(number);
                CompositeNumbers.Sort();
                return false;
            }

            PrimeNumbers.Add(number);
            PrimeNumbers.Sort();
            return true;
        }

        /// <summary>
        /// Checks if number is contained within following list.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <param name="list">List to be searched.</param>
        /// <returns>true if number is in list.</returns>
        private bool CheckAgainstList(int number, List<int> list)
        {
            bool success;
            foreach (var nr in list)
            {
                if (nr == number) success = true;
            }
            success = false;

            return success;
        }        
    }
}