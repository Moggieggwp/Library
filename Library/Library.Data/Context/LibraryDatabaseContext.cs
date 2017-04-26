using Library.Data.Entities;
using Library.Data.Entities.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Library.Data.Context
{
    public class LibraryDatabaseContext : DbContext
    {
        private static int id = 0;
        private int idObj = ++id;

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public LibraryDatabaseContext() : base("LibraryDatabaseContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryDatabaseContext>());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BookMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new ParticipationMapping());
            modelBuilder.Configurations.Add(new PublisherMapping());
            modelBuilder.Configurations.Add(new ApplicationUserMapping());

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
