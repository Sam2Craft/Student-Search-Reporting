using System;

namespace OOPEXTRA
{
    class Program
    {
        static void Main(string[] args)
        {

            StudentFile myDataHandler = new StudentFile("students.txt");
            Student[] myStudents = myDataHandler.GetAllStudents();
            StudentReports reports = new StudentReports(myStudents);
            Utility myUtility = new Utility(myStudents);

            Menu menu = new Menu();

            int userInput = 0;
            while (userInput != 3)
            {
                userInput = menu.MainMenu();
                Routem(userInput, reports, myUtility, myStudents);
            }
        }

        static void Routem(int userInput, StudentReports reports, Utility myUtility, Student[] myStudents)
        {
            if (userInput == 1)
            {
                SearchStudent(myUtility, myStudents);
            }
            else
            {
                if (userInput == 2)
                {
                    ReportRoutem(reports);
                }
                else
                {
                    System.Console.WriteLine("Goodbye");
                }
            }
        }

        static void ReportRoutem(StudentReports reports)
        {
            Menu menu = new Menu();

            int userInput = 0;

            while (userInput != 4)
            {
                userInput = menu.ReportMenu();
                if (userInput == 1)
                {
                    reports.GpaRange();
                }
                else
                {
                    if (userInput == 2)
                    {
                        reports.HoursByYear();
                    }
                    else
                    {
                        if (userInput == 3)
                        {
                            reports.ExcessGpa();
                        }
                    }
                }

            }
        }

        static void SearchStudent(Utility myUtility, Student[] myStudents)
        {

            myUtility.Sort();
            System.Console.WriteLine("Enter the full name of the Student you are looking for : ");
            int found = myUtility.Search(Console.ReadLine());

            if (found != -1)
            {
                System.Console.WriteLine(myStudents[found].ToString());
            } else{
                System.Console.WriteLine("This Student is not on file");
            }

        }
    }
}