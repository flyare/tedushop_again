using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
    }

    public class PostRepository : IRepositoryBase<Post>, IPostRepository
    {
        protected PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}