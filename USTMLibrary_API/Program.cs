using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using USTMLibrary_API.Data;
var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<USTMLibrary_APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("USTMLibrary_APIContext") ?? throw new InvalidOperationException("Connection string 'USTMLibrary_APIContext' not found.")));

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("http://127.0.0.1:7213").AllowAnyMethod().AllowAnyHeader();
					  });
});

// Add services to the container.

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


app.UseCors(MyAllowSpecificOrigins);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
