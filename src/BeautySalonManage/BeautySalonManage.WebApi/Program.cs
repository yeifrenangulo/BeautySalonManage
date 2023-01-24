using BeautySalonManage.Application;
using BeautySalonManage.Perisistence;
using BeautySalonManage.Shared;
using BeautySalonManage.WebApi.Extensions;
using BeautySalonManage.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddPolicy(name: "hostAllowedDevelopment", cors =>
    {
        cors
        .WithOrigins("http://localhost:4200", "http://localhost")
        .AllowAnyMethod()
        .AllowAnyHeader();
    })
);

// Add services to the container.
builder.Services.AddSharedInfraestructure(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();

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

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors("hostAllowedDevelopment");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
