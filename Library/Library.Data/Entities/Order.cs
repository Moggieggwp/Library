using System;
using System.Collections.Generic;

namespace Library.Data.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
