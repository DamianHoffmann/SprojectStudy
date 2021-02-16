using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;



namespace Repository
{
    public interface IApplicationDbContext : IDisposable
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
    }
}
