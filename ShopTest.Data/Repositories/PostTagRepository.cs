﻿using ShopTest.Data.Infrastructure;
using ShopTest.Model.Models;
using TeduShop.Data.Infrastructure;

namespace ShopTest.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag>
    {
    }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}