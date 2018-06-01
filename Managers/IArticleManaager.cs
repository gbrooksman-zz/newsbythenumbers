using System.Collections.Generic;
using System.Threading.Tasks;
using newsbythenumbers.Models;
using System;

namespace newsbythenumbers.Managers
{
    public interface IArticleManager
    {
        Task<List<Article>> GetCategory(int categoryid);
        Task<List<Article>> GetLatest();
        Task<Article> GetOne(Guid guid);

    }
}