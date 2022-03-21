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

            //store colored letters for grid
            int[,] color1 = new int[6, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            //store guesses for grid
            string[] guesses = new string[6] { "OOOOO", "OOOOO", "OOOOO", "OOOOO", "OOOOO", "OOOOO" };
            //store colored letters for keyboard
            int[] colors2 = new int[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //introduction
            Console.Write("Welcome to Dordle! \n-----------------\n - You have 6 tries to guess the secret word. \n - Guess a 5 letter word, and the letters printed yellow are in the secret word, but in another spot.\n - Letters printed in green are letters in the secret word and in that spot.\n - Otherwise, not in the word.\n - Enjoy! :D\n - Press [ENTER] to start");
            Console.ReadLine();

            //generate random word
            word = randomWord();

            //6 guesses loop
            while (x != 6)
            {
                //prints grid of previous guesses
                WordGrid(color1, guesses);

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

                //fills color array with colored values {grid}
                for (int i = 0; i < 5; i++)
                {
                    color1[x, i] = colorize(guesses[x], word, i);
                }

                //fills second color array with colored values {keyboard}

                
                //checks if matchs
                if (guesses[x] != word)
                {
                    x++;
                    //lose sequence after 6 tries
                    if (x == 6)
                    {
                        WordGrid(color1, guesses);
                        Console.WriteLine("You Lose :(");
                        Console.WriteLine("The word was " + word);
                    }
                }
                else if (guesses[x] == word)
                {
                    WordGrid(color1, guesses);
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

                string[] wordBank = new string[36] { "chart", "voids", "pizza", "bongo", "fraud", "limbo", "youth", "quail", "money", "bring", "zebra", "jelly", "upper", "whale", "freer", "kebab", "flick", "audio", "idiot", "juddy", "pupil", "which", "there", "their", "about", "would", "these", "other", "words", "could", "write", "first", "water", "after", "where", "right" };

                Random rng = new Random();
                randomWord = rng.Next(0, 35);

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

            //prints 5x6
            static void WordGrid(int[,] color1, string[] guesses)
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
            }

            //prints keyboard with colors
            static void Keyboard(int[] colors2)
            {
                string[] alphabet = new string[26] { " q ", " w ", " e ", " r ", " t ", " y ", " u ", " i ", " o ", " p ", " a ", " s ", " d ", " f ", " g ", " h ", " j ", " k ", " l ", " z ", " x ", " c ", " v ", " b ", " n ", " m ", };
                
                for (int i = 0; i < 26; i++)
                {

                }
            }
        }
    }
}

