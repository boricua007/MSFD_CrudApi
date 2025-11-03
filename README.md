# MSFD CRUD API

ASP.NET Core 9.0 Minimal API demonstrating complete CRUD operations, REST principles, and modern web API development patterns for the Microsoft Full Stack Developer certification.

## Quick Start

```bash
dotnet watch run
# Navigate to http://localhost:5224
# Test endpoints using requests.http file
```

## Features

✅ **Complete CRUD Operations** - Create, Read, Update, Delete  
✅ **RESTful API Design** - Following REST conventions  
✅ **In-Memory Data Storage** - Quick development & testing  
✅ **Auto ID Assignment** - Smart ID generation for new records  
✅ **Input Validation** - Required properties with C# 9.0 features  
✅ **Error Handling** - Proper HTTP status codes  
✅ **Hot Reload Development** - Fast development cycle  
✅ **Comprehensive Test Coverage** - HTTP request files included  

**Tech Stack:** ASP.NET Core 9.0 • C# • Minimal APIs • Hot Reload

## API Routes

| Method | Endpoint | Example | Description |
|--------|----------|---------|-------------|
| GET | `/` | `/` | Welcome message & available endpoints |
| GET | `/blogs` | `/blogs` | Get all blog posts |
| GET | `/blogs/{id}` | `/blogs/1` | Get specific blog by ID |
| POST | `/blogs` | `/blogs` | Create new blog post |
| PUT | `/blogs/{id}` | `/blogs/1` | Update existing blog post |
| DELETE | `/blogs/{id}` | `/blogs/1` | Delete blog post by ID |

## Request/Response Examples

### Create Blog Post
```http
POST /blogs
Content-Type: application/json

{
  "title": "My First Blog",
  "body": "This is the content of my blog post."
}
```

**Response:** `201 Created`
```json
{
  "id": 3,
  "title": "My First Blog", 
  "body": "This is the content of my blog post."
}
```

### Update Blog Post
```http
PUT /blogs/1
Content-Type: application/json

{
  "title": "Updated Blog Title",
  "body": "Updated blog content."
}
```

**Response:** `200 OK`
```json
{
  "id": 1,
  "title": "Updated Blog Title",
  "body": "Updated blog content."
}
```

### Error Responses
- `404 Not Found` - Blog with specified ID doesn't exist
- `400 Bad Request` - Invalid request format or missing required fields

## Data Model

```csharp
public class Blog
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
}
```

## Code Structure Demonstrated

```csharp
// CRUD Operations with proper HTTP status codes
app.MapGet("/blogs", () => blogs);
app.MapGet("/blogs/{id}", (int id) => { /* Get by ID logic */ });
app.MapPost("/blogs", (Blog blog) => { /* Create logic */ });
app.MapPut("/blogs/{id}", (int id, Blog blog) => { /* Update logic */ });
app.MapDelete("/blogs/{id}", (int id) => { /* Delete logic */ });
```

## Learning Objectives

- **CRUD Fundamentals:** Complete Create, Read, Update, Delete operations
- **REST Principles:** Proper HTTP methods, status codes, and resource naming
- **Modern APIs:** Minimal API architecture, dependency injection, model binding
- **Data Management:** In-memory collections, LINQ queries, ID management
- **MSFD Certification:** Demonstrates ASP.NET Core competencies for Microsoft Full Stack Developer track

## Project Structure

```
MSFD_CrudApi/
├── Program.cs                 # Main application & API endpoints
├── MSFD_CrudApi.csproj       # Project configuration
├── MSFD_CrudApi.sln          # Solution file
├── requests.http             # HTTP test requests
├── MSFD_CrudApi.http         # Additional HTTP tests
├── appsettings.json          # Application configuration
├── Properties/
│   └── launchSettings.json   # Development settings
└── README.md                 # This file
```

## Development Workflow

1. **Start Development Server:**
   ```bash
   dotnet watch run
   ```

2. **Test API Endpoints:**
   - Use the included `requests.http` file with VS Code REST Client extension
   - Navigate to `http://localhost:5224` in your browser
   - Use tools like Postman or curl for testing

3. **Available Test Scenarios:**
   - Get all blogs (initially 2 sample posts)
   - Create new blog posts with auto-assigned IDs  
   - Update existing blog posts
   - Delete blog posts
   - Handle non-existent resource errors

## Sample Data

The API starts with sample blog posts:

```csharp
var blogs = new List<Blog>
{
    new Blog { Id = 1, Title = "First Blog", Body = "This is the content of the first blog." },
    new Blog { Id = 2, Title = "Second Blog", Body = "This is the content of the second blog." }
};
```

## Getting Started

1. **Clone or download the project**
2. **Navigate to project directory:**
   ```bash
   cd MSFD_CrudApi
   ```
3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
4. **Run the application:**
   ```bash
   dotnet run
   ```
5. **Test the API:**
   - Open `requests.http` in VS Code
   - Click "Send Request" above each HTTP request
   - Or navigate to `http://localhost:5224` in your browser

## About

.NET ASP.NET Core C# Application built for the Microsoft Back-End Development with .NET course as part of the Full-Stack Certification track. This app demonstrates complete CRUD API development using ASP.NET Core Minimal APIs.

This project is part of the Microsoft Full Stack Developer certification track, showcasing modern REST API development patterns, CRUD operations, and ASP.NET Core best practices.

### Key Concepts Covered
- RESTful API design principles
- HTTP methods and status codes
- Model binding and validation
- In-memory data management
- Error handling and response formatting
- Modern C# features (required properties, minimal APIs)

---

**Built with ASP.NET Core 9.0 for the Microsoft Full Stack Developer Certification Program**