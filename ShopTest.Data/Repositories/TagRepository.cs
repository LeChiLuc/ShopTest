using ShopTest.Data.Infrastructure;
using ShopTest.Model.Models;
using TeduShop.Data.Infrastructure;

namespace ShopTest.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}