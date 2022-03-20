using System;

namespace dle_Wordle
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaration
            int x = 0;
            string word;

            //store colored letters
            int[,] color1 = new int[6, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            //store guess
            string[] guesses = new string[6] { "OOOOO", "OOOOO", "OOOOO", "OOOOO", "OOOOO", "OOOOO" };

            //introduction
            Console.WriteLine("Welcome to Dordle! \n-----------------\n - You have 6 tries to guess the secret word. \n - Guess a 5 letter word, and the letters printed yellow are in the secret word, but in another spot.\n - Letters printed in green are letters in the secret word and in that spot.\n - Otherwise, not in the word.\n - Enjoy! :D\n - Press [ENTER] to start");
            Console.ReadLine();

            //generate random word
            word = randomWord();

            //6 guesses loop
            while (x != 6)
            {
                Console.Clear();
                //array of words
                for (int j = 0; j < 6; j++)
                {
                    //array for char within words
                    for (int n = 0; n < 5; n++)
                    {
                        if (color1[j, n] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(guesses[j].Substring(n, 1));
                            Console.ResetColor();
                        }
                        else if (color1[j, n] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(guesses[j].Substring(n, 1));
                            Console.ResetColor();
                        }
                        else
                            Console.Write(guesses[j].Substring(n, 1));
                    }
                    //goes to next line
                    Console.WriteLine();
                }
                Console.WriteLine();

                //prompt
                Console.WriteLine("Guess #" + (x + 1) + "\n--------");
                Console.Write("What is your guess: ");
                guesses[x] = Console.ReadLine();

                //guess checker
                while (guessCheck(guesses[x]))
                {
                    Console.WriteLine();
                    Console.Write("Your guess is not valid\nGuess again: ");
                    guesses[x] = Console.ReadLine();
                }

                //fills color array with colored values {0, 1, 2}
                for (int i = 0; i < 5; i++)
                {
                    color1[x, i] = colorize(guesses[x], word, i);
                }

                //checks if matchs
                if (guesses[x] != word)
                {
                    x++;
                    //lose sequence after 6 tries
                    if (x == 6)
                    {
                        Console.Clear();
                        //array of words
                        for (int j = 0; j < 6; j++)
                        {
                            //array for char within words
                            for (int n = 0; n < 5; n++)
                            {
                                if (color1[j, n] == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(guesses[j].Substring(n, 1));
                                    Console.ResetColor();
                                }
                                else if (color1[j, n] == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(guesses[j].Substring(n, 1));
                                    Console.ResetColor();
                                }
                                else
                                    Console.Write(guesses[j].Substring(n, 1));
                            }
                            //goes to next line
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("You Lose :(");
                        Console.WriteLine("The word was " + word);
                    }
                }
                else if (guesses[x] == word)
                {
                    Console.Clear();
                    //array of words
                    for (int j = 0; j < 6; j++)
                    {
                        //array for char within words
                        for (int n = 0; n < 5; n++)
                        {
                            if (color1[j, n] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(guesses[j].Substring(n, 1));
                                Console.ResetColor();
                            }
                            else if (color1[j, n] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(guesses[j].Substring(n, 1));
                                Console.ResetColor();
                            }
                            else
                                Console.Write(guesses[j].Substring(n, 1));
                        }
                        //goes to next line
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    //win sequence
                    Console.WriteLine("Splendid! You win!");
                    x = 6;
                }
            }
            Console.ReadLine();

            //random word function
            static string randomWord()
            {
                int randomWord;

                string[] wordBank = new string[20] { "chart", "voids", "pizza", "bongo", "fraud", "limbo", "youth", "quail", "money", "bring", "zebra", "jelly", "upper", "whale", "freer", "kebab", "flick", "audio", "idiot", "juddy" };

                Random rng = new Random();
                randomWord = rng.Next(0, 19);

                return wordBank[randomWord];
            }

            //length of guess function
            static bool guessCheck(string guess)
            {
                bool returnValue = true;
                int length;

                length = guess.Length;
                if (length == 5)
                    returnValue = false;

                return returnValue;
            }

            //gets colored values from guess
            static int colorize(string guess, string word, int i)
            {
                //grey sub value
                int returnValue = 0;

                //yellow
                if (guess.Substring(i, 1) == word.Substring(i, 1))
                {
                    returnValue = 2;
                }
                //green
                else if (word.IndexOf(guess.Substring(i, 1)) != -1)
                {
                    returnValue = 1;
                }

                return returnValue;
            }
        }
    }
}



