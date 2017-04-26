using System;

namespace Library.Data.DTOs
{
    public class WriterDTO
    {
        public long WriterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
