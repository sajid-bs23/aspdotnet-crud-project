# ASP.NET Core CRUD Project

A simple RESTful CRUD (Create, Read, Update, Delete) application built with C#, ASP.NET Core, and Entity Framework Core. This project provides a complete Book management API with comprehensive test coverage and Docker support.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Quick Start with Docker](#quick-start-with-docker)
  - [Local Development Setup](#local-development-setup)
- [API Endpoints](#api-endpoints)
- [Running Tests](#running-tests)
- [Code Coverage](#code-coverage)
- [Build and Run](#build-and-run)
- [Configuration](#configuration)
- [Technologies Used](#technologies-used)
- [Example API Usage](#example-api-usage)
- [Validation Rules](#validation-rules)
- [Error Handling](#error-handling)
- [License](#license)
- [Contributing](#contributing)
- [Support](#support)

## Features

- ✅ Full CRUD operations for Book management
- ✅ RESTful API with JSON responses
- ✅ Input validation and error handling
- ✅ Comprehensive unit and integration tests (xUnit)
- ✅ Code coverage reporting (dotnet-coverage and dotCover)
- ✅ Docker and Docker Compose support
- ✅ SQLite database with EF Core (No external DB required)
- ✅ Automatic database schema creation on startup
- ✅ Swagger UI for API documentation and testing

## Prerequisites

Before you begin, ensure you have the following installed:

### For Docker Setup
- **Docker** 20.10+ or higher
- **Docker Compose** 2.0+ or higher

### For Local Development
- **.NET 8.0 SDK** or higher
- **Make** (optional, for using Makefile commands)

Verify your installation:

```bash
# Docker
docker --version
docker-compose --version

# .NET
dotnet --version
```

## Project Structure

```
aspdotnet-crud-project/
├── AspDotNetCrudProject.sln      # Solution file
├── AspDotNetCrudProject.csproj   # Project file
├── Controllers/
│   └── BooksController.cs         # API Controllers (CRUD operations)
├── Data/
│   └── BookContext.cs             # EF Core database context
├── Models/
│   └── Book.cs                    # Book model with Data Annotations
├── Tests/
│   ├── AspDotNetCrudProject.Tests.csproj # Test project file
│   └── BookTests.cs               # xUnit integration tests
├── Program.cs                     # Application startup and configuration
├── appsettings.json               # Application settings
├── .gitignore                     # Git ignore rules
├── .dockerignore                  # Docker ignore rules
├── Dockerfile                     # Docker image definition
├── docker-compose.yml             # Docker Compose configuration
├── Makefile                       # Build automation
└── README.md                      # This file
```

## Getting Started

### Quick Start with Docker

The easiest way to get started is using Docker Compose:

#### 1. Build and Run

```bash
docker-compose up --build
```

This will:
- Build the Docker image
- Start the application container
- Apply migrations and create the database
- Expose the API at `http://localhost:5000`

#### 2. Access the API

The application will be available at: `http://localhost:5000/api/books`
The Swagger UI documentation: `http://localhost:5000/swagger/index.html`

### Local Development Setup

#### 1. Clone the Repository

```bash
git clone <repository-url>
cd aspdotnet-crud-project
```

#### 2. Build the Solution

Using Makefile:
```bash
make build
```

Or using dotnet CLI:
```bash
dotnet build
```

#### 3. Run the Application

Using Makefile:
```bash
make run
```

Or using dotnet CLI:
```bash
dotnet run
```

The application will start on `http://localhost:5000` (or the port configured in your environment).

## API Endpoints

All endpoints are prefixed with `/api/books`

### List All Books

**GET** `/api/books`

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "title": "The Great Gatsby",
    "author": "F. Scott Fitzgerald",
    "isbn": "9780743273565",
    "published_date": "1925-04-10T00:00:00",
    "pages": 180
  }
]
```

### Get Book by ID

**GET** `/api/books/{id}`

**Response (200 OK):**
```json
{
  "id": 1,
  "title": "The Great Gatsby",
  "author": "F. Scott Fitzgerald",
  "isbn": "9780743273565",
  "published_date": "1925-04-10T00:00:00",
  "pages": 180
}
```

**Response (404 Not Found):**
```json
{
  "error": "Book not found"
}
```

### Create a Book

**POST** `/api/books`

**Request Body:**
```json
{
  "title": "1984",
  "author": "George Orwell",
  "isbn": "9780451524935",
  "published_date": "1949-06-08",
  "pages": 328
}
```

**Response (201 Created):**
```json
{
  "id": 2,
  "title": "1984",
  "author": "George Orwell",
  "isbn": "9780451524935",
  "published_date": "1949-06-08T00:00:00",
  "pages": 328
}
```

### Update a Book

**PUT** `/api/books/{id}`

**Request Body:**
```json
{
  "id": 2,
  "title": "1984 (Updated)",
  "author": "George Orwell",
  "isbn": "9780451524935",
  "published_date": "1949-06-08",
  "pages": 350
}
```

**Response (200 OK):**
```json
{
  "id": 2,
  "title": "1984 (Updated)",
  "author": "George Orwell",
  "isbn": "9780451524935",
  "published_date": "1949-06-08T00:00:00",
  "pages": 350
}
```

### Delete a Book

**DELETE** `/api/books/{id}`

**Response (200 OK):**
```json
{
  "message": "Book deleted successfully"
}
```

## Running Tests

### Run All Tests

**Using Makefile:**
```bash
make test
```

**Using Dotnet CLI:**
```bash
dotnet test
```

## Code Coverage

We provide two separate tools for coverage reporting to support different workflows.

### Option 1: dotnet-coverage (SonarQube format)

Generates an XML report compatible with SonarQube.

```bash
make coverage
```
Report: `coverage.xml`

### Option 2: dotCover (HTML format)

Generates a detailed, human-readable HTML report.

```bash
make dotcover
```
Report: `dotCoverReport.html`

## Build and Run

### Available Makefile Commands

```bash
make help       # Show all available commands
make build      # Restore and build the entire solution
make run        # Run the Web API project
make test       # Run the test suite
make coverage   # Generate XML coverage report (dotnet-coverage)
make dotcover   # Generate HTML coverage report (dotCover)
make clean      # Remove build artifacts and temporary files
```

### Docker Commands

```bash
# Build and start in foreground
docker-compose up --build

# Start in background
docker-compose up -d

# Stop and remove containers
docker-compose down

# View logs
docker-compose logs -f
```

## Configuration

### App Settings

Configuration is located in `appsettings.json`:

- **ConnectionStrings**: Default SQLite connection string.
- **Logging**: Log level settings for the application.

### Database

The project uses a SQLite database (`books.db`) by default. The database is automatically created on startup if it doesn't exist.

To switch to SQL Server or PostgreSQL:
1. Install the appropriate EF Core provider.
2. Update the connection string in `appsettings.json`.
3. Update `Program.cs` to use the new provider (e.g., `UseSqlServer`).

## Technologies Used

- **.NET 8.0** - Core framework
- **ASP.NET Core Web API** - API framework
- **Entity Framework Core** - ORM
- **SQLite** - Database
- **xUnit** - Testing framework
- **Microsoft.AspNetCore.Mvc.Testing** - Integration testing
- **Swashbuckle (Swagger)** - API documentation
- **Docker** - Containerization
- **Makefile** - Build automation

## Example API Usage

### Using cURL

```bash
# Create a book
curl -X POST http://localhost:5000/api/books \
  -H "Content-Type: application/json" \
  -d '{
    "title": "The Catcher in the Rye",
    "author": "J.D. Salinger",
    "isbn": "9780316769488",
    "published_date": "1951-07-16",
    "pages": 234
  }'

# Get all books
curl http://localhost:5000/api/books
```

### Using C# HttpClient

```csharp
using var client = new HttpClient();
var book = new { Title = "Title", Author = "Author", ISBN = "123", PublishedDate = DateTime.Now, Pages = 100 };
var response = await client.PostAsJsonAsync("http://localhost:5000/api/books", book);
var result = await response.Content.ReadFromJsonAsync<dynamic>();
```

## Validation Rules

- **Title**: Required, maximum 200 characters.
- **Author**: Required, maximum 100 characters.
- **ISBN**: Required, maximum 13 characters, must be unique across all books.
- **PublishedDate**: Required, valid date.
- **Pages**: Required, must be a positive integer.

## Error Handling

- `200 OK`: Successful GET/PUT/DELETE.
- `201 Created`: Successful creation.
- `400 Bad Request`: Validation failure or business logic error (e.g., duplicate ISBN).
- `404 Not Found`: Resource does not exist.
- `500 Internal Server Error`: Unexpected server errors.

## License

This project is part of the BrainStation23 QMS samples.

## Contributing

1. Create a feature branch.
2. Implement changes.
3. Add/Update tests.
4. Ensure all tests pass.
5. Open a Pull Request.

## Support

For technical support or questions, please refer to the project maintainers.
