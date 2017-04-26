using Library.Data.Repositories.Base;
using Library.Data.Repositories.Writer.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Writer
{
    public class WriterRepository : Repository<Entities.Writer>, IWriterRepository
    {
        private readonly IDbSet<Entities.Writer> publisherDataSet;

        public WriterRepository(DbContext dataContext) : base(dataContext)
        {
            this.publisherDataSet = dataContext.Set<Entities.Writer>();
        }

        public Task<List<Entities.Writer>> GetWritersByPartialName(string partialName)
        {
            return publisherDataSet
                .Where(x => x.FullName.StartsWith(partialName)
                || x.FullName.StartsWith(partialName.ToUpper())
                || x.FullName.StartsWith(partialName.ToLower())
                || x.FullName .Contains(" " + partialName)
                || x.FullName.Contains(" " + partialName.ToUpper())
                || x.FullName.Contains(" " + partialName.ToLower()))
                //|| x.LastName.StartsWith(partialName)
                //|| x.LastName.Contains(" " + partialName)
                //|| x.LastName.Contains(" " + partialName.ToUpper())
                //|| x.LastName.Contains(" " + partialName.ToLower())
                //|| x.LastName.StartsWith(partialName.ToUpper())
                //|| x.LastName.StartsWith(partialName.ToLower()))
                .ToListAsync();
        }
    }
}
