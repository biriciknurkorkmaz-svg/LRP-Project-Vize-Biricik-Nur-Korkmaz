using LRPProject.Data;
using LRPProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=lrp.db"));

var app = builder.Build();

app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();


    context.Database.EnsureCreated();

    
    if (!context.Users.Any())
    {
        context.Users.Add(new User
        {
            Username = "admin",
            Password = "123", 
            Role = "Admin"
        });
        context.SaveChanges();
    }
}

app.MapGet("/", () => Results.Redirect("/index.html"));


app.MapGet("/api/auth/login", (string user, string pass, AppDbContext db) => {
    var foundUser = db.Users.FirstOrDefault(u => u.Username == user && u.Password == pass);
    if (foundUser != null)
    {
        return Results.Ok(new { foundUser.Username, foundUser.Role });
    }
    return Results.Unauthorized();
});


app.MapGet("/api/labs", async (AppDbContext db) => await db.Labs.ToListAsync());

app.MapPost("/api/labs", async (Lab lab, AppDbContext db) => {
    db.Labs.Add(lab);
    await db.SaveChangesAsync();
    return Results.Ok(lab);
});


app.MapGet("/api/computers", async (AppDbContext db) => await db.Computers.ToListAsync());

app.MapPost("/api/computers", async (Computer pc, AppDbContext db) => {
    var lab = await db.Labs.FindAsync(pc.LabId);
    if (lab == null) return Results.BadRequest("Laboratuvar bulunamadý!");

    int count = await db.Computers.CountAsync(c => c.LabId == pc.LabId);
    
    pc.AssetCode = $"{lab.Name.Replace(" ", "")}-PC-{(count + 1).ToString().PadLeft(2, '0')}";

    db.Computers.Add(pc);
    await db.SaveChangesAsync();
    return Results.Ok(pc);
});


app.MapPost("/api/assign", async (AssignRequest req, AppDbContext db) => {
    var pc = await db.Computers.FindAsync(req.ComputerId);
    if (pc == null) return Results.NotFound();

    var newUser = new User
    {
        Username = req.StudentNumber,
        Password = "123",
        Role = "Student",
        StudentNumber = req.StudentNumber
    };

    db.Users.Add(newUser);
    await db.SaveChangesAsync();

    pc.AssignedUserId = newUser.Id;
    await db.SaveChangesAsync();

    return Results.Ok();
});


app.MapGet("/api/student/pc", async (string username, AppDbContext db) => {
    
    var user = await db.Users.FirstOrDefaultAsync(u => u.Username == username);

    if (user == null) return Results.NotFound("Kullanýcý bulunamadý");

    
    var pc = await db.Computers.FirstOrDefaultAsync(c => c.AssignedUserId == user.Id);

    if (pc == null) return Results.NotFound("Zimmetli bilgisayar yok");

    
    return Results.Ok(pc);
});
app.Run();


public record AssignRequest(int ComputerId, string StudentNumber);