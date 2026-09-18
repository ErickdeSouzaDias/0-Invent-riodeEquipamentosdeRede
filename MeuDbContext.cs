using Microsoft.EntityFrameworkCore;

public class MeuDbContext : DbContext
{
    public DbSet<Equipamento> equipamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Dados.db");
    }

}