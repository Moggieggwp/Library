using EasyFlights.Data.Mappings;
using Library.Data.Entities;
using Library.Data.Entities.Mappings;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace Library.Data.Context
{
    public class LibraryDatabaseContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        private static int id = 0;
        private int idObj = ++id;

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Participation> Participations { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public bool AutoDetectChangesEnabled
        {
            get { return Configuration.AutoDetectChangesEnabled; }
            set { Configuration.AutoDetectChangesEnabled = value; }
        }

        public void DetectChanges()
        {
            ChangeTracker.DetectChanges();
        }

        public LibraryDatabaseContext() : base("LibraryDatabaseContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryDatabaseContext>());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>();
            modelBuilder.Entity<IdentityUserRole>();
           // modelBuilder.Entity<IdentityUserClaim>();
            modelBuilder.Entity<IdentityUserLogin>();

            modelBuilder.Configurations.Add(new BookMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new ParticipationMapping());
            modelBuilder.Configurations.Add(new PublisherMapping());
            modelBuilder.Configurations.Add(new ApplicationUserMapping());
            modelBuilder.Configurations.Add(new ApplicationRoleMapping());
           // modelBuilder.Configurations.Add(new ApplicationUserRoleMapping());
           // modelBuilder.Configurations.Add(new ApplicationUserLoginMapping());

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
