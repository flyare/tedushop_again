using System;
using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory T);

        void Update(PostCategory T);

        PostCategory Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void SaveChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _repository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory T)
        {
            return _repository.Add(T);
        }

        public PostCategory Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _repository.GetAll().Where(p => p.ParentID == parentId && p.Status);
        }

        public PostCategory GetById(int id)
        {
            return _repository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory T)
        {
            _repository.Update(T);
        }
    }
}