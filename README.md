# BlazorItemsManagerWebApp

Welcome to the BlazorItemsManagerWebApp repository!
This project is a Blazor application that utilizes Dapper as the ORM (Object-Relational Mapper) and DevExpress controls for the views.

## Table of Contents
- [BlazorItemsManagerWebApp](#blazoritemsmanagerwebapp)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Usage](#usage)
  - [Screenshots](#screenshots)
    - [Home Page](#home-page)
    - [Active Items Grid](#active-items-grid)
    - [Active Items Editor](#active-items-editor)
    - [Deleted Items Grid And Editor](#deleted-items-grid-and-editor)
    - [Create Item Page](#create-item-page)
    - [Edit Item Page](#edit-item-page)
  - [License](#license)

## Introduction

This Blazor application is designed to demonstrate how we can write Web Applications with Blazor, use Dapper for data access and DevExpress controls for a rich user interface.
The application serves as a template for building scalable and maintainable web applications.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any other compatible IDE
- SQL Server
- SQL Server Management Studio

## Installation

1. **Clone the Repository**

    Clone this repository
    https://github.com/kvinceto/BlazorItemsManagerWebApp.git

2. **Update Database Connection String**

    Update the connection string in `appsettings.json` to point to your database.

3. **Create the database**

    Go to SQL Server Management Studio and create the database
    Use this Query: [.SQL Query](/SQLQuery.sql)

4. **Run the Application**

    Build the Application

## Usage

Once the application is running, navigate to the app in your browser. You will see the home page with side navigation bar.

- **Home**: Displays a welcome message.
- **Active Items**: Shows all active items in the database, fetched using Dapper, in a table using DevExpress Grid component that provides filtering, grouping and sorting of the items. Also a component that provides Create, Edit and Delete functionality.
- **Deleted Items**: Shows all deleted items in the database, fetched using Dapper, in a table using DevExpress Grid component that provides filtering and sorting of the items. Also a component that provides functionality for restoring a deleted item.

## Screenshots

Here are some screenshots of the application:

### Home Page
![Home Page](/sampleImages/home-page.jpg)

### Active Items Grid
![Active Items Grid](/sampleImages/items-grid.jpg)

### Active Items Editor
![Active Items Editor](/sampleImages/items-editor-panel.jpg)

### Deleted Items Grid And Editor
![Deleted Items Grid And Editor](/sampleImages/deleted-items-grig-and-editor.jpg)

### Create Item Page
![Create Item Page](/sampleImages/create-item.jpg)

### Edit Item Page
![dit Item Page](/sampleImages/edit-item.jpg)


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


