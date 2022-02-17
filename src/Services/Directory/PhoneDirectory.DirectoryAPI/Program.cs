using Microsoft.EntityFrameworkCore;
using PhoneDirectory.DirectoryApplicationCore.Config;
using PhoneDirectory.DirectoryApplicationCore.Interfaces;
using PhoneDirectory.DirectoryApplicationCore.Mapper;
using PhoneDirectory.DirectoryApplicationCore.Middleware;
using PhoneDirectory.DirectoryApplicationCore.Services;
using PhoneDirectory.DirectoryInfrastructure;
using PhoneDirectory.Shared.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DirectoryDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IContactInformation, ContactInformationService>();
builder.Services.AddScoped<ICommunicationService, CommunicationService>();
builder.Services.AddScoped<ConfigHelper>();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(PersonProfile));
var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<DirectoryDbContext>().Database.Migrate();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
