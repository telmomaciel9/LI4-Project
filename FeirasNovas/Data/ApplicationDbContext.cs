using FeirasNovas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FeirasNovas.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Produto { get; set; }
    public DbSet<Sales> Venda { get; set; }
    public DbSet<FeirasNovas.Models.Feiras> Feiras { get; set; } = default!;
}

