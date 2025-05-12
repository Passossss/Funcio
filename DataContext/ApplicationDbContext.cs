using System.Security.Principal;
using Funcio.Models;
using Microsoft.EntityFrameworkCore;

namespace Funcio.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<FuncionarioModel> Funcionarios {
        get;
        set;
    }
}