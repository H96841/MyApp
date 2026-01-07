using Microsoft.EntityFrameworkCore;

using MyApp.Data;
using MyApp.Reposetory;
using MyApp.Repository;
using MyApp.Service;

var builder = WebApplication.CreateBuilder(args);
//Add-Migration initalCreate
// update-database
// Add services to the container.
builder.Services.AddControllers();

// Register EF DbContext (InMemory for demo; replace with real DB in production)
builder.Services.AddDbContext<AppDbContext>(options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("SalesConnection")));
  

// Register repository and service
builder.Services.AddScoped<IGiftRepository, GiftRepository>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICateroryRepository, CateroryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    //c =>
//{
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApp API", Version = "v1" });
//});

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

app.Run();
