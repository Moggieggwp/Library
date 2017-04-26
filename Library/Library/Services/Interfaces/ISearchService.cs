using Library.ViewModels;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchResultViewModel> GetItems(string partialName);
    }
}