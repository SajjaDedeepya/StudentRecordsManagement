
using Npgsql;

namespace StudentRecordsManagement.Data
{
    public class StudentRepository
    {
        public void AddStudent(Student student)
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                string studentQuery = @"
                    INSERT INTO students (student_id, student_name)
                    VALUES (@id, @name)
                    ON CONFLICT (student_id) DO UPDATE
                    SET student_name = EXCLUDED.student_name;";

                using (var command = new NpgsqlCommand(
                    studentQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@id", student.StudentID);
                    command.Parameters.AddWithValue("@name", student.StudentName);
                    command.ExecuteNonQuery();
                }

                string moduleQuery = @"
                    INSERT INTO student_modules
                    (student_id, module_name, marks, grade)
                    VALUES (@id, @module, @marks, @grade)
                    ON CONFLICT (student_id, module_name)
                    DO UPDATE SET
                        marks = EXCLUDED.marks,
                        grade = EXCLUDED.grade;";

                foreach (var module in student.Modules)
                {
                    using var command = new NpgsqlCommand(
                        moduleQuery, connection, transaction);

                    command.Parameters.AddWithValue("@id", student.StudentID);
                    command.Parameters.AddWithValue("@module", module.Key);
                    command.Parameters.AddWithValue("@marks", module.Value.Marks);
                    command.Parameters.AddWithValue("@grade", module.Value.Grade);

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                Console.WriteLine("Student saved successfully to PostgreSQL!");
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void SearchStudent(string studentId)
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();

            string query = @"
        SELECT student_id, student_name
        FROM students
        WHERE student_id = @id";

            using var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", studentId);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                Console.WriteLine("Student not found.");
                return;
            }

            string id = reader.GetString(0);
            string name = reader.GetString(1);

            reader.Close();

            Student student = new Student(id, name);

            string moduleQuery = @"
        SELECT module_name, marks, grade
        FROM student_modules
        WHERE student_id = @id
        ORDER BY module_name";

            using var moduleCommand = new NpgsqlCommand(moduleQuery, connection);
            moduleCommand.Parameters.AddWithValue("@id", studentId);

            using var moduleReader = moduleCommand.ExecuteReader();

            while (moduleReader.Read())
            {
                student.AddModule(
                    moduleReader.GetString(0),
                    moduleReader.GetInt32(1),
                    moduleReader.GetString(2)
                );
            }

            Console.WriteLine("\nStudent found in PostgreSQL:");
            student.DisplayDetails();
        }
        public void DisplayAllStudents()
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();

            string query = @"
        SELECT
            s.student_id,
            s.student_name,
            sm.module_name,
            sm.marks,
            sm.grade
        FROM students s
        LEFT JOIN student_modules sm
            ON s.student_id = sm.student_id
        ORDER BY s.student_id, sm.module_name;";

            using var command = new NpgsqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            Dictionary<string, Student> students = new Dictionary<string, Student>();

            while (reader.Read())
            {
                string id = reader.GetString(0);
                string name = reader.GetString(1);

                if (!students.ContainsKey(id))
                {
                    students[id] = new Student(id, name);
                }

                if (!reader.IsDBNull(2) &&
                    !reader.IsDBNull(3) &&
                    !reader.IsDBNull(4))
                {
                    students[id].AddModule(
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetString(4)
                    );
                }
            }

            Console.WriteLine("\n========== ALL STUDENTS ==========");

            if (students.Count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            foreach (var student in students.Values)
            {
                student.DisplayDetails();
            }

            Console.WriteLine("\nTotal students: " + students.Count);
        }

    }
}
