//3
using Assignment1_redo1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")//Angular dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//THE DEPENDENCY INJECTION
//An instance of the dbcontext class is created and shared throughout the application when required
//Inside <ProductDBContext>(), we have to pass the value for the corresponding constructor we have in out db context class
//options.UseSqlServer() is saying that we want to use SQL server db for this db context class
//Inside the UseSqlServer() method, we have to pass the corresponding DB connection string...to do that go to appsettings.json
//In order to retain the data from the appsetting.json file we will make use of the builder object in UseSqlServer(builder.Configuration.GetConnectionString()
//Inside that builder object must be the corresponding key that we have in our appsetting.json file --"ProductConnection"--
builder.Services.AddDbContext<ProductDBContext>(options => //lambda expression wih this options parameter
options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"))); //5

//Now we can move on to migrations - migration is process of creating a physical DB from the Model and DB context class that we have created
//Before migrating - always try to build the project first

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers(); //the routing of the running API is left to the controllers

app.Run();
