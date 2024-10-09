using Microsoft.EntityFrameworkCore;
using VideoGamesLibreryBack.DbSet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("conn");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString, sqlOptions =>
sqlOptions.EnableRetryOnFailure(
    maxRetryCount: 5,// N�mero m�ximo de reintentos
    maxRetryDelay: TimeSpan.FromSeconds(30), // Tiempo m�ximo de espera entre reintentos
    errorNumbersToAdd: null) // Puedes especificar c�digos de error adicionales si es necesario
));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
