using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {

    }
    public class FooterRepository : IRepositoryBase<Footer>, IFooterRepository
    {
        protected FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
