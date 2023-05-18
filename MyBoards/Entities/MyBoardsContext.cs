using Microsoft.EntityFrameworkCore;

namespace MyBoards.Entities
{
    public class MyBoardsContext : DbContext
    {
        public MyBoardsContext(DbContextOptions<MyBoardsContext> options) : base(options)
        {

        }

        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-HELIKOP;Database=EfBoardsDb;Trusted_Connection=True");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasKey(x => new {x.FirstName, x.LastName});
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<WorkItem>()
            //    .Property(w => w.State)
            //    .IsRequired();

            //modelBuilder.Entity<WorkItem>()
            //    .Property(w => w.Area)
            //    .HasColumnType("varchar(200)");

            modelBuilder.Entity<WorkItem>(eb =>
            {
                eb.Property(wi => wi.IterationPath).HasColumnName("Iteration_Path");
                eb.Property(wi => wi.Effort).HasColumnType("decimal(5,2");
                eb.Property(wi => wi.EndDate).HasPrecision(3);
                eb.Property(wi => wi.Activity).HasMaxLength(200);
                eb.Property(wi => wi.RemainingWork).HasPrecision(14,2);
                eb.Property(wi => wi.State).IsRequired();
                eb.Property(wi => wi.Area).HasColumnType("varchar(200)");
                eb.Property(wi => wi.Priority).HasDefaultValue(1);
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(wi => wi.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(wi => wi.UpdatedDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);


        }
    }
}
