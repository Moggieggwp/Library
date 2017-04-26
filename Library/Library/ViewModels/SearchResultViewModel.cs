using Library.Data.DTOs;
using System.Collections.Generic;

namespace Library.ViewModels
{
    public class SearchResultViewModel
    {
        public List<BookDTO> Books { get; set; }
        public List<WriterDTO> Writers { get; set; }
        public List<PublisherDTO> Publishers { get; set; }
    }
}