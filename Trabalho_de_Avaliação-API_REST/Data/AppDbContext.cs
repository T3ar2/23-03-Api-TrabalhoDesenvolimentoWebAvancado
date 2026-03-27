using Microsoft.EntityFrameworkCore;

namespace ModelsAPI;


public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Categoria> Categoria => Set<Categoria>();
    public DbSet<Cliente> Cliente => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        var produto = modelBuilder.Entity<Produto>();
        produto
            .Property(p => p.Preco)
            .HasPrecision(18, 2)
            .IsRequired();

        produto
            .Property(p => p.Nome)
            .HasMaxLength(120)
            .IsRequired();
        produto
            .Property(p => p.Estoque);
        
        var categoria = modelBuilder.Entity<Categoria>();
        categoria
            .Property(p => p.Nome)
            .HasMaxLength(80)
            .IsRequired();
        categoria
            .Property(p => p.Descricao)
            .HasMaxLength(200);
        var cliente = modelBuilder.Entity<Cliente>();
        cliente
            .Property(p => p.Nome)
            .HasMaxLength(100)
            .IsRequired();
        cliente 
            .Property(p => p.Email)
            .IsRequired();
            modelBuilder.Entity<Cliente>()
            .ToTable(t => t.HasCheckConstraint("CK_Email_Valido", "Email LIKE '%@%.%'"));
        cliente
            .Property(p => p.Idade)
            .IsRequired();
          modelBuilder.Entity<Cliente>()
            .ToTable(t => t.HasCheckConstraint("CK_Usuario_Idade_Minima", "Idade >= 18"));  
    }

}
