using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workshop.Data.Contracts;

namespace Workshop.Data.Services
{
    public class DataService : IDataService
    {
        private readonly WorkshopDbContext _dbContext;

        public DataService(WorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public async Task SaveDbAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}