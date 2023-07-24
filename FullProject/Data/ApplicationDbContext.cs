using FullProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
        }
        public DbSet<Projects>? Project { get; set; }
        public DbSet<Orders>? Order { get; set; }
        public DbSet<Actions>? Action { get; set; }
        public DbSet<ActionsTypes>? ActionType { get; set; }
        public DbSet<GenerlDatas>? GenerlData { get; set; }
        public DbSet<Processes2>? Process2 { get; set; }
        public DbSet<Processes3>? Process3 { get; set; }
        public DbSet<ProductDatas>? ProductData { get; set; }
        public DbSet<ProductTypes>? ProductType { get; set; }
        public DbSet<StartActivity>? StartActivity { get; set; }
        public DbSet<TaxPayers>? TaxPayer { get; set; }
        public DbSet<StartProcesses>? StartProcess { get; set; }
        public DbSet<TaxPayerData>? TaxPayerData { get; set; }
    }
}