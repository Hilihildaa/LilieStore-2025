using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("Infrastructure") // حتماً نام پروژه‌ی Migration
    )
);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
