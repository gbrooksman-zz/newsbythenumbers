using System;

namespace newsbythenumbers
{
    public class ApiSettings
    {
        public ApiSettings(){}

         public string ApplicationName { get; set; } = "News by the Numbers";
         public int RecentDaysLookback { get; set; } = 15;
         public string DBName {get; set;} = "NewsByTheNumbers.db";
    }

}