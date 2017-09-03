using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubSearch.Web.Core.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public long RepoId { get; set; }
    }
}