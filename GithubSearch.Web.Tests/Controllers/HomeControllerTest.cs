using System;
using GithubSearch.Web.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Mvc;
using GithubSearch.Web.Controllers;

namespace GithubSearch.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;

        public HomeControllerTest()
        {
            MapperConfig.Config();

            _controller = new HomeController();
        }

        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();

            var result = Task.Run(() => controller.Index()).Result as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            var result = Task.Run(() => _controller.Details(7528679)).Result as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FavoriteFromIndex()
        {
            Task.Run(() => _controller.Favorite(7528679));
        }

        [TestMethod]
        public void FavoriteFromFavorites()
        {
            Task.Run(() => _controller.Favorite(7528679, true));
        }

        [TestMethod]
        public void Favorites()
        {
            var result = Task.Run(() => _controller.Favorites()).Result as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
