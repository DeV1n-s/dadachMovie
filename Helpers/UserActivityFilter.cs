using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dadachMovie.Helpers
{
    public class UserActivityFilter : IActionFilter
    {
        private readonly AppDbContext _dbContext;

        public UserActivityFilter(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userActivity = new UserActivity();
            userActivity.Data = "";

            var routeData = context.RouteData;
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];

            userActivity.Url = $"{controller}/{action}";

            if (!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                userActivity.Data = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                var arguments = context.ActionArguments;
                var value = arguments.FirstOrDefault().Value;
                var convertedValue = JsonConvert.SerializeObject(value);
                userActivity.Data = convertedValue;
            }

            userActivity.UserName = context.HttpContext.User.Identity.Name;
            userActivity.IpAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();

            var activities = UserActivities(userActivity.UserName);
            UserActivity exists;
            
            if (userActivity.UserName != null)
            {
                exists = activities.FirstOrDefault(x => x.Data == userActivity.Data && 
                                                x.Url == userActivity.Url);
            } else {
                exists = activities.FirstOrDefault(x => x.Data == userActivity.Data && 
                                                x.IpAddress == userActivity.IpAddress && 
                                                x.Url == userActivity.Url);
            }
            
            if (exists != null)
            {
                RemoveUserActivity(exists);
            }
            SaveUserActivity(userActivity);
        }

        public void SaveUserActivity(UserActivity userActivity)
        {
            _dbContext.UserActivities.Add(userActivity);
            _dbContext.SaveChanges();
        }

        public void RemoveUserActivity(UserActivity userActivity)
        {
            _dbContext.UserActivities.Remove(userActivity);
            _dbContext.SaveChanges();
        }

        public List<UserActivity> UserActivities(string userEmail)
        {
            return _dbContext.UserActivities.Where(x => x.UserName == userEmail).ToList();
        }
    }
}