![ToDoEU Homepage](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/login_page.png)

# Introduction
## The ToDoEU App
### What is ToDoEU

ToDoEU is a simple ToDo make application that allows users to make a lists of goals and tasks they plan to carry out or achieve sometime in the future. ToDoEU eliminates distrations and adpots a striaght-to-the-point approach to it's operations.
This is an App developed  

### Context
This app is developed by [Oguntola Joshua](https://github.com/extranodev) as a shortlisted applicant and as part of requirements to be considered for an Interview for a position of System Developer.

## Author
Oguntola Joshua: [Github](https://github.com/ExtranoDev)/[Twitter](https://twitter.com/extranodev)/[LinkedIn](https://www.linkedin.com/in/oguntolajoshua/)

#### Registration page

![ToDoEU Register page](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/register_page.png)

#### Login page
![ToDoEU Login page](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/login_page.png)

#### ToDo List page [Dashboard]

![ToDoEU List page](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/user_dashboard.png)

#### ToDo Create page 

![ToDoEU Create page](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/create_todo_act.png)

#### ToDo Edit page 

![ToDoEU Edit page](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/edit_todo_act.png)

#### ToDo Delete page 

![ToDoEU Delete page](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/delete_todo_act.png)

#### ToDo Admin page 

![ToDoEU Admin page](https://github.com/ExtranoDev/TO_DO_EU/blob/main/img/admin_dashboard.png)

## API Documentation
### How to use
* Clone Repo [ToDoEU App](https://github.com/ExtranoDev/TO_DO_EU)
* Open solution in download file with visual studio
* Configure server settings in the appsettings.json file
* Connect server
* Uncomment the last section of code in the UserAuthenticationController.cs [For Admin Registration, feel free to edit]
* Open the package manager console in VSCode
* Run add-migration -context DatabaseContext
* Run update-database
* Run add-migration -context ToDoDbContext
* Run update-database
* Build the Run the file
* In the browser run https://Default:default/UserAuthentication/reg [To Register Admin details in database]


### Technologies Used
* .NET 6 MVC (Model-Views-Controller), ASP.NET core
* MSSQL Server
* C#, HTML, Bootstarp, CSS, HTML
