# DotNet (ASP.NET Core MVC Web Application)

## Project Overview

DotNet is a web-based application developed using ASP.NET Core. This project aims to create a robust system for managing categories and items, with role-based access control, bulk upload capabilities, and a user-friendly interface. The application was built following industry best practices, including SOLID principles and design patterns.

## Features

### User and Role Management
- **Login and Logout**: Secure authentication and session management.
- **Role-Based Access**: Two types of roles - Admin and General User.
  - **Admin**: Full access to both Category and Item databases.
  - **General User**: Access only to the Item database.

### Category and Item Management
- **CRUD Operations**: Create, Read, Update, and Delete functionality for both Category and Item tables.
- **Bulk Upload**: Upload multiple categories and items using Excel files.
- **Image Upload**: Multiple image handling for items.

### Data Validation
- **Duplicate Entry Checking**: Prevents duplicate data entries during bulk upload.
- **Data Validation**: Ensures integrity and consistency of the data.

## Technical Specifications

### Frontend
- **HTML5**
- **CSS3**
- **Bootstrap 5**
- **JavaScript (ES9)**
- **jQuery (v3)**
- **jQuery Datatable**: Server-side pagination, sorting, and column filtering.

### Backend
- **ASP.NET Core (.NET 7)**
- **Entity Framework Core (v7.0.18)**
- **SQL Server (v19)**
- **In-Memory Caching**: For faster data fetching.
- **ASP.NET Core Identity**: For authentication and authorization.

### Frontend to Backend Communication
- **jQuery AJAX**
- **ASP.NET Core MVC Routing (GET/POST)**

### Development Tools
- **Visual Studio 2022**
- **SQL Server Management Studio 2019**
- **GIT UI**

## Installation and Setup

### Prerequisites
- Visual Studio 2022
- SQL Server 2019 or later
- .NET 7 SDK
- Node.js (for front-end dependencies)
### NuGet Packages Version
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore Version="7.0.18"** 
- **Microsoft.AspNetCore.Identity.UI Version="7.0.18"**
- **Microsoft.EntityFrameworkCore.Sqlite Version="7.0.18"**
- **Microsoft.EntityFrameworkCore.SqlServer Version="7.0.18"**
- **Microsoft.EntityFrameworkCore.Tools Version="7.0.18"**
- **ExcelDataReader Version="3.6.0" **
## Usage

### Roles and Access

#### Admin
- Full control over Categories and Items.
- Can create new roles.

#### General User
- Limited to managing Items only.

### Bulk Upload
- Navigate to the respective bulk upload section.
- Select the Excel file and upload.
- Ensure the file format matches the required template to avoid errors.

### Image Upload
- Multiple images can be uploaded for each item.
- Images are stored in the `wwwroot` directory.

## Contributing

### Guidelines
1. Fork the repository.
2. Create a new branch (`feature-xyz`).
3. Make your changes.
4. Submit a pull request.

### Reporting Issues
- Use the GitHub issues page to report bugs or request new features.


## Acknowledgments
- **University:** Ahsanullah University of Science and Technology

For more detailed documentation, refer to the project report provided in the repository.

Feel free to reach out with any questions or feedback!

## Maintainer
**Asif Iftekher Fahim**

Email: [fahimthescientist@gmail.com](mailto:fahimthescientist@gmail.com)


