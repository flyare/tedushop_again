using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _morkUnitOfWork;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _listPostCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _morkUnitOfWork = new Mock<IUnitOfWork>();
            _postCategoryService = new PostCategoryService(_mockRepository.Object, _morkUnitOfWork.Object);

            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory { ID = 1, Name = "Category 1", Status = true },
                new PostCategory { ID = 2, Name = "Category 1", Status = true },
                new PostCategory { ID = 3, Name = "Category 1", Status = true },
                new PostCategory { ID = 4, Name = "Category 1", Status = true },
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //Set up repository first
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listPostCategory);

            //Call service
            var result = _postCategoryService.GetAll();

            //Compare
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void PostCategory_Service_Add()
        {
            var testAdd = new PostCategory { Name = "Category1", Status = true };
            _mockRepository.Setup(m => m.Add(testAdd)).Returns(
                (PostCategory p) =>
                {
                    p.ID = 1; return p;
                });

            var result = _postCategoryService.Add(testAdd);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}