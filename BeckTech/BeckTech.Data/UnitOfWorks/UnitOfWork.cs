using BeckTech.Data.Context;
using BeckTech.Data.Repositories.Abtractions;
using BeckTech.Data.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BeckTechDbContext _context;
        public UnitOfWork(BeckTechDbContext dbContext)
        {
            this._context = dbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(_context);
        }
    }
}
