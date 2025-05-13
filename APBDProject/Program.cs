using APBDProject.API.Data;
using APBDProject.API.Repositories.Interfaces;
using APBDProject.API.Repositories.Ef;
using APBDProject.API.Services.Interfaces;
using APBDProject.API.Services;
using APBDProject.API.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
builder.Services.AddScoped<IProjectRepository,    ProjectRepository>();

builder.Services.AddScoped<ITeamService,    TeamService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APBDProject API", Version = "v1" });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APBDProject API v1"));
app.MapControllers();
app.Run();