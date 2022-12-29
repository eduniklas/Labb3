using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb3
{
    public class Input
    {
        public static string setName(string msg)
        {
            string name;
            do
            {
                Console.Write(msg);
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Can't be empty, enter a name please");
                }

            } while (string.IsNullOrEmpty(name));
            return name;
        }
        public static int ReadIntFromConsole(string question)
        {
            Console.Write(question);
            int awnser;
            while (!int.TryParse(Console.ReadLine(), out awnser))
            {
                Console.WriteLine("Input must be numbers, try again");
            }
            return awnser;
        }
    }
}
