using System;
using System.Collections.Generic;

namespace Library.Data.Entities
{
    public class Writer
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<Participation> Books { get; set; }
    }
}
