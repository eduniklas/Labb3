using Labb3.Data;
using Labb3.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.RetrieveData
{
    public class RetrieveStudent
    {
        public bool GetStudent()
        {
            string prompt = "How do you want the students ordered?\n (DESC means reverse order (ö-a))";
            string[] options = { "FirstName", "LastName", "FistName DESC", "LastName DESC", "Go back" };
            var allStudMenu = new MenuBuilder(prompt, options);
            int orderIndex = allStudMenu.Run();

            using HogwartsContext context = new HogwartsContext();

            switch (orderIndex)
            {
                case 0:
                    Console.Clear();
                    var myStudent = context.Students.OrderBy(s => s.FirstName);
                    Console.WriteLine("|{0, -15}|{1, -15}|", "First name", "Last name");
                    Console.WriteLine(new string('-', 33));

                    foreach (var student in myStudent)
                    {
                        Console.WriteLine("|{0, -15}|{1, -15}|", student.FirstName, student.LastName);
                    }
                    Console.WriteLine(new string('-', 33));
                    Console.WriteLine("\nPress any key to return");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.Clear();
                    var myStudent1 = context.Students.OrderBy(s => s.LastName);
                    Console.WriteLine("|{0, -15}|{1, -15}|", "First name", "Last name");
                    Console.WriteLine(new string('-', 33));

                    foreach (var student in myStudent1)
                    {
                        Console.WriteLine("|{0, -15}|{1, -15}|", student.FirstName, student.LastName);
                    }
                    Console.WriteLine(new string('-', 33));
                    Console.WriteLine("\nPress any key to return");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    var myStudent2 = context.Students.OrderByDescending(s => s.FirstName);
                    Console.WriteLine("|{0, -15}|{1, -15}|", "First name", "Last name");
                    Console.WriteLine(new string('-', 33));

                    foreach (var student in myStudent2)
                    {
                        Console.WriteLine("|{0, -15}|{1, -15}|", student.FirstName, student.LastName);
                    }
                    Console.WriteLine(new string('-', 33));
                    Console.WriteLine("\nPress any key to return");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    var myStudent3 = context.Students.OrderByDescending(s => s.LastName);
                    Console.WriteLine("|{0, -15}|{1, -15}|", "First name", "Last name");
                    Console.WriteLine(new string('-', 33));

                    foreach (var student in myStudent3)
                    {
                        Console.WriteLine("|{0, -15}|{01, -15}|", student.FirstName, student.LastName);
                    }
                    Console.WriteLine(new string('-', 33));
                    Console.WriteLine("\nPress any key to return");
                    Console.ReadKey();
                    break;
                case 4:
                    break;
            }
            if (orderIndex == 4)
                return false;
            else
                return true;

        } //E-F
    }
}
