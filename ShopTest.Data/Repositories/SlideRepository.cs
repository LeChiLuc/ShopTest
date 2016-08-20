using ShopTest.Data.Infrastructure;
using ShopTest.Model.Models;
using TeduShop.Data.Infrastructure;

namespace ShopTest.Data.Repositories
{
    public interface ISlideRepository : IRepository<Slide>
    {
    }

    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}