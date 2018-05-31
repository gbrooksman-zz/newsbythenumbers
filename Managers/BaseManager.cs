using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteDB;
using api;
using api.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;


namespace newsbythenumbers.Managers
{
    public class BaseManager
    {
        private IMemoryCache _cache;

        public string ConnectionString = "NewsNumbers.db";

        private ApiSettings apiSettings { get; set; }

        public BaseManager(IMemoryCache memoryCache, IOptions<ApiSettings> settings )
        {
            _cache = memoryCache;
        }
    }
}