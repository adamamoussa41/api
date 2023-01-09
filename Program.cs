using Microsoft.EntityFrameworkCore;
using Crud_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyTaskContext>(opt =>
    opt.UseInMemoryDatabase("Tasklist"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "Tasklist", Version = "v1" });
//});

builder.Services.AddDbContext<MaterialContext>(opt =>
    opt.UseInMemoryDatabase("Materiallist"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "Materiallist", Version = "v1" });
//});

// builder.Services.AddDbContext<TaskMaterialUsageContext>(opt =>
//     opt.UseInMemoryDatabase("TaskMaterialUsagelist"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TaskMaterialUsagelist", Version = "v1" });
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


if(builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // app.UseHttpsRedirection();
    app.UseCors();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
