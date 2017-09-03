using GithubSearch.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GithubSearch.Web.Core
{
    public class SearchDbContext : DbContext
    {
        public SearchDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Favorite> Favorites {get; set;}
}
}