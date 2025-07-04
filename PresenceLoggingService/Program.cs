using Microsoft.EntityFrameworkCore;
using PresenceLoggingService.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IHrDepartmentRepo, HrDepartmentRepo>();
builder.Services.AddScoped<ISecurityCheckpointRepo, SecurityCheckpointRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("swagger/v1/swagger.json", "Presence Logging Service V1");
        c.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();