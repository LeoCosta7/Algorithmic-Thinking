using CleanArchMvc.Domain.Entities;
//using CleanArchMvc.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) {}

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);   //Para poder usar arquivos separados que estão herdando a interface IEntityTypeConfiguration     
        //modelBuilder.ApplyConfiguration(new CategoryConfiguration()); <- Caso n use a opção acima e queira declarar diretamente aqui
    }
}