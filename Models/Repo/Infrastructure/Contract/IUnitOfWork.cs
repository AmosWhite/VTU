using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        DbContext Db { get; }
    }
}
