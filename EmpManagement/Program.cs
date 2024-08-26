using AutoMapper;
using EmpManagement.Data.Automapper;
using EmpManagement.Data.DataContext;
using EmpManagement.Data.Repositories;
using EmpManagement.Data.Repositories.IRepositories;
using EmpManagement.Services.Interfaces;
using EmpManagement.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Automapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>(); // Register your AutoMapper profile(s) here
});

// Register IMapper with the DI container
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Auth",
        Description = "Enter Token Value Here",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", b =>
    {
        b
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
#endregion

//#region DB
//builder.Services.AddDbContext<EmpDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
//});
//#endregion

#region  AuthDB
builder.Services.AddDbContext<EmpDbAuth>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection"));
});
#endregion

#region DI
builder.Services.AddTransient<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddTransient<IDepartmentRepository,DepartmentRepository>();
builder.Services.AddScoped<IEmpService,EmpService>();
builder.Services.AddScoped<IDepService,DepService>();
#endregion

#region Identity API EndPoints
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<EmpDbAuth>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapIdentityApi<IdentityUser>();

app.UseCors("CORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
