using BambooCard.Middleware;
using BambooCard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Automapper configuration
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<HackerNewsService>();
builder.Services.AddTransient<GlobalExceptionHandler>();

builder.Services.AddControllers();
// Response Caching added
builder.Services.AddResponseCaching();
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
app.UseResponseCaching();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

app.Run();
