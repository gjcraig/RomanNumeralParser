using System;

namespace RomanNumeralsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Roman Numeral Less than 101 (I,V,X,L,C)");
            string InputNumeral = Console.ReadLine();
            try
            {
                Console.WriteLine("{0} is equal to {1}", InputNumeral, ParseRomanNumeral(InputNumeral));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.ReadLine();
        }
        private static int  ParseRomanNumeral(string r)
        {
            int[] numbers = new int[r.Length];
            var count = 0;
            // First change from letters to numbers
            for(int i = 0; i < r.Length; i++)
            {
               if(r[i] == 'I')
                {
                    numbers[i] = 1;
                }
               if (r[i] == 'V')
                {
                    numbers[i] = 5;
                }
               if (r[i] == 'X')
                {
                    numbers[i] = 10;
                }
               if (r[i] == 'L')
                {
                    numbers[i] = 50;
                }
               if (r[i] == 'C')
                {
                    numbers[i] = 100;
                }
               if((r[i] != 'I') && (r[i] != 'V') && (r[i] != 'X') && (r[i] != 'L') && (r[i] != 'C'))
                {
                    throw new ArgumentException("Invalid Roman Numeral");
                }
            }
            // check for trivial case
            if (numbers.Length > 1)
            {
                // loop through checking if we need to add or minus
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i - 1] >= numbers[i])
                    {
                        count += numbers[i - 1];

                    }
                    else
                    {
                        count -= numbers[i - 1];
                    }
                }
                // Last number is not added in the loop so add now
                count += numbers[numbers.Length - 1];
                return count;
            }
            else
            {
                return numbers[0];
            }
        }
    }
}
