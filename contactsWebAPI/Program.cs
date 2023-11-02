using contactsWebAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseInMemoryDatabase("ContactsDb"));  
//we pass option. it will use memory data base to store and retrieve data. and give name to database called "ContactsDb".it also know tables because we have set it in DbSet

//builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseSqlServer(   builder  .Configuration.GetConnectionString("ContactsApiConnectionString")));  
// here we connect sql server to store and retrieve data. string is from appSettigs.json file

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
