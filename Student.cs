
using System;
using System.Collections.Generic;

namespace StudentRecordsManagement
{
    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }

        public Dictionary<string, (int Marks, string Grade)> Modules { get; set; }

        public Student(string studentID, string studentName)
        {
            StudentID = studentID;
            StudentName = studentName;
            Modules = new Dictionary<string, (int Marks, string Grade)>();
        }

        public void AddModule(string moduleName, int marks, string grade)
        {
            Modules[moduleName] = (marks, grade);
        }

        public void DisplayDetails()
        {
            Console.WriteLine("\nStudent ID: " + StudentID);
            Console.WriteLine("Student Name: " + StudentName);
            Console.WriteLine("--------------------------------");

            foreach (var module in Modules)
            {
                Console.WriteLine("Module: " + module.Key);
                Console.WriteLine("Marks: " + module.Value.Marks);
                Console.WriteLine("Grade: " + module.Value.Grade);
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
