using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to encrypt:");
            string inputString = Console.ReadLine();
            

            try
            {
                EncryptString(inputString);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Line 49 doesn't work");
            }
            catch (ArgumentOutOfRangeException) 
            {
                Console.WriteLine("Line 70 doesn't work");
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static string EncryptString(string inputString)
        {
            // Guard clause to check if input is a valid string
            if (string.IsNullOrEmpty(inputString)) { Console.WriteLine("Input must  not be null or empty"); }
            
            // Reverse the string
            inputString = inputString.ToLower();
            char[] inputStringArray = inputString.ToCharArray();
            inputStringArray.Reverse();
            inputString = new string (inputStringArray);

            // Convert every second charatcer to uppercase
            var output = new StringBuilder();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (i % 2 == 0)
                {
                    output.Append(char.ToUpper(inputStringArray[i]));
                }
                else
                {
                    output.Append(inputString[i]);
                }
            }
            // Interpolateion and concatenation
            inputString = output.ToString();
            inputString = "Start-" + inputString + "-Code";


            // String conversion using ASCII values to shift each character by 1
            var finaloutput = new StringBuilder();
            char[] chars = inputString.ToCharArray();
            foreach (char c in chars)
            {
                string str = char.ToString(c);
                int value = int.Parse(str);
                string character = char.ConvertFromUtf32(value + 1);
                finaloutput.Append(character);
            }

            char[] finalEncryptionChars = finaloutput.ToString().ToCharArray();

            
            
            string finalEncryption = new string(finalEncryptionChars);
            return finalEncryption;
        }
    }
}

