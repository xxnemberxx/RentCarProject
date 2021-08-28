using DataAccess.Abstract;
using System;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IVehicleDal Vehicles { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
