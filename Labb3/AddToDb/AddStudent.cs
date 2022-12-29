using Labb3.Menu;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.AddToDb
{
    public class AddStudent
    {
        public bool NewStudent()
        {
            string prompt = "What gender is the new student?\n";
            string[] genOptions = { "F", "M" };
            var genMenu = new MenuBuilder(prompt, genOptions);
            int genIndex = genMenu.Run();

            string classPrompt = "Which class is this student joining?\n";
            string[] classOptions = { "Orange", "Apple", "Mango", "Blueberry", "Pineapple", "Pear" };
            var classMenu = new MenuBuilder(classPrompt, classOptions);
            int classIndex = classMenu.Run();
            int studClass = classIndex + 1;

            string firstName = Input.setName("Enter first name: ");
            string lastName = Input.setName("Enter last name: ");
            string secNum = Convert.ToString(Input.ReadIntFromConsole("Enter security number, Ex. 19880310 : "));

            string prompt3 = "Do you want to save this to the database?\n" +
                "\nName: " + firstName + " " + lastName + "\nSecurity number: " + secNum + "\nClass: " + classOptions[classIndex] + "\nGender: " + genOptions[genIndex]+"\n";
            string[] yesOrNo = { "Yes", "No" };
            var save = new MenuBuilder(prompt3, yesOrNo);
            int optionIndex3 = save.Run();

            if (optionIndex3 == 0)
            {
                string sqlQuery = "Insert Into Students(PersonalNumber, FirstName, LastName, Gender, FK_ClassID)" +
                    "Values(@PN, @FN, @LN, @Gen, @FK_ClassID)";


                using (SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=Hogwarts; Integrated Security=true"))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
                {
                    cmd.Parameters.Add("@PN", System.Data.SqlDbType.NVarChar, 15).Value = secNum;
                    cmd.Parameters.Add("@FN", System.Data.SqlDbType.NVarChar, 50).Value = firstName;
                    cmd.Parameters.Add("@LN", System.Data.SqlDbType.NVarChar, 50).Value = lastName;
                    cmd.Parameters.Add("@Gen", System.Data.SqlDbType.Char, 1).Value = genOptions[genIndex];
                    cmd.Parameters.Add("@FK_ClassID", System.Data.SqlDbType.Int).Value = studClass;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Student saved!");
                Console.ResetColor();
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                return false;
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Student not saved!");
                Console.ResetColor();
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
                return false;
            }
        }
    }
}
