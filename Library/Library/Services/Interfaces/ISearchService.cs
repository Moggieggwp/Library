using Library.Data.Entities;
using Library.ViewModels;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResultViewModel> GetItems(string partialName);
        Task<BookInfoViewModel> GetDetailsInfo(int bookId);
    }
}