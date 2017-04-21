using System.Collections.Generic;

namespace Library.Data.Entities
{
    public class Publisher
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
