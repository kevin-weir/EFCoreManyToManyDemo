using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreManyToManyDemo.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) {}
 
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use ModelBuilder to shape the many to many junction table
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    j => j
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_Tags_TagId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_Posts_PostId")
                        .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}
