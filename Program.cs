using HRMS.API.Data;
using HRMS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using HRMS.API.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(action => { 
    action.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.MapControllers();

app.Run();


