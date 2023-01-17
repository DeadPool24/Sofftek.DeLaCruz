namespace Sofftek.GestionComercial.Service.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sofftek.GestionComercial.Service.Entities;

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

        modelBuilder.Entity<DetalleVenta>().HasNoKey();

        base.OnModelCreating(modelBuilder);

    }

    public DbSet<Venta> Venta { get; set; }
    public DbSet<DetalleVenta> DetalleVenta { get; set; }
}