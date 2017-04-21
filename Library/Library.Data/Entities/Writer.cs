using System;
using System.Collections.Generic;

namespace Library.Data.Entities
{
    public class Writer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Participation> Books { get; set; }
    }
}
