using System;
using System.Data.Entity;

namespace Library.Data.Context
{
    public interface IDataContext : IDisposable
    {
        bool AutoDetectChangesEnabled { get; set; }

        int SaveChanges();

        void DetectChanges();

        DbSet<T> Set<T>() where T : class;
    }
}
