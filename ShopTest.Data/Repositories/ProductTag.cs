﻿using ShopTest.Data.Infrastructure;
using ShopTest.Model.Models;
using TeduShop.Data.Infrastructure;

namespace ShopTest.Data.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}