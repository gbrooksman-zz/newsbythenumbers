using System;

namespace api.Models
{

    public class Category
    {
        public Guid Id {get; set;}

        public string Name {get; set;}

        public int ArticleCount {get; set;}

        public DateTime LastArticleDate {get; set;}
    }
}