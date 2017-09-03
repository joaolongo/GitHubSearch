using AutoMapper;
using GithubSearch.Web.Models;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubSearch.Web.App_Start
{
    public static class MapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Repository, GitHubViewModel>()
                .ForMember(member => member.Owner, map => map.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Owner = src.Owner.Name;
                    dest.OwnerId = src.Owner.Id;
                });

                cfg.CreateMap<IList<Repository>, IList<GitHubViewModel>>();
            });
        }
    }
}