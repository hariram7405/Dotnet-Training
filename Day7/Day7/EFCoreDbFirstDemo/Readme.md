
# EFCoreDbFirstDemo

A simple .NET Core Console Application demonstrating **Entity Framework Core (EF Core) Database-First** approach. This app allows you to manage employee and department data using a SQL Server database through a text-based interface.

---

## 📌 Features

- Add new **Departments**
- Add **Employees** and associate them with existing Departments
- View all Employees with their Department information
- Menu-driven **console interface**

---

## 🧰 Technologies Used

- [.NET Core](https://dotnet.microsoft.com/)
- C#
- Entity Framework Core
- SQL Server

---




## 🚀 Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/EFCoreDbFirstDemo.git
cd EFCoreDbFirstDemo
```

### 2. Scaffold the Models (if not present)

Use EF Core's database-first approach to scaffold the models:

```bash
dotnet ef dbcontext scaffold "Your_Connection_String" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

> Replace `"Your_Connection_String"` with your actual SQL Server connection string.

### 3. Run the App

```bash
dotnet run
```

---

## 🧪 Sample Console Output

### ➕ Adding Departments

```
---------Menu----------
1.Add Employee
2.Add Department
3.Display Employee
4.Exit
Enter your choice
2
Enter Number of Departments to insert
2
Enter Department Name
HR
Enter Department Name
IT
Department Added Successfully
```

---

### ➕ Adding Employees

```
---------Menu----------
1.Add Employee
2.Add Department
3.Display Employee
4.Exit
Enter your choice
1
Enter Number of Employees to insert
2
Enter Employee Name
Alice
Enter Age
30
Enter Department Name:
HR
Enter Employee Name
Bob
Enter Age
28
Enter Department Name:
IT
Employees Added Successfully
```

---

### 📋 Displaying Employees

```
---------Menu----------
1.Add Employee
2.Add Department
3.Display Employee
4.Exit
Enter your choice
3
Employee id        Employee Name                 Department                    
--------------------------------------------------------------------------------
1                   Alice                         HR                              
2                   Bob                           IT                              
```

---

### ❌ Trying to Add Employee to Non-Existent Department

```
Enter Employee Name
Charlie
Enter Age
25
Enter Department Name:
Finance
Department not found. Add the Department first
```

---

## 📎 Notes

* **Employees must be added to existing departments**.
* The application uses `DbContext` and EF Core's `.Include()` to fetch related data.
* Run in a loop until "Exit" is selected.

---

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

---

## 👤 Author

* Hari Ram L

```


