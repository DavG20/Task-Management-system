using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManagement.Domain.Common;
using TaskManagement.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Persistence
{
    public class TaskManagementDbContext : IdentityDbContext<AppUser>
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
           : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementDbContext).Assembly);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<AppUser>()
         .HasMany(u => u.Tasks)
         .WithOne(t => t.User)
         .HasForeignKey(t => t.UserId)
         .IsRequired();

            modelBuilder.Entity<Domain.Task>()
           .HasMany(t => t.CheckLists)
           .WithOne()
           .HasForeignKey(cl => cl.TasksId)
           .IsRequired();


            // modelBuilder.Entity<System.Threading.Tasks.Task>().HasNoKey();
            // modelBuilder.Entity<CheckList>().HasNoKey();

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Domain.Task> Tasks { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }


    }
}
