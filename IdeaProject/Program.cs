using DataAccess;
using DataAccess.Repositories;
using DataContract.Contracts;
using IdeaProject.Configurations;
using Service.Services;
using ServiceContract.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfiq));
builder.Services.AddScoped<IIdeaService, IdeaService>();
builder.Services.AddScoped<IIdeaRepository, IdeaRepository>();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("DefaultSQLConnection"));

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