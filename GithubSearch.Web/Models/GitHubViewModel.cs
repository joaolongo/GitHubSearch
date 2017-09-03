using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GithubSearch.Web.Models
{
    public class GitHubViewModel
    {
        [DisplayName("Erros Abertos")]
        public int OpenIssuesCount { get; set; }
        [DisplayName("Criação")]
        public DateTimeOffset CreatedAt { get; set; }
        [DisplayName("Última Atualização")]
        public DateTimeOffset UpdatedAt { get; set; }
        [DisplayName("Tem Wiki?")]
        public bool HasWiki { get; set; }
        [DisplayName("Permite Rebase Merge")]
        public bool? AllowRebaseMerge { get; set; }
        [DisplayName("Permite Squash Merge")]
        public bool? AllowSquashMerge { get; set; }
        [DisplayName("Permite Merge Commit")]
        public bool? AllowMergeCommit { get; set; }
        [DisplayName("Branch Default")]
        public string DefaultBranch { get; set; }
        [DisplayName("Total de Estrelas")]
        public int StargazersCount { get; set; }
        [DisplayName("Total de Forks")]
        public bool Fork { get; set; }
        [DisplayName("Total de Seguidores")]
        public int SubscribersCount { get; set; }
        [DisplayName("Url da API")]
        public string Url { get; set; }
        [DisplayName("Url padrão")]
        public string HtmlUrl { get; set; }
        [DisplayName("Clone (HTTP)")]
        public string CloneUrl { get; set; }
        [DisplayName("Url (SSH)")]
        public string SshUrl { get; set; }
        public long Id { get; set; }
        [DisplayName("ID do proprietário")]
        public int OwnerId { get; set; }
        [DisplayName("Proprietário")]
        public string Owner { get; set; }
        [DisplayName("Nome do Repositório")]
        public string Name { get; set; }
        [DisplayName("Nome Completo do Repositório")]
        public string FullName { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("HomePage")]
        public string Homepage { get; set; }
        [DisplayName("Linguagem")]
        public string Language { get; set; }
        [DisplayName("É Privado?")]
        public bool Private { get; set; }
        [DisplayName("Tamanho Total (KB)")]
        public long Size { get; set; }
    }
}