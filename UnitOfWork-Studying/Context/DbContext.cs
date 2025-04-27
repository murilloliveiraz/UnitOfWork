using Microsoft.EntityFrameworkCore;
using UnitOfWork_Studying.Domain;

namespace UnitOfWork_Studying.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {

                entity.HasKey(p => p.ProductId);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Price)
                      .HasPrecision(18, 2);

                // Se quiser adicionar relacionamentos, seria aqui também
            });
        }
    }
}
