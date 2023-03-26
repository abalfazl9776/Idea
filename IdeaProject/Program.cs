using DataAccess;
using DataAccess.Repositories;
using DataContract.Contracts;
using FluentValidation;
using IdeaProject.Configurations;
using IdeaProject.ViewModels;
using Service.Services;
using ServiceContract.Contracts;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfiq));
builder.Services.AddScoped<IIdeaService, IdeaService>();
builder.Services.AddScoped<IIdeaRepository, IdeaRepository>();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
builder.Services.AddScoped<IValidator<IdeaInputVm>, IdeaValidator>();
builder.Services.AddScoped<IIdeaRepository, IdeaRepository>();
builder.Services.AddControllers()
    .AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    // Automatic registration of validators in assembly
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}); ;
var app = builder.Build();
// Add services to the container.


app.MapPost("/Idea", async (IValidator<IdeaInputVm> validator, IdeaInputVm ideainputvm) =>
{
    ValidationResult validationResult = await validator.ValidateAsync(ideainputvm);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }
    return Results.Created("", ideainputvm);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


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