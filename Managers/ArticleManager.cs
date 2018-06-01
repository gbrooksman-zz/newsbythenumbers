using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteDB;
using api.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using newsbythenumbers.Models;

namespace newsbythenumbers.Managers
{
    public class ArticleManager : BaseManager , IArticleManager
    {
        private IMemoryCache _cache;
        private ApiSettings _settings;

        private string dbname;
        public ArticleManager(IMemoryCache memoryCache, IOptions<ApiSettings> settings) 
                                    : base(memoryCache, settings)
        {
            _cache = memoryCache;
            _settings = settings.Value;
            dbname = _settings.DBName;
        }

        public async Task <List<Article>> GetCategory(int categoryid)
         {
            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(dbname))
                {
                    var col = db.GetCollection<Article>("articles");

                   return col.Find(a => a.CategoryId == categoryid 
                                    && a.DateStamp > DateTime.Now.AddDays(-1)).ToList();
                } 
            });
         }

        public async Task<List<Article>> GetLatest()
        {
            List<Article> articles = new  List<Article> ();

            int daysDiff = -_settings.RecentDaysLookback;

            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(dbname))
                {
                    var col = db.GetCollection<Article>("articles");

                   return col.Find(a => a.DateStamp > DateTime.Now.AddDays(daysDiff)).ToList();
                } 
            });            
        }

        public  async Task<Article> GetOne(Guid guid)
         {
            return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(dbname))
                { 
                   var col = db.GetCollection<Article>("articles");

                   var article =  new Article(); //col.Find(a => a.Id == guid).FirstOrDefault();

                    article.Id = guid;

                    article.Title = "The title";

                    article.Body = "This is the body";

                   return article;
                } 
            });        
         }
    }
}