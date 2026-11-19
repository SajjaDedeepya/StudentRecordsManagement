# Student Records Management System

## 1. Project Overview
A console-based Student Records Management System developed using C# and PostgreSQL. The application stores student information, module details, marks and grades.

## 2. Technologies Used
- C#
- .NET
- PostgreSQL
- Npgsql
- Visual Studio Code

## 3. Project Folder Structure

```text
StudentRecordsManagement/
│
├── Data/
│   ├── DatabaseConnection.cs
│   └── StudentRepository.cs
│
├── Program.cs
├── Student.cs
├── StudentData.cs
│
├── StudentRecordsManagement.csproj
├── bin/
└── obj/
```

### File and Folder Description

| File / Folder | Purpose |
|---|---|
| `Program.cs` | Main application entry point. Connects to the database, saves student records, displays all students and accepts student ID searches. |
| `Student.cs` | Defines the Student class with student details, module information, marks, grades and display methods. |
| `StudentData.cs` | Provides the initial dataset containing 20 student records. |
| `Data/` | Contains database-related classes. |
| `DatabaseConnection.cs` | Establishes the PostgreSQL connection. |
| `StudentRepository.cs` | Handles database operations such as inserting, searching and displaying student records. |
| `.csproj` | Contains project configuration and package references. |
| `bin/` and `obj/` | Generated build and intermediate files. |

## 4. Features
1. Load student records from the application dataset.
2. Store student information in PostgreSQL.
3. Store multiple modules for each student.
4. Maintain module marks and grades.
5. Search students using Student ID.
6. Display all student records.
7. Retrieve student information directly from PostgreSQL.
8. Update existing student and module records without creating duplicates.

## 5. Object-Oriented Programming
The project uses a Student class to represent student information and encapsulate module-related operations.

## 6. Data Structures
- Dictionary collection to manage students using Student ID as the key.
- Dictionary collection to maintain module names, marks and grades.
- Relational database tables to store student and module information.

## 7. Database Design
Database: `StudentRecordsDB`

### Table 1: students

| Column | Description |
|---|---|
| student_id | Student ID (Primary Key) |
| student_name | Student name |

### Table 2: student_modules

| Column | Description |
|---|---|
| id | Module record ID (Primary Key) |
| student_id | Student reference (Foreign Key) |
| module_name | Module name |
| marks | Marks obtained |
| grade | Grade obtained |

Each student can have multiple module records.

## 8. Sample Dataset
The application contains 20 student records.

- The record for Charles Severance is based on the lecturer-provided data.
- Other student records are fictional sample records.
- Additional module values are sample data where the original information was not provided.

## 9. Database Configuration
The application connects to PostgreSQL using Npgsql.

Configure the following Windows user environment variable:

**Variable Name:** `DB_PASSWORD`

**Variable Value:** Your PostgreSQL password.

Both Hospital Management System and Student Records Management System use the same environment variable for database authentication.

The password is read from the environment variable instead of being hardcoded in the source code.

## 10. How to Run
1. Open the project in Visual Studio Code.
2. Open the terminal in the project directory.
3. Restore packages:

   `dotnet restore`

4. Build:

   `dotnet build`

5. Run:

   `dotnet run`

## 11. Conclusion
The project demonstrates C# programming, object-oriented concepts, collection-based data management, relational database design, PostgreSQL connectivity and student record retrieval.
