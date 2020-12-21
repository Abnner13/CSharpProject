using System.Collections.Generic;

namespace FProject.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Create( T model );
        List<T> ReadAll();
        void Update( T model );
        void Delete( T model );
    }
}
