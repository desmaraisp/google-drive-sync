using System;
using System.Threading;
using Microsoft.CodeAnalysis;

namespace KPSyncForDrive
{
    public interface IDatabaseContextAccessor
    {
        Optional<DatabaseContext> DatabaseContext { get; set; }
        DatabaseContext GetDatabaseContext();
    }
    public class DatabaseContextAccessor : IDatabaseContextAccessor
    {
        private static readonly AsyncLocal<DatabaseContextHolder> _databaseContextCurrent = new AsyncLocal<DatabaseContextHolder>();

        public Optional<DatabaseContext> DatabaseContext
        {
            get
            {
                return _databaseContextCurrent.Value.Context;
            }
            set
            {
                var holder = _databaseContextCurrent.Value;
                if (holder != null)
                {
                    // Clear current HttpContext trapped in the AsyncLocals, as its done.
                    holder.Context = null;
                }

                if (value.HasValue)
                {
                    // Use an object indirection to hold the HttpContext in the AsyncLocal,
                    // so it can be cleared in all ExecutionContexts when its cleared.
                    _databaseContextCurrent.Value = new DatabaseContextHolder { Context = value };
                }
            }
        }

        public DatabaseContext GetDatabaseContext()
        {
            if (DatabaseContext.HasValue)
            {
                return DatabaseContext.Value;
            }
            throw new InvalidOperationException("Database context was not initialized");
        }
        private sealed class DatabaseContextHolder
        {
            public Optional<DatabaseContext> Context;
        }

    }
}
