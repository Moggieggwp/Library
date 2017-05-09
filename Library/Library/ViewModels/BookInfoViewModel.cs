using Library.Data.DTOs;
using System.Collections.Generic;

namespace Library.ViewModels
{
    public class BookInfoViewModel
    {
        public BookDTO Book { get; set; }
        public List<WriterDTO> Writers { get; set; }
        public PublisherDTO Publisher { get; set; }
    }
}