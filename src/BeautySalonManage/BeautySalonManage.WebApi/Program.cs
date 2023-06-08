using BeautySalonManage.Application;
using BeautySalonManage.Infrastructure;
using BeautySalonManage.Infrastructure.Persistence;
using BeautySalonManage.WebApi;
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

builder.Services
    .AddApplicationLayer()
    .AddPresentationLayer()
    .AddInfrastructureLayer(builder.Configuration);

var app = builder.Build();

// Initialise and seed database
using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
    await initialiser.InitialiseAsync();
    await initialiser.SeedAsync();
}

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
