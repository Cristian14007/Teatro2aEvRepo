using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BackEnd.Business;
using BackEnd.Data;


//var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/* builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddSingleton<IIngredientesRepository, IngredientesRepository>();
builder.Services.AddScoped<IngredienteService>(); */


builder.Services.AddScoped<IObraService, ObraService>();
builder.Services.AddScoped<IObraRepository, ObraEFRepository>();

//var connectionString = builder.Configuration.GetConnectionString("ServerDB");
var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddDbContext<ObraContext>(options =>
    options.UseSqlServer(connectionString)
    .LogTo(Console.WriteLine,LogLevel.Information));
  
  



/* builder.Services.AddScoped<IPizzaRepository, PizzaSqlRepository>(serviceProvider => 
    new PizzaSqlRepository(connectionString));

    builder.Services.AddScoped<IIngredientesRepository, IngredienteSqlRepository>(serviceProvider => 
    new IngredienteSqlRepository(connectionString)); */


/* builder.Services.AddScoped<IngredienteService>();
builder.Services.AddSingleton<IIngredientesRepository, IngredientesRepository>(); */

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
