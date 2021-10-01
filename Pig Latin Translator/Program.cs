using System;
using System.Text.RegularExpressions;

namespace Pig_Latin_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the piglaton translator.");
            bool RunProgram = true;
            while (RunProgram)
            {
                // Ask for word to translate
                bool enoughText = true;
                string input;
                while (enoughText)
                {

                    Console.WriteLine("Please enter a word to be translated.");
                    input = Console.ReadLine();

                    if (input.Length > 0)
                    {
                        Console.WriteLine(SentenceArray(input));
                        enoughText = false;
                    }
                    else
                    {
                        enoughText = true;
                    }
                }

                bool finalSay = true;
                while (finalSay)
                {
                    Console.WriteLine("Would you like to translate another word? y/n");
                    string MaybeEnd = Console.ReadLine();
                    if (MaybeEnd.ToLower() == "y")
                    {
                        RunProgram = true;
                        break;
                    }
                    else if (MaybeEnd.ToLower() == "n")
                    {
                        RunProgram = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option. Please type y or n.");
                    }
                }
            }
        }
        public static bool CheckForNonAlpha(string input)
        {
            bool result = true;
            if(Regex.IsMatch(input, "^[a-zA-Z]+$"))
            { 
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static string SentenceArray(string input)
        {
            input = input.ToLower();
            string[] ToBeTranslated = input.Split(" ", '.');
            string result = "";
            string sentence = "";
            foreach (string sub in ToBeTranslated)
            {
                bool AllLetters = CheckForNonAlpha(sub);
                if (AllLetters)
                {
                    result = ConvertToPig(sub);
                    sentence += " ";
                    sentence += result;
                }
                else
                {
                    sentence += " ";
                    sentence += sub;
                }
            }
            return sentence.Trim() + ".";
        }


        public static string ConvertToPig(string input)
        {
            string result;
            int i;
            int x = input.Length;
            for(i = 0; i < x; i++)
            {
                if(input.Substring(i, 1) == "a" || input.Substring(i, 1) == "e" || input.Substring(i, 1) == "i" || input.Substring(i, 1) == "o"  || input.Substring(i, 1) == "u")
                {
                    break;
                }
                
            }
            result = input.Substring(i);
            string FirstHalf = input.Substring(0, i);

            if (i == 0)
            {
                return input + "way";
            }
            else
            {
                return result + FirstHalf + "ay";
            }
        }


    }
}
