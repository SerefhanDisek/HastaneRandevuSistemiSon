using Microsoft.AspNetCore.Identity;
using HastaneRandevuSistemiSon.Models;
namespace HastaneRandevuSistemiSon.Models
{
    public class ApplicationUser 
    {

        public string UserType { get; set; } 
        public int TotalSiteVisits { get; set; }
        public int TotalContentCount { get; set; }
        public int TotalUserCount { get; set; }

    }
}
