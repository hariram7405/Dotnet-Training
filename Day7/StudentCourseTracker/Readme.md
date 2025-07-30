
# 🎓 Student Course Tracker Console App

A C# console application using **Entity Framework Core** and **SQL Server** to manage students and their enrolled courses.

---

## 📚 Overview

This app provides a text-based interface to:

- Add, update, and delete students
- Add, update, and delete courses
- View students with their enrolled courses
- View available courses

---

## 🛠️ Tech Stack

- .NET 6 / .NET Core
- Entity Framework Core
- SQL Server (Local or Remote)
- C# Console Application

---

## 🧱 Database Schema

### SQL Script

```sql
CREATE DATABASE StudentCourseDB;
GO

USE StudentCourseDB;
GO

CREATE TABLE Course (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Student (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    CourseId INT NOT NULL FOREIGN KEY REFERENCES Course(CourseId)
);
````
## 🗂️ Project Structure

```
StudentCourseTracker/
├── Models/
│   ├── Course.cs
│   ├── Student.cs
│   └── CourseContext.cs
├── Program.cs
├── StudentCourseTracker.csproj
└── README.md
```

---
## 📦 Seeded Data

If the database is empty, the following default courses will be added automatically:

* C#
* Java
* Python

IDs are reseeded to:

* Students start from ID 101
* Courses start from ID 1001

---

## 🔧 Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/student-course-tracker.git
cd student-course-tracker
```

### 2. Install Required NuGet Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 3. Scaffold the Database (Optional – if using Database First)

Use the following command to generate the `DbContext` and models from an existing SQL Server database:

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=StudentCourseDB;User=sa;Password=dummy123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c CourseContext -f
```

* `-o Models`: Output directory for models
* `-c CourseContext`: Name of the generated DbContext class
* `-f`: Force overwrite if files exist


---

## 🚀 Running the App

Once set up, run the application:

```bash
dotnet run
```

### Console Menu

```
--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
```

---


---


## OUTPUT
```
--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 1
Enter Student Name: Hari Ram L
Enter Course Id: 1001
Enter Age: 20
Student Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 2
Enter Student Id: 100
Enter Student Name: Hari L
Student Updated Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 1
Enter Student Name: Arun
Enter Course Id: 1002
Enter Age: 21
Student Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 1
Enter Student Name: Lokesh
Enter Course Id: 1002
Enter Age: 21
Student Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 4
Id    Name                 Age        Course Name
------------------------------------------------------------
100   Hari L               20         Java
101   Arun                 21         Python
102   Lokesh               21         Python

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 5
Enter Course Name: SpringBoot
Course Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 7
Enter Course Id: 1003
Course deleted successfully.

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 8
Course Id  Course Name
---------------------------------------------
1000       C#
1001       Java
1002       Python

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 9

```

--
# 🎓 Student Course Tracker Console App

A C# console application using **Entity Framework Core** and **SQL Server** to manage students and their enrolled courses.

---

## 📚 Overview

This app provides a text-based interface to:

- Add, update, and delete students
- Add, update, and delete courses
- View students with their enrolled courses
- View available courses

---

## 🛠️ Tech Stack

- .NET 6 / .NET Core
- Entity Framework Core
- SQL Server (Local or Remote)
- C# Console Application

---

## 🧱 Database Schema

### SQL Script

```sql
CREATE DATABASE StudentCourseDB;
GO

USE StudentCourseDB;
GO

CREATE TABLE Course (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Student (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    CourseId INT NOT NULL FOREIGN KEY REFERENCES Course(CourseId)
);
````
## 🗂️ Project Structure

```
StudentCourseTracker/
├── Models/
│   ├── Course.cs
│   ├── Student.cs
│   └── CourseContext.cs
├── Program.cs
├── StudentCourseTracker.csproj
└── README.md
```

---
## 📦 Seeded Data

If the database is empty, the following default courses will be added automatically:

* C#
* Java
* Python

IDs are reseeded to:

* Students start from ID 101
* Courses start from ID 1001

---

## 🔧 Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/student-course-tracker.git
cd student-course-tracker
```

### 2. Install Required NuGet Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 3. Scaffold the Database (Optional – if using Database First)

Use the following command to generate the `DbContext` and models from an existing SQL Server database:

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=StudentCourseDB;User=sa;Password=dummy123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c CourseContext -f
```

* `-o Models`: Output directory for models
* `-c CourseContext`: Name of the generated DbContext class
* `-f`: Force overwrite if files exist


---

## 🚀 Running the App

Once set up, run the application:

```bash
dotnet run
```

### Console Menu

```
--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
```

---


---


## OUTPUT
```
--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 1
Enter Student Name: Hari Ram L
Enter Course Id: 1001
Enter Age: 20
Student Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 2
Enter Student Id: 100
Enter Student Name: Hari L
Student Updated Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 1
Enter Student Name: Arun
Enter Course Id: 1002
Enter Age: 21
Student Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 1
Enter Student Name: Lokesh
Enter Course Id: 1002
Enter Age: 21
Student Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 4
Id    Name                 Age        Course Name
------------------------------------------------------------
100   Hari L               20         Java
101   Arun                 21         Python
102   Lokesh               21         Python

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 5
Enter Course Name: SpringBoot
Course Added Successfully

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 7
Enter Course Id: 1003
Course deleted successfully.

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 8
Course Id  Course Name
---------------------------------------------
1000       C#
1001       Java
1002       Python

--------Menu---------
1. Add Student
2. Update Student Details
3. Delete Student
4. View All Students with Courses
5. Add Course
6. Update Course Details
7. Delete Course
8. View All Courses
9. Exit
Enter your choice: 9

```

--