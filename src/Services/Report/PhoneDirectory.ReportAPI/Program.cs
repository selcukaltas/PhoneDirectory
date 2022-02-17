using Microsoft.EntityFrameworkCore;
using PhoneDirectory.DirectoryApplicationCore.Middleware;
using PhoneDirectory.DirectoryInfrastructure;
using PhoneDirectory.ReportApplicationCore.Mapper;
using PhoneDirectory.ReportApplicationCore.Services;
using PhoneDirectory.Shared.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReportDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddSingleton<ConsumerService>();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(ReportProfile));

var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<ReportDbContext>().Database.Migrate();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.UseRabbitListener();


app.MapControllers();

app.Run();
