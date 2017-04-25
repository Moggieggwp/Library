using Library.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Entities.Mappings
{
    public class ApplicationUserMapping : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMapping()
        {
            HasKey(p => p.UserId);
            //Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("ApplicationUsers");
            //});

            //Property(u => u.FirstName).IsRequired();
            //Property(u => u.LastName).IsRequired();

            HasMany(x => x.Orders)
                .WithRequired(x => x.User);
        }
    }
}
