using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly ProjectDbContext _context;
        private EfVehicleDal _efVehicleDal;
        private bool _disposed;

        public UnitOfWork(ProjectDbContext context)
        {
            _context = context;
        }
        public IVehicleDal Vehicles => _efVehicleDal ??= new EfVehicleDal(_context);

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
