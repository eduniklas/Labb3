using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Labb3.Data;
using Labb3.Menu;
using Labb3.Models;

namespace Labb3.AddToDb
{
    public class AddEmployee
    {
        public bool NewEmployee()
        { //Lägga till ny personal        Användaren får möjlighet att mata in uppgifter om en ny anställd och den datan sparas då ner i databasen.
            string[] options = { "F", "M" };
            string prompt = "What gender is this new hire?";
            var genMenu = new MenuBuilder(prompt, options);
            int optionIndex = genMenu.Run();
            string gen = options[optionIndex];

            string prompt2 = "What position in this new hire filling?";
            string[] roleOptions = { "Teacher", "Admin", "Caretaker" };
            var roleMenu = new MenuBuilder(prompt2, roleOptions);
            int roleIndex2 = roleMenu.Run();

            string firstName = Input.setName("Enter first name: ");
            string lastName = Input.setName("Enter last name: ");
            string secNum = Convert.ToString(Input.ReadIntFromConsole("Enter security number, Ex. 19201021 : "));

            string prompt3 = "Do you want to save this to the database?\n" +
                "\nName: "+ firstName + " " + lastName + "\nSecurity number: " + secNum + "\nPosition: " + roleOptions[roleIndex2] + "\nGender: " + options[optionIndex]+"\n";
            string[] yesOrNo = { "Yes", "No" };
            var save = new MenuBuilder(prompt3, yesOrNo);
            int optionIndex3 = save.Run();

            if (optionIndex3 == 0)
            {
                using HogwartsContext context = new HogwartsContext();
                Employee e = new Employee()
                {
                    PersonalNumber = secNum,
                    Fname = firstName,
                    Lname = lastName,
                    Gender = gen,
                    FkRoleId = roleIndex2 + 2,
                };
                context.Employees.Add(e);
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saved!");
                Console.ResetColor();
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not saved!");
                Console.ResetColor();
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                return false;
            }
        } //E-F Inte klar
    }
}
