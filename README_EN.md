# Groupproject .NET MVC - 'GezondOpReis'
## Short explanation
This repository contains all the code for the group project "GezondOpReis" (Healthy Travel), which we developed for the "MVC Project" course.
With this README, I want to give you a clearer picture of how this project works and which features I worked on.

## What is this project?
This project is a web application built using the .NET framework, following ASP.NET, Entity Framework, and the MVC principle.
For this project, we each worked on one or sometimes even multiple branches per week.
We used a feature-branch workflow, with each branch containing a specific (core) functionality that ensures the proper functioning of the web application.

Simply put, it's a platform where you can book trips. You can participate in these trips in various ways.
Each of these trips also includes activities, which themselves comprise a program.
You can participate as a regular traveler, but also as a parent, monitor, or (main) responsible person.
Participants also have the option of taking certain training courses.

Each of these roles has a specific responsibility. A user of this website can sign up as a monitor when registering.
If you want to register your child for a trip, you can do so as a parent. Expenses incurred during the trip are uploaded to the system by the person responsible.
A medical record is also stored for each user, which they can complete or edit themselves.
This allows those people who are responsible to bring any necessary medications or remedies on the trip.
Finally, you can also leave a review for each trip, which will then be displayed for that trip.

Each page is built using Razor pages and associated controllers.
All data was managed in a SQL Server database and accessed via Entity Framework Core.

## Why did we make this project?
As mentioned before, this was a mandatory group assignment we had to develop to test our knowledge of the MVC principle and Entity Framework.

## When did we start this project?
We started this project on 13 November 2024, and worked on it until 20 December, 2024, a few days before the deadline.
If I remember correctly, it was 22 December, 2024, but it could have been 20 December itself.

## How did we work during this project?
We worked on this project using the Agile/Scrum methodology.
We had to course three times a week: Monday, Wednesday, and Friday.

### Monday
On Mondays, we always met first to discuss what needed to be done that week and who would do it.
We clearly divided these tasks via GitHub Issues, assigning each functionality to one of our names.
All this information was always recorded in a SPRINT plan, with each group member taking turns as SCRUM master and taking notes.
These notes also had to be uploaded to our learning/student platform at the end of each week.

### Wednesday
On Wednesdays, we always started by reviewing what each of us had already accomplished and what still needed to be done that week.
We also noted what went well/smoothly and what didn't. Afterward, we could continue working on the features we started on Monday.

### Friday
Then, on Fridays, we had to merge all our work from the past week into the `main` branch.
Afterward, we could present our work as a group to our lecturer via a Teams call, who also reviewed it each time.
The SCRUM master also wrote down the feedback our lecturer provided in the SPRINT plan, after which it could be uploaded to the learning/student platform.

We continued using this methodology until the end of the project, where, after receiving feedback, we had to indicate what we liked about the project, what went well, and what could be improved.
Finally, after submitting the project, we had to complete an evaluation in which we rated ourselves or each other, each time by giving a score out of 5.

## Used technologies
#### Backend
- .NET
- ASP.NET Core
- Entity Framework
- C#
- MVC
- SQL

#### Frontend
- Razor pages

#### Tools and methodologies
- Agile/Scrum
- GitHub Issues
- Git (feature-branch workflow)


## Functionalities
I've already mentioned that this project is quite extensive. For that reason, I'll only explain the features I worked on in the [`functionalities.md`](functionalities.md) file.