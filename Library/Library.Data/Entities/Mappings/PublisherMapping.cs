using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Entities.Mappings
{
    public class PublisherMapping : EntityTypeConfiguration<Publisher>
    {
        public PublisherMapping()
        {
            HasKey(x => x.Id);

            HasMany(x => x.Books)
                .WithRequired(x => x.Publisher);
        }
    }
}
