using BeautySalonManage.Domain.Entities;
using BeautySalonManage.Infrastructure.Identity.Models;
using BeautySalonManage.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BeautySalonManage.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new ApplicationRole { Name = "Administrador", IsActive = true };
        var collaboratorRole = new ApplicationRole { Name = "Colaborador", IsActive = true };

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        if (_roleManager.Roles.All(r => r.Name != collaboratorRole.Name))
        {
            await _roleManager.CreateAsync(collaboratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { 
            Name = "Usuario",
            Surname = "Administrador",
            UserName = "admin", 
            Email = "administrator@prueba.com",
            IsActive = true,
        };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "12345Aa.");

            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name, collaboratorRole.Name });
            }
        }

        if (!_context.Genders.Any())
        {
            _context.Genders.AddRange(
                new Gender { Name = "Hombre" }, 
                new Gender { Name = "Mujer" }
            );

            await _context.SaveChangesAsync();
        }

        if (!_context.States.Any())
        {
            _context.States.AddRange(
                new State { Name = "Pendiente" }, 
                new State { Name = "Atendido" },
                new State { Name = "Cancelado"}
            );

            await _context.SaveChangesAsync();
        }
    }
}
