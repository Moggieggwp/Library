using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Publisher.Interfaces
{
    public interface IPublisherRepository
    {
        Task<List<Entities.Publisher>> GetPublishersByPartialName(string partialName);
    }
}
