using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.Data.Mappings
{
    public class ApplicationUserLoginMapping : EntityTypeConfiguration<IdentityUserLogin>
    {
        public ApplicationUserLoginMapping()
        {
            HasKey(l => l.UserId);
        }
    }
}
