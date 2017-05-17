using Library.Data.DTOs;
using System;

namespace Library.ViewModels
{
    public class OrderViewModel
    {
        public BookDTO Book { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}