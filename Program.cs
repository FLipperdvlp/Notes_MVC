using Microsoft.EntityFrameworkCore;
using Notes_API.Database;
using Notes_API.Interfaces;
using Notes_API.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite("Data source = notes.db");
    });
    builder.Services.AddScoped<INoteService, NoteService>();
    builder.Services.AddScoped<IUserService, UserService>();
}

var app = builder.Build();
{
    app.UseStaticFiles();
    app.MapControllerRoute( "default", "{controller=Notes}/{action=List}/{id?}");
    app.Run();   
}