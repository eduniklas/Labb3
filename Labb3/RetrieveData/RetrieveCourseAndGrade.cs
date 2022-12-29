using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.RetrieveData
{
    public class RetrieveCourseAndGrade
    {
        public bool GetCourseAndGrade() //SQL
        { /*Hämta en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen (ska lösas med SQL)
           Här får användaren direkt upp en lista med alla kurser i databasen, snittbetyget samt det högsta och lägsta betyget för varje kurs.*/
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=Hogwarts; Integrated Security=true");

            SqlDataAdapter sqlda = new SqlDataAdapter("Select Subjects.SubjectName, MAX(Grades.Grade) As 'TopGrade', MIN(Grades.Grade) As 'LowGrade', AVG(Grades.GradeID) As 'AverageGrade' From Grades " +
                "Join TakingSubjects On FK_GradeID = GradeID " +
                "Join Subjects On Subjects.SubjectID = FK_SubjectID " +
                "Group by SubjectName ", sqlcon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            Console.Clear();
            Console.WriteLine("|{0, -13}|{1, -13}|{2, -13}|{3, -14}|", "Subject", "Top Grade", "Low Grade", "Average Grade");
            Console.WriteLine(new string('-', 58));
            foreach (DataRow dr in dtbl.Rows)
            {
                Console.WriteLine("|{0, -13}|{1, -13}|{2, -13}|{3, -14}|", dr["SubjectName"], dr["TopGrade"], dr["LowGrade"], dr["AverageGrade"]);
            }
            Console.WriteLine(new string('-', 58));
            Console.ReadKey();
            return false;
        }
    }
}
