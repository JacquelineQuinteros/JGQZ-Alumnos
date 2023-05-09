using JGQZ.ArqLimpia.EN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGQZ.ArqLimpia.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly JGQZDBContext dbContext;
        public UnitOfWork(JGQZDBContext pDbContext)
        {
            dbContext = pDbContext;
        }

        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
