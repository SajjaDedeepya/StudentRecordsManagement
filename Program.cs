
using System;
using System.Collections.Generic;
using StudentRecordsManagement.Data;

namespace StudentRecordsManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection.TestConnection();

            Dictionary<string, Student> students = StudentData.GetStudents();

            StudentRepository repository = new StudentRepository();

            Console.WriteLine("\nSaving student records to PostgreSQL...");

            foreach (var student in students.Values)
            {
                repository.AddStudent(student);
            }

            repository.DisplayAllStudents();

            Console.Write("\nEnter Student ID to search: ");

            string studentId = Console.ReadLine() ?? "";

            repository.SearchStudent(studentId);
        }
    }
}
