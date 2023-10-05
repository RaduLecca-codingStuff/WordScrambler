using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WordScrambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string Author = "Radu Dimitrie Lecca";
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|*  Welcome to the scrambler/d-escrambler                          Made by : "+Author+"                 *|");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Please type '0' if you wish to scramble a sentence / paragraph . Else if you want to de-scramble one, type '1'. |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            ScrambleFunctionality();
        }

        static void ScrambleFunctionality()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string message = Console.ReadLine();
            if (message == "0")
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("| Please type the word you wish to scramble: |");
                Console.WriteLine("----------------------------------------------");
                message = Console.ReadLine();
                Random random = new Random();
                int key = random.Next(3,10000);
                char[] mLetters = message.ToCharArray();
                char[] keyNumbers = key.ToString().ToCharArray();


                int codeI = 0;
                char compare;
                for(int i=0; i<mLetters.Length; i++)
                {
                    compare = mLetters[i];
                    if (compare != ' ')
                    {
                        mLetters[i] = (char)((int)mLetters[i] + (int)(keyNumbers[codeI] - '0'));

                        if (compare <= 'z' && compare >= 'a')
                        {
                            if (mLetters[i] > 'z')
                            {
                                mLetters[i] -= 'z';
                                mLetters[i] += 'a';
                            }

                        }
                        else if (compare <= 'Z' && compare >= 'A')
                        {
                            if (mLetters[i] > 'Z')
                            {
                                mLetters[i] -= 'Z';
                                mLetters[i] += 'A';
                            }
                        }
                        else if (compare <= '9' && compare >= '0')
                        {
                            if (mLetters[i] > '9')
                            {
                                mLetters[i] -= '9';
                                mLetters[i] += '0';
                            }
                        }
                    }

                    codeI++;
                    if(codeI>=keyNumbers.Length)
                        codeI = 0;
                }

                message = "";
                foreach (char l in mLetters)
                    message += l;

                Console.WriteLine("---------------------");
                Console.WriteLine("| scrambled message : "+message);
                Console.WriteLine("| key : "+key);
                Console.WriteLine("---------------------");


                Console.WriteLine('\n');
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("| If you wish to scramble or de-scramble another sentence or paragraph, type '0'. |");
                Console.WriteLine("| But If you wish to close the application, type something else.                  |");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                string response=Console.ReadLine();
                if (response =="0")
                ScrambleFunctionality();
                else 
                {
                    return;
                }
            }
            else if (message == "1")
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("| Please type the scrambled text here: |");
                Console.WriteLine("----------------------------------------");
                message =Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("| Now, please type the key used to scramble the text here (please only type ): |");
                Console.WriteLine("--------------------------------------------------------------------------------");
                string key=Console.ReadLine();
                char[] mLetters=message.ToCharArray();
                char[] kNumbers=key.ToCharArray();

                int codeI = 0;
                char compare;
                for (int i = 0; i < mLetters.Length; i++)
                {
                    compare = mLetters[i];
                    if(compare!=' ')
                    {
                        mLetters[i] = (char)((int)mLetters[i] - (int)(kNumbers[codeI] - '0'));

                        if (compare <= 'z' && compare >= 'a')
                        {
                            if (mLetters[i] < 'a')
                            {
                                mLetters[i] -= 'a';
                                mLetters[i] += 'z';
                            }

                        }
                        else if (compare <= 'Z' && compare >= 'A')
                        {
                            if (mLetters[i] < 'A')
                            {
                                mLetters[i] -= 'A';
                                mLetters[i] += 'Z';
                            }
                        }
                        else if (compare <= '9' && compare >= '0')
                        {
                            if (mLetters[i] < '0')
                            {
                                mLetters[i] -= '0';
                                mLetters[i] += '9';
                            }
                        }
                    }
                    codeI++;
                    if (codeI >= kNumbers.Length)
                        codeI = 0;
                }

                message = "";
                foreach (char l in mLetters)
                    message += l;
                Console.WriteLine("------------------------");
                Console.WriteLine("| de-scrambled message : " + message);
                Console.WriteLine("------------------------");

                Console.WriteLine('\n');
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("| If you wish to scramble or de-scramble another sentence or paragraph, type '0'. |");
                Console.WriteLine("| But If you wish to close the application, type something else.                  |");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                string response = Console.ReadLine();
                if (response == "0")
                    ScrambleFunctionality();
                else
                {
                    return;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("| Incorrect command. Please try to type either '0' for scramble or '1' for de-scramble. |");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                ScrambleFunctionality();
            }
        }
    }
}
