using ApplicationServices.Implementation;
using CloseMate.Api.Extensions;
using DataAccess.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using OpenAI.Implementations;
using System.Reflection;
using System.Text.Json.Serialization;
using UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddUseCases(Assembly.GetExecutingAssembly(), builder.Configuration);

builder.Services.AddOpenAI(builder.Configuration);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddDataAccessPostgreSQL(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
