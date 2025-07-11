using Microsoft.EntityFrameworkCore;
using JobRepository;
using JobRepository.Repository;
using JobService.Service;
using JobService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure Entity Framework with your JobsRepository
builder.Services.AddDbContext<JobPortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your repositories and services
builder.Services.AddScoped<IJobRepo, JobsRepository>();
builder.Services.AddScoped<IJobService, JobsService>();
builder.Services.AddScoped<IUserRepo, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();

// Configure CORS if needed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();