using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllByTagPaging(int page, int pageSize, out int totalRow);
    }

    public class PostService : IPostService
    {
        IPostRepository _repository;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository repository, IUnitOfWork unitOfWork)
        {
            
        }

        public IEnumerable<Post> GetAllByTagPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }
    }
}
