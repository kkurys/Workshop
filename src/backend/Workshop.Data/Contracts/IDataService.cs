using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Workshop.Data.Contracts
{
    public interface IDataService
    {
        DbSet<T> GetSet<T>() where T : class;
        Task SaveDbAsync();
    }
}
