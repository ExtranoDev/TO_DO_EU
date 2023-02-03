using Microsoft.EntityFrameworkCore;
using ToDoEU.Models.DTO;

namespace ToDoEU.Models.Domain
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
        public DbSet<ToDoItemModel> ToDoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDoItemModel>(entity =>
            {
                entity.Property(e => e.ItemName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.ItemDescription)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.ItemStatus)
                .IsRequired()
                .HasMaxLength(15);
            });

            base.OnModelCreating(builder);
        }
    }
}
