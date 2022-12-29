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
    public class RetrieveEmployee
    {
        public bool GetEmployee()
        {
            string[] options = { "Headmaster", "Teacher", "Caretaker", "Admin", "All employees", "Go back" };
            string prompt = "Retrive employee\n";
            var getEmpMenu = new MenuBuilder(prompt, options);
            int optionIndex = getEmpMenu.Run();

            if (optionIndex <= 3)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=Hogwarts; Integrated Security=true");

                SqlDataAdapter sqlda = new SqlDataAdapter("Select Employee.FName, Employee.LName, Roles.RoleName From Employee " +
                    "Join Roles On RoleID = FK_RoleID" +
                    " where Roles.RoleName = '" + options[optionIndex] + "' ", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                Console.Clear();
                Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|", "First name", "Last name", "Role");
                Console.WriteLine(new string('-', 47));
                foreach (DataRow dr in dtbl.Rows)
                {
                    Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|", dr["FName"], dr["LName"], dr["RoleName"]);
                }
                Console.WriteLine(new string('-', 47));
                Console.WriteLine("\nPress any key to return");
                Console.ReadKey();
                return true;
            }
            else if (optionIndex == 4)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-6LJDH4RT; Initial Catalog=Hogwarts; Integrated Security=true");

                SqlDataAdapter sqlda = new SqlDataAdapter("Select Employee.FName, Employee.LName, Roles.RoleName From Employee " +
                    "Join Roles On RoleID = FK_RoleID", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                Console.Clear();
                Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|", "First name", "Last name", "Role");
                Console.WriteLine(new string('-', 47));
                foreach (DataRow dr in dtbl.Rows)
                {
                    Console.WriteLine("|{0, -15}|{1, -15}|{2, -13}|", dr["FName"], dr["LName"], dr["RoleName"]);
                }
                Console.WriteLine(new string('-', 47));
                Console.WriteLine("\nPress any key to return");
                Console.ReadKey();
                return true;
            }
            else { return false; }

        } //SQL
    }
}
