using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TodoApp.DataAccess.Configurtions;
using TodoApp.Shared.Entities;

namespace TodoApp.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {}

        public DbSet<TodoEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TodoConfiguration().Configure(modelBuilder.Entity<TodoEntity>());
     
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=WEBJET-82028\SQLEXPRESS;Database=TodoApp;Trusted_Connection=True");
        }
    }

    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(@"Server=WEBJET-82028\SQLEXPRESS;Database=TodoApp;Trusted_Connection=True");

            return new Context(optionsBuilder.Options);
        }
    }
}
