# Group Project .NET MVC - GezondOpReis
.NET • ASP.NET Core • Entity Framework • MVC • SQL Server • Razor Pages

## 📌 About the project
This repository contains the source code of the group project **GezondOpReis**, developed for the *MVC Project* course.

GezondOpReis is a web application that allows users to book, manage, and track trips within various roles such as traveler, parent, monitor, and supervisor.

In this README, I explain the architecture, technologies used, development approach, and my contribution to the project.

---

## 🎯 Goal of the project
The goal of this project was to put our knowledge of:

- the MVC principle
- ASP.NET Core
- Entity Framework Core
- relational databases
- and Agile/Scrum teamwork

into practice within a larger group application.

---

## 🧠 What is 'GezondOpReis'?
GezondOpReis is a platform where users can book and manage trips.

Within the platform, there are various user roles:
- traveler
- parent
- monitor
- supervisor
- head supervisor

Each role has specific functionalities and responsibilities.

### Examples of functionalities
- View trips and activities
- Register children for trips
- Follow training courses
- Leave reviews per trip
- Manage medical information
- Upload expenses during trips
- Manage activities and programs

The application was built according to the MVC principle using ASP.NET Core and Entity Framework Core.

All data was managed in a SQL Server database.

---

## 🚧 Architecture
The application is built according to the MVC pattern:

- **Models**: manage the data and database relationships
- **Views**: built using Razor Pages
- **Controllers**: handle logic and user actions

Entity Framework Core was used as the ORM layer for communication with the SQL Server database.

Additionally, a feature-branch workflow was used, where each feature was developed separately and later merged into the main branch.

---

## 🔄️ Workflow
During the project, we worked according to the Agile/Scrum methodology.

We held several meetings per week during which:
- new functionalities were discussed
- tasks were distributed via GitHub Issues
- sprint plans were created
- feedback sessions took place with the lecturer

Every week, features were developed within separate branches and later merged into the main branch.

In addition, we regularly presented our progress via Teams meetings.

---

## 👨🏻‍💻 My contribution
This project was developed in a group. Because the application is quite extensive, I documented my personal contributions and implemented features separately in
[`functionalities.md`](functionalities.md)

---

## 🕒 Development timeframe
This project was developed between:
- **13 November 2024**
- **20 December 2024**

---

## 🛠️ Technologies
#### Backend
- .NET
- ASP.NET Core
- Entity Framework
- C#
- MVC
- SQL Server

#### Frontend
- Razor Pages
- HTML
- CSS
- JavaScript

#### Tools and methodologies
- GitHub Issues
- Git & GitHub
- Feature-branch workflow
- Agile/Scrum

---

## ⚙ Installation & setup

```bash
# Clone the repository
git clone https://github.com/MilanVW-Personal/GezondOpReis_.NET-MVC-groupproject.git

cd GezondOpReis_.NET-MVC-groupproject/GezondOpReisMVC

# Restore dependencies and run the project
dotnet restore
dotnet build
dotnet run
```

### Requirements
- .NET SDK
- SQL Server
- Visual Studio / Rider / VS Code

---

## 🌐 Languages
- English (current)
- Dutch: [`README_NL.md`](README_NL.md)