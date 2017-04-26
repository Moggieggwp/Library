using System;

namespace Library.Data.DTOs
{
    public class WriterDTO
    {
        public long WriterId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageName { get; set; }
    }
}
