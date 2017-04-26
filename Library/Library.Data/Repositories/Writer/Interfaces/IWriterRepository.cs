using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Writer.Interfaces
{
    public interface IWriterRepository
    {
        Task<List<Entities.Writer>> GetWritersByPartialName(string partialName);
    }
}
