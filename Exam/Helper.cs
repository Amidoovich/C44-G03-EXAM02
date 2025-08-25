using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal static class Helper
    {
        public static int ReadAndValidateInt(string message, int min, int max)
        {
            int value;
            bool isParse;
            do
            {
                Console.WriteLine(message);
                isParse = int.TryParse(Console.ReadLine(), out value);
                if (!isParse || value < min || value > max)
                {
                    Console.WriteLine($"Invalid input\nPlease enter a valid integer between {min} and {max}.");
                }
            } while (!isParse || value < min || value > max);
            return value;
        }

        public static string ReadAndValidateString(string message)
        {
            string? input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input\nPlease enter a valid non-empty string.");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input!;
        }
    }
}
