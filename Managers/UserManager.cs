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

namespace newsbythenumbers.Managers
{

    public class UserManager : BaseManager
    {
        private IMemoryCache _cache;

        private ApiSettings _settings;

        private string dbname;
        public UserManager(IMemoryCache memoryCache, IOptions<ApiSettings> settings) 
                                    : base(memoryCache, settings)
        {
            _cache = memoryCache;
            _settings = settings.Value;
            dbname = _settings.DBName;
        }

        public User Save(User user)
        {
            using ( var db = new LiteDatabase(dbname))
            {
                var col = db.GetCollection<User>("users");

                if (user.Id == Guid.Empty)
                {
                    user.Id = Guid.NewGuid();
                    user.CreateDate = DateTime.Now;
                    user.IsActive = true;
                    col.Insert(user);
                }
                else
                { 
                    col.Update(user);
                }
            }

            return user;
        }

        public User Get(string username)
        {
            var user = new User();

            using ( var db = new LiteDatabase(dbname))
            {
                var col = db.GetCollection<User>("users");

                user = col.Find(u => u.UserName == username).FirstOrDefault();             
            }

            return user;
        }

        public bool TryLogin(User user)
        {
            bool ret = false;

            var sysUser = Get(user.UserName);

            if (sysUser != null)  return ret;

            if (sysUser.Password == user.Password) 
            {
                using ( var db = new LiteDatabase(dbname))
                {
                    var col = db.GetCollection<User>("users");
                
                    user.LastLoginDate = DateTime.Now;  

                    col.Update(user);      
                }

                ret = true;
            }

            return ret;
        }

        public bool AddInterest(User user)
        {
            using ( var db = new LiteDatabase(dbname))
            {
                var col = db.GetCollection<User>("users");
                
                user.InterestCount++;  

                col.Update(user);      
            }
            
            return true;
        }


        public bool AddView(User user)
        {
            using ( var db = new LiteDatabase(dbname))
            {
                var col = db.GetCollection<User>("users");
                
                user.ArticleViews++;  

                col.Update(user);      
            }
            
            return true;
        }


        public bool ToggleModerator(User user)
        {
            using ( var db = new LiteDatabase(dbname))
            {
                var col = db.GetCollection<User>("users");
                
                user.IsModerator = !user.IsModerator;  

                col.Update(user);      
            }
            
            return true;
        }


        

    }
}