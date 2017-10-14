using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    {
    }

    public class PageRepository : IRepositoryBase<Page>, IPageRepository
    {
        protected PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}