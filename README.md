# 📝 Abstract Notes

A simple web application for creating and managing personal notes.

The project is built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQLite**.

---

## ✨ Features

- 🔐 User registration
- 🔑 User authentication with Cookie Authentication
- 👤 Display of the authenticated user's name
- 📝 Create notes
- ✏️ Edit notes
- 🗑️ Delete notes
- 📌 Pin notes
- 👥 Separate notes for each user
- 💾 SQLite database
- 🎨 Modern dark UI
- 📱 Responsive design

---

## 🛠️ Technologies

### Backend

- **C#**
- **ASP.NET Core MVC**
- **.NET 10**
- **Entity Framework Core**
- **SQLite**
- **Dependency Injection**
- **Cookie Authentication**

### Frontend

- **HTML5**
- **CSS3**
- **Razor Views**
- **ASP.NET Core Tag Helpers**

---

## 📂 Project Structure

```text
Notes_API/
│
├── Controllers/
│   ├── AuthController.cs
│   └── NotesController.cs
│
├── Database/
│   └── AppDbContext.cs
│
├── Entities/
│   ├── User.cs
│   └── Note.cs
│
├── Interfaces/
│   ├── IUserService.cs
│   └── INoteService.cs
│
├── Models/
│   ├── Login/
│   │   └── LoginViewModel.cs
│   │
│   ├── Register/
│   │   └── RegisterViewModel.cs
│   │
│   ├── Request/
│   │   ├── CreateRequestModel.cs
│   │   └── EditRequestModel.cs
│   │
│   └── NoteViewModel.cs
│
├── Services/
│   ├── UserService.cs
│   └── NoteService.cs
│
├── Views/
│   ├── Auth/
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   │
│   └── Notes/
│       ├── List.cshtml
│       └── Edit.cshtml
│
├── wwwroot/
│   └── css/
│       └── styles.css
│
├── Program.cs
├── appsettings.json
├── notes.db
└── Notes_API.csproj
