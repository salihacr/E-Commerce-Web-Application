using System;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        // Repositories


        Task CommitAsync();
        void Commit();
    }
}
