using System;

namespace api.Models
{

    public class User
    {

        public User(){}

        public Guid Id {get; set;}

        public string UserName {get; set;}

        public string Password {get; set;}

        public DateTime CreateDate {get; set;}

        public DateTime LastLoginDate {get; set;}

        public int ArticleViews {get; set;}

        public int InterestCount {get; set;}

        public bool IsActive  {get; set;}

        public bool IsModerator {get; set;}



    }



}