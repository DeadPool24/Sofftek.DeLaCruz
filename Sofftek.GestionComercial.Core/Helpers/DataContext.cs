namespace Sofftek.GestionComercial.Core.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofftek.GestionComercial.Core.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("GestionComercialBD");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Venta>().HasKey(ve => new
        {
            ve.id_venta
        });

        modelBuilder.Entity<Articulo>().HasKey(art => new
        {
            art.id_producto
        });

        modelBuilder.Entity<Cliente>().HasKey(cli => new
        {
            cli.id_cliente
        });

        modelBuilder.Entity<Asesor>().HasKey(ase => new
        {
            ase.id_asesor
        });

        modelBuilder.Entity<DetalleVenta>().HasNoKey();

        base.OnModelCreating(modelBuilder);

    }

    public DbSet<Venta> Venta { get; set; }
    public DbSet<DetalleVenta> DetalleVenta { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Articulo> Articulo { get; set; }
    public DbSet<Asesor> Asesor { get; set; }
}