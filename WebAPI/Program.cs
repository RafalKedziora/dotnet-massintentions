using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IIntentionRepository, IntentionRepository>();
builder.Services.AddScoped<IIntentionService, IntentionService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        optBuilder =>
        {
            optBuilder.WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

builder.Services.AddDbContext<MyIntentionsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyIntentionsCS")));

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MyIntentions API", Version = "v0.5" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
