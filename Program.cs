using Kanban.Api.Repositories;
using Kanban.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/* dependency injection  */
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
                      policy =>
                      {
                        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();