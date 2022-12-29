using Labb3.Menu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.RetrieveData
{
    public class RetrieveMonthlyGrade
    {
        public bool GetMonthlyGrades()
        {
            string[] options = { "SubjectName", "FirstName", "LastName", "Grade", "Go back" };
            string prompt = "In what order do you want to show this months grades?\n";
            var monthsGradeMenu = new MenuBuilder(prompt, options);
            int optionIndex = monthsGradeMenu.Run();

            if (optionIndex <= 3)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=Hogwarts; Integrated Security=true");

                SqlDataAdapter sqlda = new SqlDataAdapter("Select Students.FirstName, Students.LastName, Subjects.SubjectName, Grades.Grade From TakingSubjects " +
                    "Join Students On StudentID = FK_StudentID " +
                    "Join Subjects On SubjectID = FK_SubjectID " +
                    "Join Grades On GradeID = FK_GradeID " +
                    "Where GradeDate >= Current_timestamp -30 " +
                    "Order by '" + options[optionIndex] + "' ", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                Console.Clear();
                Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|{3, -8}|", "First name", "Last name", "Subject", "Grade");
                Console.WriteLine(new string('-', 56));
                foreach (DataRow dr in dtbl.Rows)
                {
                    Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|{3, -8}|", dr["FirstName"], dr["LastName"], dr["SubjectName"], dr["Grade"]);
                }
                Console.WriteLine(new string('-', 56));
                Console.WriteLine("Press any button to return");
                Console.ReadKey();

                return true;
            }
            else
            {
                return false;
            }

        } //SQL
    }
}
