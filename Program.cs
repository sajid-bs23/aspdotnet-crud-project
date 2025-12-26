using Microsoft.EntityFrameworkCore;
using AspDotNetCrudProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure SQLite
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=books.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Ensure database directory exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BookContext>();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=books.db";
    
    if (connectionString.Contains("Data Source="))
    {
        var dataSource = connectionString.Split("Data Source=")[1].Split(";")[0];
        var directory = Path.GetDirectoryName(dataSource);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }
    
    context.Database.EnsureCreated();
}

app.Run();

public partial class Program { }
