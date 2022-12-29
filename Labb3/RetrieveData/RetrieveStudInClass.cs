using Labb3.Data;
using Labb3.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.RetrieveData
{
    public class RetrieveStudInClass
    {
        public bool GetStudentsInClass()
        {
            Console.WriteLine("\nThis might take awhile..");
            using (var context = new HogwartsContext())
            {
                var allClasses = from c in context.Classes
                                 select c;
                Console.Clear();
                Console.WriteLine("|{0,-15}|{1,-15}|", "Class name", "Year");
                Console.WriteLine(new string('-', 33));
                foreach (var Class in allClasses)
                {
                    Console.WriteLine("|{0,-15}|{1,-15}|", Class.ClassName, Class.ClassYear);
                }
                Console.WriteLine(new string('-', 33));
                Console.WriteLine("\nPress any key to get your options");
                Console.ReadKey();

                string[] options = { "Orange", "Apple", "Mango", "Blueberry", "Pineapple", "Pear" };
                string prompt = "Choose wich class you want to look up\n";
                var chooseClass = new MenuBuilder(prompt, options);
                int orderIndex = chooseClass.Run();
                string classInput = options[orderIndex];

                string[] options2 = { "FirstName", "LastName", "FirstName DESC", "LastName DESC" };
                string prompt2 = "What order do you want the students in?\n";
                var chooseOrder = new MenuBuilder(prompt2, options2);
                int orderIndex2 = chooseOrder.Run();
                string orderInput = options2[orderIndex2];

                switch (orderIndex2)
                {
                    case 0:
                        var studInClass = from c in context.Classes
                                          where c.ClassName == classInput
                                          join s in context.Students on c.ClassId equals s.FkClassId
                                          orderby s.FirstName
                                          select new
                                          {
                                              s.FirstName,
                                              s.LastName,
                                              c.ClassName,
                                          };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        Console.WriteLine("\nPress any key to return to start");
                        break;

                    case 1:
                        var studInClass1 = from c in context.Classes
                                           where c.ClassName == classInput
                                           join s in context.Students on c.ClassId equals s.FkClassId
                                           orderby s.LastName
                                           select new
                                           {
                                               s.FirstName,
                                               s.LastName,
                                               c.ClassName,
                                           };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass1)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        Console.WriteLine("\nPress any key to return to start");
                        break;

                    case 2:
                        var studInClass2 = from c in context.Classes
                                           where c.ClassName == classInput
                                           join s in context.Students on c.ClassId equals s.FkClassId
                                           orderby s.FirstName descending
                                           select new
                                           {
                                               s.FirstName,
                                               s.LastName,
                                               c.ClassName,
                                           };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass2)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        Console.WriteLine("\nPress any key to return to start");
                        break;

                    case 3:
                        var studInClass3 = from c in context.Classes
                                           where c.ClassName == classInput
                                           join s in context.Students on c.ClassId equals s.FkClassId
                                           orderby s.LastName descending
                                           select new
                                           {
                                               s.FirstName,
                                               s.LastName,
                                               c.ClassName,
                                           };
                        Console.Clear();
                        Console.WriteLine("|{0,-15}|{1,-15}|{2, -15}|", "Class name", "First name", "Last name");
                        Console.WriteLine(new string('-', 49));
                        foreach (var stud in studInClass3)
                        {
                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|", stud.ClassName, stud.FirstName, stud.LastName);
                        }
                        Console.WriteLine(new string('-', 49));
                        Console.WriteLine("\nPress any key to return to start");
                        break;

                }
            };
            Console.ReadKey();
            return false;
        } //E-F
    }
}
