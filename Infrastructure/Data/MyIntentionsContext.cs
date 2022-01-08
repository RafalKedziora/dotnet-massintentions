namespace Infrastructure.Data
{
    public class MyIntentionsContext : DbContext
    {
        public MyIntentionsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Intention> Intentions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Intention
            modelBuilder.Entity<Intention>().ToTable("Intentions");
            modelBuilder.Entity<Intention>().HasKey(x => x.Id);
            modelBuilder.Entity<Intention>()
                .Property(x => x.Title)
                .HasMaxLength(60)
                .IsRequired();
            modelBuilder.Entity<Intention>()
                .Property(x => x.Content)
                .HasMaxLength(500);
            modelBuilder.Entity<Intention>()
                .Property(p => p.MassDate)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<Intention>()
                .HasOne(x => x.Detail)
                .WithOne(y => y.Intention)
                .HasForeignKey<IntentionDetail>(nd => nd.IntentionId);

            #endregion

            #region Category

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region IntentionDetail

            modelBuilder.Entity<IntentionDetail>().ToTable("IntentionDetails");
            modelBuilder.Entity<IntentionDetail>().HasKey(x => x.Id);
            modelBuilder.Entity<IntentionDetail>()
                .Property(p => p.Created)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<IntentionDetail>()
                .Property(p => p.LastModified)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();

            #endregion
        }
    }
}
