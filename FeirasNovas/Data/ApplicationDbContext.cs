using FeirasNovas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FeirasNovas.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Feira_Product>().HasKey(am => new
        {
            am.idFeira,
            am.idProduto
        });

        builder.Entity<Feira_Product>().HasOne(m => m.Feiras).WithMany(am => am.Feira_Products).HasForeignKey(m => m.idFeira);
        builder.Entity<Feira_Product>().HasOne(m => m.Product).WithMany(am => am.Feira_Products).HasForeignKey(m => m.idProduto);

        base.OnModelCreating(builder);



    }

    public DbSet<VendedorL> VendedorL { get; set; }
    public DbSet<Feiras> Feiras { get; set; }

    public DbSet<Product> Product { get; set; }

    public DbSet<Feira_Product> Feira_Product { get; set; }



}

