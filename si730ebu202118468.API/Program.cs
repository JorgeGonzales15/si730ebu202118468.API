using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu202118468.API.Inventory.Domain.Repositories;
using si730ebu202118468.API.Inventory.Domain.Services;
using si730ebu202118468.API.Inventory.Mapping;
using si730ebu202118468.API.Inventory.Persistence.Repositories;
using si730ebu202118468.API.Inventory.Services;
using si730ebu202118468.API.Maintenance.Domain.Repositories;
using si730ebu202118468.API.Maintenance.Domain.Services;
using si730ebu202118468.API.Maintenance.Persistence.Repositories;
using si730ebu202118468.API.Maintenance.Services;
using si730ebu202118468.API.Shared.Domain.Repositories;
using si730ebu202118468.API.Shared.Persistence.Contexts;
using si730ebu202118468.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
    //aqui va la documentación, si pide en el examen se  cambia aqui
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Teachable.io Platform API",
        Description = "Teachable.io Platform RESTful API",
        TermsOfService = new Uri("https://Teacheable-Courses.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "Teachable.io",
            Url = new Uri("https://teachable.io")
        },
        License = new OpenApiLicense
        {
            Name = "Teachable.io Platform Resources License",
            Url = new Uri("https://teachable.io/license")
        }
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMaintainanceActivityRepository, MantainanceActivityRepository>();
builder.Services.AddScoped<IMantainanceActivityService, MantainanceActivityService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile),
    typeof(si730ebu202118468.API.Maintenance.Mapping.ModelToResourceProfile),
    typeof(si730ebu202118468.API.Maintenance.Mapping.ResourceToModelProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();