using System.Collections.Generic;
using System.Threading.Tasks;

namespace FProject.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create( T model );
        List<T> ReadAll();
        Task Update( T model );
        Task Delete( T model );
    }
}
