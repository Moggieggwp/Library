using Library.Data.Repositories.Base;
using Library.Data.Repositories.Publisher.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Publisher
{
    public class PublisherRepository : Repository<Entities.Publisher>, IPublisherRepository
    {
        private readonly IDbSet<Entities.Publisher> publisherDataSet;

        public PublisherRepository(DbContext dataContext) : base(dataContext)
        {
            this.publisherDataSet = dataContext.Set<Entities.Publisher>();
        }

        public Task<List<Entities.Publisher>> GetPublishersByPartialName(string partialName)
        {
            return publisherDataSet
                .Where(x => (x.Title + " " + x.City).StartsWith(partialName)
                || (x.Title + " " + x.City).StartsWith(partialName.ToUpper())
                || (x.Title + " " + x.City).StartsWith(partialName.ToLower())
                || (x.Title + " " + x.City).Contains(" " + partialName)
                || (x.Title + " " + x.City).Contains(" " + partialName.ToUpper())
                || (x.Title + " " + x.City).Contains(" " + partialName.ToLower()))
                .ToListAsync();
        }
    }
}
