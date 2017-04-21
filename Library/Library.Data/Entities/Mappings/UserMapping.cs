using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Entities.Mappings
{
    public class UserMapping : EntityTypeConfiguration<ApplicationUser>
    {
        public UserMapping()
        {
            HasKey(x => x.Id);

            HasMany(x => x.Orders)
                .WithRequired(x => x.User)
                .WillCascadeOnDelete(false);
        }
    }
}
