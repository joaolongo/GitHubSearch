using AutoMapper;
using GithubSearch.Web.Core;
using GithubSearch.Web.Core.Models;
using GithubSearch.Web.Models;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GithubSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        private GitHubClient _github;
        private SearchDbContext _context;

        public HomeController()
        {
            _github = new GitHubClient(new ProductHeaderValue("GitHubSearch"));
            _context = new SearchDbContext();
        }

        public async Task<ActionResult> Index()
        {
            var results = await _github.Search.SearchRepo(new SearchRepositoriesRequest()
            {
                SortField = RepoSearchSort.Stars,
                Order = SortDirection.Descending,
                Updated = new DateRange(DateTime.Now.AddDays(-1), DateTime.Now)
            });

            ViewBag.Favorites = _context.Favorites.Select(x => x.RepoId).ToList();

            var viewModel = new List<GitHubViewModel>();

            foreach (var item in results.Items)
                viewModel.Add(Mapper.Map<GitHubViewModel>(item));

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(string text)
        {
            if (string.IsNullOrEmpty(text))
                return RedirectToAction("Index");

            var results = await _github.Search.SearchRepo(new SearchRepositoriesRequest(text)
            {
                SortField = RepoSearchSort.Stars,
                Order = SortDirection.Descending,
                Updated = new DateRange(DateTime.Now.AddDays(-1), DateTime.Now)
            });

            ViewBag.Favorites = _context.Favorites.Select(x => x.RepoId).ToList();

            var viewModel = new List<GitHubViewModel>();

            foreach (var item in results.Items)
                viewModel.Add(Mapper.Map<GitHubViewModel>(item));

            return View(viewModel);
        }

        public async Task<ActionResult> Details(long id)
        {
            var repo = await _github.Repository.Get(id);

            return View(Mapper.Map<GitHubViewModel>(repo));
        }

        public ActionResult Favorite(long id, bool fromFavorites = false)
        {
            if (_context.Favorites.All(x => x.RepoId != id))
                _context.Favorites.Add(new Favorite() { RepoId = id });
            else
                _context.Favorites.Remove(_context.Favorites.Single(x => x.RepoId == id));

            _context.SaveChanges();

            if (fromFavorites)
                return RedirectToAction("Favorites");
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Favorites()
        {
            var favorites = _context.Favorites.Select(x => x.RepoId).ToList();
            var viewModel = new List<GitHubViewModel>();

            foreach (var favorite in favorites)
            {
                var repo = await _github.Repository.Get(favorite);

                viewModel.Add(Mapper.Map<GitHubViewModel>(repo));
            }

            return View(viewModel);
        }
    }
}