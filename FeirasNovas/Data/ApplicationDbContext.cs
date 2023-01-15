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
    public DbSet<Product> Produto { get; set; }
    public DbSet<Sales> Venda { get; set; }
    public DbSet<Feiras> Feiras { get; set; }

<<<<<<< HEAD
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


        //builder.Entity<Feiras>()
        //    .HasMany(f => f.Vendedores)
        //    .WithOne()
        //    .OnDelete(DeleteBehavior.Cascade);
    }
     
    public DbSet<Feiras> Feira { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Feira_Product> Feira_Products { get; set; }


=======
>>>>>>> b3f80d55761f5e7dac1a2a5d267adb0f19c70dc4
}

