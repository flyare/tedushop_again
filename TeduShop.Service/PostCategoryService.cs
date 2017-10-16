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
        void Add(PostCategory T);

        void Update(PostCategory T);

        void Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void SaveChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private PostCategoryRepository _repository;
        private UnitOfWork _unitOfWork;

        public PostCategoryService(PostCategoryRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(PostCategory T)
        {
            _repository.Add(T);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
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