
# 📚 Book Rental System

## 📘 Overview

The **Book Rental System** is a console-based application developed using **C#** that models a basic library rental service. It allows users to manage fiction and non-fiction books with functionality such as renting, returning, displaying, and searching for books. The system demonstrates key **OOP concepts** like abstraction, inheritance, polymorphism, and encapsulation.

---

## 🎯 Key Features

* 📖 Add and manage books (Fiction and Non-Fiction)
* 📕 Rent and return books
* 🔍 Search books by title
* 📋 Display all available books
* 📝 Report current status (available / rented)
* ✅ Fully object-oriented design using interfaces and abstract classes

---

## 🧱 Class Overview

| Class / Interface | Type           | Description                                                                   |
| ----------------- | -------------- | ----------------------------------------------------------------------------- |
| `Book`            | Abstract Class | Base class containing shared book attributes and a virtual `Display()` method |
| `Fiction`         | Class          | Inherits from `Book`; includes additional `Genre` and implements `IRentable`  |
| `NonFiction`      | Class          | Inherits from `Book`; includes `Category` and implements `IRentable`          |
| `IRentable`       | Interface      | Declares `Rent()`, `Return()`, and `ReportStatus()` methods                   |
| `IServicable`     | Interface      | Declares library service actions like `RentBook()`, `ReturnBook()`, etc.      |
| `BookServices`    | Service Class  | Implements `IServicable`, manages the collection of books                     |
| `Program`         | Entry Point    | Main method that runs the application and ties all components together        |

---

## 🧠 Object-Oriented Concepts Used

| Concept           | How It's Applied                                                           |
| ----------------- | -------------------------------------------------------------------------- |
| **Abstraction**   | Interfaces (`IRentable`, `IServicable`) hide implementation details        |
| **Inheritance**   | `Fiction` and `NonFiction` extend from `Book` class                        |
| **Polymorphism**  | Overridden `Display()` methods, interface-based dynamic method dispatch    |
| **Encapsulation** | Book attributes are defined in classes and accessed through public members |

---

## 🧾 Example Console Output

```
-----------Fiction----------
Book Id :5001
Book Title: The Mystery Case
Book Author: Lokesh
Book Genre:Drama

-----------Non Fiction----------
Book Id :4001
Book Title: The Universe Explained
Book Author: Smith
Book category:Science

The Mystery Case has been Rented
The Universe Explained has been Rented

*************Report**************
Report Generated as on : 7/24/2025
Book Id :5001
Book Title: The Mystery Case
Book Author: Lokesh
Book Genre:Drama
Book Status:Not Available

*************Report**************
Report Generated as on : 7/24/2025
Book Id :4001
Book Title: The Universe Explained
Book Author: Smith
Book Category:Science
Book Status:Not Available

The Mystery Case has been Returned
The Universe Explained has been Returned

*************Report**************
Report Generated as on : 7/24/2025
Book Id :5001
Book Title: The Mystery Case
Book Author: Lokesh
Book Genre:Drama
Book Status:Available

*************Report**************
Report Generated as on : 7/24/2025
Book Id :4001
Book Title: The Universe Explained
Book Author: Smith
Book Category:Science
Book Status:Available

The Mystery Case Book is Available

Book 1
Book Id:5001
Book Title:The Mystery Case
Book Author:Lokesh

Book 2
Book Id:4001
Book Title:The Universe Explained
Book Author:Smith

Total Number of Book Available:2
```

---

## 👨‍💻 Author

* **Name**: Hariram
* **GitHub**: [@hariram7405](https://github.com/hariram7405)


