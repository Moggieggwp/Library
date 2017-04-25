using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.Mappings
{
    public class ApplicationUserRoleMapping : EntityTypeConfiguration<IdentityUserRole>
    {
        public ApplicationUserRoleMapping()
        {
            HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
