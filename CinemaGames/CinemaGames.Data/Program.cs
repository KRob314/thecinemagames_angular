using CinemaGames.Data;
using CinemaGames.Data.Models;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();
builder.Services.AddDbContext<CinemaGamesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaGamesDb")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //    options.RoutePrefix = string.Empty;
    //});

    using (var context = new CinemaGamesDbContext())
    {
        SeedData.SeedDatabase(context);
    }

        app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(
//      "CorsPolicy",
//      builder => builder.WithOrigins("https://localhost:4200").WithOrigins("https://localhost:7121").WithOrigins(";http://localhost:5121").WithOrigins("http://localhost:27114")
//      .AllowAnyMethod()
//      .AllowAnyHeader()
//      .AllowCredentials());
//});
//builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);

//app.UseCors("CorsPolicy");

//app.UseCors(builder => builder.WithOrigins("https://localhost:4200").AllowAnyHeader()
//.WithOrigins("https://localhost:7121").AllowAnyHeader()
//.WithOrigins("http://localhost:5121").AllowAnyHeader()
//.WithOrigins("http://localhost:27114").AllowAnyHeader());

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseAuthorization();

app.MapControllers();

app.Run();
