using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MyIntentionsContext : DbContext
    {
        public MyIntentionsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Intention> Intentions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intention>().ToTable("Intentions");
            modelBuilder.Entity<Intention>().HasKey(x => x.Id);
            modelBuilder.Entity<Intention>()
                .Property(x => x.Title)
                .HasMaxLength(60)
                .IsRequired();
            modelBuilder.Entity<Intention>()
                .Property(x => x.Content)
                .HasMaxLength(500);
        }
    }
}
