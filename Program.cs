using Kanban.Api.Repositories;
using Kanban.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/* dependency injection  */
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();