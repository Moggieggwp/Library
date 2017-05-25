using System;
using System.Collections.Generic;

namespace Library.Data.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fare { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public bool IsOrdered { get; set; }
        public DateTime IssueYear { get; set; }
        public string ImageName { get; set; }
        public string PathToReadOnline { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Participation> Writers { get; set; }
    }
}
