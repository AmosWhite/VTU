using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.Repo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AmosVTU_Context _dbContext;
        
        public UnitOfWork(DbContextOptions<AmosVTU_Context> _option)
        {
            _dbContext = new AmosVTU_Context(_option);
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
