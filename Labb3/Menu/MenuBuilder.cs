using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.Menu
{
    public class MenuBuilder
    {
        private int OptionIndex;
        private string Prompt;
        private string[] Options;

        public MenuBuilder(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            OptionIndex = 0;
        }

        private void DisplayOptions()
        {

            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                prefix = "  ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                if (i == OptionIndex)
                {
                    prefix = "->";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{prefix} {currentOption}");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    OptionIndex--;
                    if (OptionIndex == -1)
                    {
                        OptionIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    OptionIndex++;
                    if (OptionIndex == Options.Length)
                    {
                        OptionIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return OptionIndex;
        }
    }
}
