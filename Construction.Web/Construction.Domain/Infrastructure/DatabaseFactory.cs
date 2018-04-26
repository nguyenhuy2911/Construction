using System;

namespace Construction.Domain.Infrastructure
{
    public class DatabaseFactory : Disposable
    {
        private DatabaseContext dataContext;
        public DatabaseContext Get()
        {
            return dataContext ?? (dataContext = new DatabaseContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
