using System;

namespace newsbythenumbers.Models
{

    public class Article
    {
        public Article(){}

        public Guid Id {get; set;}

        public string Title {get; set;}

        public string Body {get; set;}

        public string SourceURL {get; set;}

        public int ViewCount {get; set;}

        public int Interests {get; set;}

        public int CategoryId {get; set;}

        public DateTime DateStamp {get; set;}

        public string ImageURL {get; set;}

    }





}