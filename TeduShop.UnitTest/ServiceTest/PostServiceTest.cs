using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeduShop.Data.Repositories;
using TeduShop.Data.Infrastructure;
using TeduShop.Service;
using TeduShop.Model.Models;
using Moq;
using System.Collections.Generic;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostServiceTest
    {
        private Mock<IPostRepository> _mockRepository;
        private Mock<IUnitOfWork> _morkUnitOfWork;
        private IPostService _postService;
        private List<Post> _listPost;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostRepository>();
            _morkUnitOfWork = new Mock<IUnitOfWork>();
            _postService = new PostService(_mockRepository.Object, _morkUnitOfWork.Object);
            _listPost = new List<Post>()
            {
                new Post() {ID = 1, Name = "Post1", Alias = "Post1", Content = "Test", Status = true },
                new Post() {ID = 2, Name = "Post1", Alias = "Post1", Content = "Test", Status = true },
                new Post() {ID = 3, Name = "Post1", Alias = "Post1", Content = "Test", Status = true },
                //new Post() {ID = 4, Name = "Post1", Alias = "Post1", Content = "Test", Status = true },
                //new Post() {ID = 5, Name = "Post1", Alias = "Post1", Content = "Test", Status = true },
                //new Post() {ID = 6, Name = "Post1", Alias = "Post1", Content = "Test", Status = true },
            };
        }

        [TestMethod]
        public void Post_Service_All_Paging_Test()
        {
            int total = 1;
            int total1 = 2;
            _mockRepository.Setup(m => m.GetMultiPaging(x => x.Status, out total, 0, 3, null)).Returns(_listPost);

            var reult = _postService.GetAllPaging(0, 3, out total1);

            Assert.AreEqual(3, _listPost.Count);            
        }

        [TestMethod]
        public void Post_Service_Get_By_Id_Test()
        {
            var post = new Post { ID = 1, Name = "Post1" };
            _mockRepository.Setup(m => m.GetSingleById(It.IsAny<int>())).Returns(post);

            var result = _postService.GetPostById(1);

            Assert.AreEqual(1, result.ID);
        }
    }
}
