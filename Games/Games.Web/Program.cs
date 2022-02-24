using FluentValidation.AspNetCore;
using Games.Core;
using Games.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbServices();
builder.Services.AddServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<Program>();
});

builder.Services.AddSwaggerGen();
builder.Services.AddCors(config =>
{
    config.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
