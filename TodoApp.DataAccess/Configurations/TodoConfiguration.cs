using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Shared.Entities;

namespace TodoApp.DataAccess.Configurtions
{
    class TodoConfiguration : IEntityTypeConfiguration<TodoEntity>
    {
        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder
                .ToTable("Todos");
            builder
                .HasKey(e => e.Id);
            builder
                .Property(e => e.Text)
                .IsRequired();
            builder
                .Property(e => e.Done)
                .IsRequired();
        }
    }
}
