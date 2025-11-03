var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//  In-memory list of blogs
var blogs = new List<Blog>
{
    new Blog { Id = 1, Title = "First Blog", Body = "This is the content of the first blog." },
    new Blog { Id = 2, Title = "Second Blog", Body = "This is the content of the second blog." }
};


// READ ROUTES 
// Root endpoint
app.MapGet("/", () => "Welcome to the MSFD_CrudApi Blog API! Available endpoints: GET /blogs, POST /blogs, PUT /blogs/{id}, DELETE /blogs/{id}");

// Endpoint to get all blogs
app.MapGet("/blogs", () => {
    return blogs;
});

// Endpoint to get a blog by ID
app.MapGet("/blogs/{id}", (int id) =>
{
    var blog = blogs.FirstOrDefault(b => b.Id == id);

    if (blog == null)
    {
        return Results.NotFound("Blog not found");
    }
    else
    {
        return Results.Ok(blog);
    }
});


// CREATE ROUTES
// Endpoint to create a new blog with ID assignment
app.MapPost("/blogs", (Blog newBlog) =>
{
    newBlog.Id = blogs.Count > 0 ? blogs.Max(b => b.Id) + 1 : 1; // Assign a new ID
    blogs.Add(newBlog);

    return Results.Created($"/blogs/{newBlog.Id}", newBlog);
});



// DELETE ROUTES
// Option 1:  Endpoint to delete a blog by ID
app.MapDelete("/blogs/{id}", (int id) => {
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound("Blog not found");
    }
    else
    {
        var blog = blogs[id];
        blogs.RemoveAt(id);
        return Results.NoContent();
    }
});




// PUT ROUTES (UPDATE)
// Endpoint to update a blog by ID
app.MapPut("/blogs/{id}", (int id, Blog updatedBlog) =>
{
    var existingBlog = blogs.FirstOrDefault(b => b.Id == id);

    if (existingBlog == null)
    {
        return Results.NotFound("Blog not found");
    }
    else
    {
        // Update the existing blog's properties
        existingBlog.Title = updatedBlog.Title;
        existingBlog.Body = updatedBlog.Body;
        // Keep the original ID
        existingBlog.Id = id;
        
        return Results.Ok(existingBlog);
    }
});



// Run the application
app.Run();

// Blog model
public class Blog
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
}
