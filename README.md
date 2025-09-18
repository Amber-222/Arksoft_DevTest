# ArkSoft Customer Management Web Application

## 📝 Overview

This is a web-based application developed using **ASP.NET MVC in C#** for tracking customer information. The solution is designed to be robust, user-friendly, and maintainable, leveraging **Entity Framework Core** and **LINQ** for data persistence. All customer data is stored in an **Azure SQL Server** database, with a provided script for database setup.

## ✨ Features

- **Customer Data Management:**  
  Capture and manage the following customer details:
  - Name (Required)
  - Address (Required)
  - Telephone Number
  - Contact Person Name
  - Contact Person Email Address (Validated if supplied)
  - VAT Number

- **Validation:**  
  - Name and Address are mandatory fields.
  - If a contact email is provided, it must be a valid email address format.
  - All validation is performed with clear feedback for users.

- **Customer List Page:**  
  - Displays all customer information in a tabular format.
  - Supports sorting by Full Name and VAT Number (ascending/descending).
  - Paging is implemented, showing 10 entries per page.
  - Filtering options for searching by Name.
  - Ability to delete customers, with a confirmation prompt before deletion.

- **Customer Management Page:**  
  - Add new customers with full validation.
  - Edit existing customer details.
  - User-friendly forms with error feedback for invalid or missing data.

- **Database Integration:**  
  - Uses Entity Framework Core and LINQ for queries.
  - All data is persisted in a SQL Server database.
  - Includes a SQL script ([SQL_DB_Script.sql](SQL_DB_Script.sql)) to create the database and required table.

## 🛠 Technologies Used

- ASP.NET MVC (C#)
- Entity Framework Core
- LINQ
- SQL Server
- Bootstrap 5 (for responsive UI)
- X.PagedList (for paging)

## 🚀 Getting Started

1. **Database Setup:**  
   Run the provided [SQL_DB_Script.sql](SQL_DB_Script.sql) to create the database and the `Customer` table.

2. **Build & Run:**  
   Open the solution [`ArkSoft_MVC/ArkSoft_MVC.sln`](ArkSoft_MVC/ArkSoft_MVC.sln) in Visual Studio and run the project.

## 📁 Project Structure

- **Controllers:** Business logic and routing ([ArkSoft_MVC/ArkSoft_MVC/Controllers](ArkSoft_MVC/ArkSoft_MVC/Controllers))
- **Models:** Data models ([ArkSoft_MVC/ArkSoft_MVC/Models](ArkSoft_MVC/ArkSoft_MVC/Models))
- **Views:** Razor pages for UI ([ArkSoft_MVC/ArkSoft_MVC/Views](ArkSoft_MVC/ArkSoft_MVC/Views))
- **Database:** Entity Framework context ([ArkSoft_MVC/ArkSoft_MVC/Database/dbContext.cs](ArkSoft_MVC/ArkSoft_MVC/Database/dbContext.cs))
- **Migrations:** EF Core migrations ([ArkSoft_MVC/ArkSoft_MVC/Migrations](ArkSoft_MVC/ArkSoft_MVC/Migrations))

## 🗄️ SQL Script

The database creation script is provided in [SQL_DB_Script.sql](SQL_DB_Script.sql).  
It creates the `ArkSoft_DevTest` database and the `Customer` table with all required fields.

## 📚 How to Use

- **View Customers:**  
  Navigate to the Customer List page to view, sort, filter, and delete customers.

- **Add/Edit Customers:**  
  Use the management page to add new customers or update existing records. All required fields and validation rules are enforced.
