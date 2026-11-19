
using System.Collections.Generic;

namespace StudentRecordsManagement
{
    public static class StudentData
    {
        public static Dictionary<string, Student> GetStudents()
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            // Student 1: Details provided in the assignment
            AddStudent(students, "20001010", "Charles Severance",
                (70, "B+"), (65, "B"), (55, "C"), (75, "B+"), (80, "A"));

            // Remaining 19 fictional sample records
            AddStudent(students, "20001011", "John Smith",
                (85, "A"), (78, "B+"), (72, "B"), (88, "A"), (90, "A+"));

            AddStudent(students, "20001012", "Emma Johnson",
                (65, "B"), (70, "B"), (60, "C+"), (75, "B+"), (82, "A"));

            AddStudent(students, "20001013", "Michael Brown",
                (55, "C"), (62, "C+"), (68, "B"), (70, "B"), (74, "B"));

            AddStudent(students, "20001014", "Sophia Williams",
                (92, "A+"), (89, "A"), (85, "A"), (91, "A+"), (88, "A"));

            AddStudent(students, "20001015", "David Miller",
                (73, "B"), (76, "B+"), (69, "B"), (80, "A"), (77, "B+"));

            AddStudent(students, "20001016", "Olivia Davis",
                (81, "A"), (84, "A"), (79, "B+"), (86, "A"), (90, "A+"));

            AddStudent(students, "20001017", "Daniel Wilson",
                (60, "C+"), (58, "C"), (65, "B"), (68, "B"), (72, "B"));

            AddStudent(students, "20001018", "Ava Taylor",
                (88, "A"), (91, "A+"), (87, "A"), (85, "A"), (93, "A+"));

            AddStudent(students, "20001019", "James Anderson",
                (70, "B"), (68, "B"), (72, "B"), (74, "B"), (76, "B+"));

            AddStudent(students, "20001020", "Isabella Thomas",
                (95, "A+"), (92, "A+"), (89, "A"), (94, "A+"), (91, "A+"));

            AddStudent(students, "20001021", "William Jackson",
                (64, "C+"), (69, "B"), (61, "C+"), (70, "B"), (73, "B"));

            AddStudent(students, "20001022", "Mia White",
                (78, "B+"), (82, "A"), (80, "A"), (84, "A"), (86, "A"));

            AddStudent(students, "20001023", "Benjamin Harris",
                (57, "C"), (63, "C+"), (59, "C"), (65, "B"), (68, "B"));

            AddStudent(students, "20001024", "Charlotte Martin",
                (86, "A"), (88, "A"), (90, "A+"), (87, "A"), (92, "A+"));

            AddStudent(students, "20001025", "Lucas Thompson",
                (72, "B"), (75, "B+"), (77, "B+"), (79, "B+"), (81, "A"));

            AddStudent(students, "20001026", "Amelia Garcia",
                (83, "A"), (80, "A"), (85, "A"), (88, "A"), (90, "A+"));

            AddStudent(students, "20001027", "Henry Martinez",
                (61, "C+"), (66, "B"), (64, "C+"), (70, "B"), (72, "B"));

            AddStudent(students, "20001028", "Harper Robinson",
                (90, "A+"), (87, "A"), (92, "A+"), (89, "A"), (95, "A+"));

            AddStudent(students, "20001029", "Alexander Clark",
                (76, "B+"), (74, "B"), (78, "B+"), (80, "A"), (82, "A"));

            return students;
        }

        private static void AddStudent(
            Dictionary<string, Student> students,
            string id,
            string name,
            (int Marks, string Grade) module1,
            (int Marks, string Grade) module2,
            (int Marks, string Grade) module3,
            (int Marks, string Grade) module4,
            (int Marks, string Grade) module5)
        {
            Student student = new Student(id, name);

            student.AddModule("Advanced Programming",
                module1.Marks, module1.Grade);

            student.AddModule("Adv. Databases",
                module2.Marks, module2.Grade);

            student.AddModule("Networking & Security",
                module3.Marks, module3.Grade);

            student.AddModule("Software Engineering (Sample)",
                module4.Marks, module4.Grade);

            student.AddModule("Data Analytics (Sample)",
                module5.Marks, module5.Grade);

            students.Add(id, student);
        }
    }
}
