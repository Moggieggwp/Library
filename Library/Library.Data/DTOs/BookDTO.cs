﻿using System;

namespace Library.Data.DTOs
{
    public class BookDTO
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fare { get; set; }
        public int Pages { get; set; }
        public DateTime IssueYear { get; set; }
    }
}
