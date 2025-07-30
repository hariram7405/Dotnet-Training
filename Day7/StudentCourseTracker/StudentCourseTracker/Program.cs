using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;  
using StudentCourseTracker.Models;

class Program
{
    public static void Main(string[] args)
    {
        using (var context = new CourseContext())
        {
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('StudentS', RESEED, 100)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Courses', RESEED, 1000)");

            if (!context.Courses.Any())
            {
                var coursesToAdd = new[]
                {
                new Course { CourseName = "C#" },
                new Course { CourseName = "Java" },
                new Course { CourseName = "Python" }
            };
                context.Courses.AddRange(coursesToAdd);
                context.SaveChanges();
            }
        }

        while (true)
        {
            Menu();
            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    UpdateStudent();
                    break;
                case 3:
                    DeleteStudent();
                    break;
                case 4:
                    ViewAllStudents();
                    break;
                case 5:
                    AddCourse();
                    break;
                case 6:
                    UpdateCourse();
                    break;
                case 7:
                    DeleteCourse();
                    break;
                case 8:
                    ViewAllCourses();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            Console.WriteLine(); // extra line for readability
        }
    }

    public static void Menu()
    {
        Console.WriteLine("--------Menu---------");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Update Student Details");
        Console.WriteLine("3. Delete Student");
        Console.WriteLine("4. View All Students with Courses");
        Console.WriteLine("5. Add Course");
        Console.WriteLine("6. Update Course Details");
        Console.WriteLine("7. Delete Course");
        Console.WriteLine("8. View All Courses");
        Console.WriteLine("9. Exit");
    }

    public static void AddStudent()
    {
        using (var context = new CourseContext())
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course Id: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("Invalid Course Id!");
                return;
            }

            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid Age!");
                return;
            }

            var student = new Student
            {
                StudentName = name,
                CourseId = courseId,
                Age = age
            };

            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Student Added Successfully");
        }
    }

    public static void UpdateStudent()
    {
        using (var context = new CourseContext())
        {
            Console.Write("Enter Student Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Student Id!");
                return;
            }

            var student = context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                Console.WriteLine("Student with given id not found! Enter valid Id");
                return;
            }

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            student.StudentName = name;

            context.SaveChanges();
            Console.WriteLine("Student Updated Successfully");
        }
    }

    public static void DeleteStudent()
    {
        using (var context = new CourseContext())
        {
            Console.Write("Enter Student Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Student Id!");
                return;
            }

            var student = context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student with given id not found.");
            }
        }
    }

    public static void ViewAllStudents()
    {
        using (var context = new CourseContext())
        {
            var students = context.Students
                .Include(s => s.Course) 
                .Select(e => new
                {
                    e.StudentId,
                    e.StudentName,
                    e.Age,
                    CourseName = e.Course != null ? e.Course.CourseName : "Not Available"
                }).ToList();

            if (students.Any())
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-20}", "Id", "Name", "Age", "Course Name");
                Console.WriteLine(new string('-', 60));
                foreach (var s in students)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-20}", s.StudentId, s.StudentName, s.Age, s.CourseName);
                }
            }
            else
            {
                Console.WriteLine("No Records to Display");
            }
        }
    }

    public static void AddCourse()
    {
        using (var context = new CourseContext())
        {
            Console.Write("Enter Course Name: ");
            string name = Console.ReadLine();

            var course = new Course
            {
                CourseName = name,
            };

            context.Courses.Add(course);
            context.SaveChanges();
            Console.WriteLine("Course Added Successfully");
        }
    }

    public static void UpdateCourse()
    {
        using (var context = new CourseContext())
        {
            Console.Write("Enter Course Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Course Id!");
                return;
            }

            var course = context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null)
            {
                Console.WriteLine("Course with given id not found! Enter valid Id");
                return;
            }

            Console.Write("Enter Course Name: ");
            string name = Console.ReadLine();
            course.CourseName = name;

            context.SaveChanges();
            Console.WriteLine("Course Updated Successfully");
        }
    }

    public static void DeleteCourse()
    {
        using (var context = new CourseContext())
        {
            Console.Write("Enter Course Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Course Id!");
                return;
            }

            var course = context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
                Console.WriteLine("Course deleted successfully.");
            }
            else
            {
                Console.WriteLine("Course with given id not found.");
            }
        }
    }

    public static void ViewAllCourses()
    {
        using (var context = new CourseContext())
        {
            var courses = context.Courses
                .Select(e => new
                {
                    e.CourseId,
                    e.CourseName,
                }).ToList();

            if (courses.Any())
            {
                Console.WriteLine("{0,-10} {1,-30}", "Course Id", "Course Name");
                Console.WriteLine(new string('-', 45));
                foreach (var c in courses)
                {
                    Console.WriteLine("{0,-10} {1,-30}", c.CourseId, c.CourseName);
                }
            }
            else
            {
                Console.WriteLine("No Records to Display");
            }
        }
    }
}
