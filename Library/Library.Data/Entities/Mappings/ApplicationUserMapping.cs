using Library.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Entities.Mappings
{
    public class ApplicationUserMapping : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMapping()
        {
            HasKey(p => p.Id);


            HasMany(x => x.Orders)
                .WithRequired(x => x.User);

            HasMany(entity => entity.Logins).WithRequired().HasForeignKey(entity => entity.UserId);
            HasMany(entity => entity.Roles).WithRequired().HasForeignKey(entity => entity.UserId);
        }
    }
}
