using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.Mappings
{
    public class ApplicationRoleMapping : EntityTypeConfiguration<IdentityRole>
    {
        public ApplicationRoleMapping()
        {
            HasKey(r => r.Id);

            HasMany(entity => entity.Users).WithRequired().HasForeignKey(entity => entity.RoleId);
        }
    }
}
