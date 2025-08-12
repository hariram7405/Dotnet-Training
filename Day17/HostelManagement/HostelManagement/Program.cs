using HostelManagement.Application.Services;
using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// repositories (in-memory singletons)
builder.Services.AddSingleton<IRepository<Room>, RoomRepository>();
builder.Services.AddSingleton<IRepository<Staff>, StaffRepository>();
builder.Services.AddSingleton<IRepository<Student>, StudentRepository>();

// application services (use interfaces)
builder.Services.AddSingleton<IRoomService, RoomService>();
builder.Services.AddSingleton<IStaffService, StaffService>();
builder.Services.AddSingleton<IStudentService, StudentService>();

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
