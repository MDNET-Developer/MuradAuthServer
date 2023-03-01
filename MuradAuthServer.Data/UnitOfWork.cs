using MuradAuthServer.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void SaveCommit()
        {
            _context.SaveChanges();
        }

        public async Task SaveCommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
