# BookCatalog_AspNET

## Description

BookCatalog_AspNET is a simple book catalog management application built with ASP.NET Core. This application allows users to perform CRUD (Create, Read, Update, Delete) operations on a book catalog, including adding new books, viewing book details, updating existing books, and deleting books. It incorporates input validation, structured logging, and robust error handling to ensure a reliable user experience. The project is designed with a layered architecture to promote maintainability and scalability.

## Technologies Used

- **ASP.NET Core 8.0**: Framework for building modern, cross-platform web applications.
- **C#**: Primary programming language for backend development.
- **SQLite**: Lightweight database for storing book data.
- **Serilog**: Logging library for detailed and structured logging of application events.
- **FluentValidation**: Library for validating user input to ensure data integrity.
- **AutoMapper**: Tool for mapping between domain entities and Data Transfer Objects (DTOs).
- **Bootstrap**: CSS framework for creating a responsive and user-friendly interface.
- **Entity Framework Core**: ORM for database operations with SQLite.

## Features

- **CRUD Operations**: Users can create, read, update, and delete books in the catalog.
- **Input Validation**: Ensures book data meets required criteria (e.g., non-empty title, valid page count) before saving.
- **Structured Logging**: Logs all CRUD operations and errors with Serilog, including request details like client IP and request URL.
- **Error Handling**: Global exception handling middleware catches and logs unhandled exceptions, displaying user-friendly error pages.
- **Layered Architecture**: Organized into Presentation, Application, Domain, and Infrastructure layers for modularity.

## How to Run the Project

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.
- Git installed for cloning the repository.
- A code editor like Visual Studio or Visual Studio Code.

### Steps

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/ersinisgor/BookCatalog_AspNET.git
   ```

2. **Navigate to the Project Directory**:

   ```bash
   cd BookCatalog_AspNET
   ```

3. **Restore NuGet Packages**:

   ```bash
   dotnet restore
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```
   - Open a web browser and navigate to `https://localhost:7271` (or the port specified in `launchSettings.json`).

### Configuration

- The application uses SQLite as its database, with the database file located at `./Infrastructure/Data/bookcatalog.db`.
- Logging is configured via `appsettings.json`, using Serilog to write logs to `Logs/logs-{Date}.txt`.

## What I Learned

Through developing this project, I gained valuable skills and insights, including:

- **ASP.NET Core MVC**: Learned to build a web application using the Model-View-Controller pattern.
- **Entity Framework Core**: Implemented database operations with SQLite, including migrations and CRUD functionality.
- **Dependency Injection**: Utilized ASP.NET Core’s built-in dependency injection to manage services and repositories.
- **Input Validation**: Applied FluentValidation to enforce data integrity and provide user-friendly error messages.
- **Structured Logging**: Configured Serilog to log application events and errors, including request details, in a structured format.
- **Error Handling**: Implemented global exception handling to improve application reliability and user experience.
- **Layered Architecture**: Structured the project into distinct layers (Presentation, Application, Domain, Infrastructure) to enhance maintainability.
- **AutoMapper**: Used AutoMapper to map between domain entities and DTOs, reducing boilerplate code.
- **Bootstrap**: Leveraged Bootstrap for responsive and visually appealing UI design.

This project deepened my understanding of modern web development practices, including how to structure a scalable application, handle errors gracefully, and implement logging for debugging and monitoring.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
