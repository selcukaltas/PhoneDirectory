using Microsoft.EntityFrameworkCore;
using PhoneDirectory.DirectoryApplicationCore.Interfaces;
using PhoneDirectory.DirectoryApplicationCore.Services;
using PhoneDirectory.DirectoryInfrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IContactInformation, ContactInformationService>();
var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<DirectoryDbContext>().Database.Migrate();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
