using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTest.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopTestDbContext dbContext;

        public ShopTestDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopTestDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
