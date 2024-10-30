using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Models; // Adicione isso para acessar as classes de modelo

namespace ProjetoFinalAPI.Data // Certifique-se de que o namespace esteja correto
{
    public class AppDbContext : DbContext
    {
        // Construtor que aceita opções de configuração do DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Propriedades DbSet para as entidades
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        // Método para configurar o modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento entre Book e Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de exclusão em cascata

            // Configuração do relacionamento entre Book e Publisher
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
