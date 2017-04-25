using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Entities.Mappings
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            HasKey(x => x.Id);

            HasMany(x => x.Books)
                .WithOptional(x => x.Order)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.User)
                .WithMany(x => x.Orders);
        }
    }
}
