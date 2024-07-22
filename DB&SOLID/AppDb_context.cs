using Microsoft.EntityFrameworkCore;


namespace DB_SOLID
{
    public class AppDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=test;UID=root;Password=burak123;", new MySqlServerVersion(new Version(8, 0, 21)));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("foods");

                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.name).HasColumnName("name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.price).HasColumnName("price").IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(e => e.description).HasColumnName("description");
            });
        }
    }
}

