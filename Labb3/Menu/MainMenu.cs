using Labb3.Data;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Versioning;
using Labb3.Models;
using Labb3.RetrieveData;
using Labb3.AddToDb;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb3.Menu
{
    public class MainMenu
    {
        bool run = true;
        public void Start()
        {

            string prompt = "Use up and down arrows to navigate and press Enter to select option\n";
            string[] options = { "Retrive employee", "Retrive student", "Retrive class", "This months grades", "Retrive courses & grades", "Add student", "Add employee", "Exit" };
            var mainMenu = new MenuBuilder(prompt, options);
            int optionIndex = mainMenu.Run();

            while (optionIndex != 8)
            {
                while (run)
                {

                    switch (optionIndex)
                    {
                        case 0:
                            RetrieveEmployee retEmp = new RetrieveEmployee();
                            if (retEmp.GetEmployee() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 1:
                            RetrieveStudent retStud = new RetrieveStudent();
                            if (retStud.GetStudent() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 2:
                            RetrieveStudInClass retClass = new RetrieveStudInClass();
                            if (retClass.GetStudentsInClass() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 3:
                            RetrieveMonthlyGrade retMonthly = new RetrieveMonthlyGrade();
                            if (retMonthly.GetMonthlyGrades() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 4:
                            RetrieveCourseAndGrade retCourseGrade = new RetrieveCourseAndGrade();
                            if (retCourseGrade.GetCourseAndGrade() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 5:
                            AddStudent stud = new AddStudent();
                            if (stud.NewStudent() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 6:
                            AddEmployee emp = new AddEmployee();
                            if (emp.NewEmployee() == false)
                            {
                                optionIndex = mainMenu.Run();
                            }
                            break;
                        case 7:
                            optionIndex = Exit();
                            break;
                    }
                }
            }
        }
        public int Exit()
        {
            Console.Clear();
            Console.Write("\nByee");
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Thread.Sleep(150);
                    Console.Write(".");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Thread.Sleep(150);
                    Console.Write(".");
                    Console.ResetColor();
                }



            }
            run = false;
            return 8;
        }
    }
}
