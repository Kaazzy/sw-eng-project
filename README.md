# Finance Tracker Application

A personal finance management web application built with ASP.NET Core 8.0 and Entity Framework Core. This application allows users to track their expenses by recording descriptions, amounts, dates, and categories for better financial management.

## Project Overview

This is an MVC (Model-View-Controller) web application that provides:
- **Expense Tracking**: Record and manage personal expenses
- **Database Integration**: Uses SQL Server with Entity Framework Core for data persistence
- **Modern Web Framework**: Built on ASP.NET Core 8.0 with C# and Razor views

### Technology Stack

- **Backend**: ASP.NET Core 8.0 (MVC)
- **ORM**: Entity Framework Core 9.0.10
- **Database**: SQL Server (LocalDB or SQL Server Express)
- **Frontend**: Razor Views with Bootstrap
- **Language**: C# (.NET 8.0)

## Prerequisites

Before you begin, ensure you have the following installed on your system:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server LocalDB
- A code editor (recommended: [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/))
- Git (for cloning the repository)

## Installation

Follow these steps to set up the project on your local machine:

### 1. Clone the Repository

```bash
git clone https://github.com/Kaazzy/sw-eng-project.git
cd sw-eng-project
```

### 2. Navigate to the Project Directory

```bash
cd sw_project
```

### 3. Configure Database Connection

Update the connection string in `sw_project/appsettings.json` to match your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FinanceAppDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Note**: Modify the `Server` value based on your SQL Server installation:
- For SQL Server Express: `localhost\\SQLEXPRESS`
- For LocalDB: `(localdb)\\mssqllocaldb`
- For a named instance: `localhost\\YOUR_INSTANCE_NAME`

**Security Note**: The `TrustServerCertificate=True` setting is included for development purposes. In production environments, ensure proper SSL certificate validation is configured.

### 4. Restore Dependencies

```bash
dotnet restore
```

### 5. Apply Database Migrations

Create and update the database schema:

```bash
dotnet ef database update
```

If the `dotnet ef` command is not recognized, install the Entity Framework Core tools:

```bash
dotnet tool install --global dotnet-ef
```

### 6. Build the Project

```bash
dotnet build
```

## Running the Application

### Using the .NET CLI

From the `sw_project` directory, run:

```bash
dotnet run
```

The application will start and be accessible at:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

### Using Visual Studio

1. Open the solution file `sw_project.sln` in Visual Studio
2. Press `F5` or click the "Run" button to start the application with debugging
3. The application will launch in your default web browser

## Project Structure

```
sw-eng-project/
├── sw_project/
│   ├── sw_project/
│   │   ├── Controllers/      # MVC Controllers
│   │   ├── Models/           # Data models (Expense, etc.)
│   │   ├── Views/            # Razor view templates
│   │   ├── Data/             # Database context
│   │   ├── Migrations/       # EF Core migrations
│   │   ├── wwwroot/          # Static files (CSS, JS, images)
│   │   ├── Program.cs        # Application entry point
│   │   └── appsettings.json  # Configuration settings
│   └── sw_project.sln        # Solution file
└── README.md
```

## Features

- Create, read, update, and delete expense records
- Track expense descriptions, amounts, dates, and categories
- Data persistence with SQL Server database
- Responsive web interface

## Troubleshooting

### Database Connection Issues

If you encounter database connection errors:
1. Verify SQL Server is running
2. Check the connection string in `appsettings.json`
3. Ensure you have the necessary permissions to create databases

### Migration Issues

If migrations fail:
```bash
# Remove existing migrations
dotnet ef migrations remove

# Create a new migration
dotnet ef migrations add InitialCreate

# Update the database
dotnet ef database update
```

## Contributing

This is a software engineering course project. If you'd like to contribute:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

## License

This project is created for educational purposes as part of a software engineering course.