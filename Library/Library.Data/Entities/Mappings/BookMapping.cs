using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Entities.Mappings
{
    public class BookMapping : EntityTypeConfiguration<Book>
    {
        public BookMapping()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Publisher)
                .WithMany(x => x.Books)
                .WillCascadeOnDelete(false);
        }
    }
}
