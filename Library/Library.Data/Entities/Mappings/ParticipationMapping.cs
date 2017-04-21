using System.Data.Entity.ModelConfiguration;

namespace Library.Data.Entities.Mappings
{
    public class ParticipationMapping : EntityTypeConfiguration<Participation>
    {
        public ParticipationMapping()
        {
            HasKey(entity => new { entity.BookId, entity.WriterId });

            HasRequired(x => x.Book)
                .WithMany(x => x.Writers)
                .HasForeignKey(x => x.BookId);

            HasRequired(x => x.Writer)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.WriterId);
        }
    }
}
