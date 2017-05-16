using Library.Services.Interfaces;
using Library.ViewModels;
using System.Threading.Tasks;
using Library.Data.Repositories.Writer.Interfaces;
using Library.Data.Repositories.Publisher.Interfaces;
using Library.Data.Repositories.Book.Interfaces;
using System.Linq;
using Library.Data.Entities;
using Library.Data.DTOs;

namespace Library.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBookRepository bookRepository;
        private readonly IPublisherRepository publisherRepository;
        private readonly IWriterRepository writerRepository;

        public SearchService(
            IBookRepository bookRepository,
            IPublisherRepository publisherRepository,
            IWriterRepository writerRepository)
        {
            this.bookRepository = bookRepository;
            this.publisherRepository = publisherRepository;
            this.writerRepository = writerRepository;
        }

        public async Task<SearchResultViewModel> GetItems(string partialName)
        {
            partialName = partialName.ToUpperInvariant().FirstOrDefault() +
                          partialName.ToLowerInvariant().Substring(1);

            var books = await bookRepository.GetBooksByPartialName(partialName);
            var writers = await writerRepository.GetWritersByPartialName(partialName);
            var publishers = await publisherRepository.GetPublishersByPartialName(partialName);

            return new SearchResultViewModel
            {
                Books = books.Select(CreateBookDTO).ToList(),
                Publishers = publishers.Select(CreatePublisherDTO).ToList(),
                Writers = writers.Select(CreateWriterDTO).ToList()
            };
        }

        public async Task<BookInfoViewModel> GetDetailsInfo(int bookId)
        {
            var book = await bookRepository.GetBookById(bookId);
            return  new BookInfoViewModel
            {
                Book = CreateBookDTO(book),
                Publisher = CreatePublisherDTO(book.Publisher),
                Writers = book.Writers.Select(x => x.Writer).Select(CreateWriterDTO).ToList()
            };
        }

        private BookDTO CreateBookDTO(Book book)
        {
            return new BookDTO
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.Description,
                Fare = book.Fare,
                IssueYear = book.IssueYear.Date,
                Pages = book.Pages,
                ImageName = book.ImageName,
                PathToReadOnline = book.PathToReadOnline
            };
        }

        private PublisherDTO CreatePublisherDTO(Publisher publisher)
        {
            return new PublisherDTO
            {
                PublisherId = publisher.Id,
                City = publisher.City,
                Title = publisher.Title,
                ImageName = publisher.ImageName
            };
        }

        private WriterDTO CreateWriterDTO(Writer writer)
        {
            return new WriterDTO
            {
                WriterId = writer.Id,
                BirthDate = writer.BirthDate.Date,
                FullName = writer.FullName,
                ImageName = writer.ImageName
            };
        }
    }
}