using GameAPI.Persistence;
using GameAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GamesDatabase");

var repository = new Repository(connectionString);

var projectRootPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
var scriptsPath = Path.Combine(projectRootPath, "SQL");
var configFilePath = Path.Combine(projectRootPath, "SQL", "migrations.json");

var migrationRunner = new MigrationRunner(connectionString, scriptsPath, configFilePath);
migrationRunner.RunMigrations();

// Add services to the container.
builder.Services.AddScoped<IRepository, Repository>((provider) => repository);

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
