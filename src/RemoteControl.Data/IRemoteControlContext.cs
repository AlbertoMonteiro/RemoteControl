using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using RemoteControl.Core.Models;

namespace RemoteControl.Data
{
    internal interface IRemoteControlContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Database Database { get; }
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        DbSet<Machine> Machines { get; }
    }
}