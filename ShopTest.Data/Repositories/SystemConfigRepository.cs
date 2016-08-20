using ShopTest.Data.Infrastructure;
using ShopTest.Model.Models;
using TeduShop.Data.Infrastructure;

namespace ShopTest.Data.Repositories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig>
    {
    }

    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}