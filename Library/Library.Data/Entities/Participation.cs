namespace Library.Data.Entities
{
    public class Participation
    {
        public long BookId { get; set; }
        public long WriterId { get; set; }

        public virtual Writer Writer { get; set; }
        public virtual Book Book { get; set; }
    }
}
