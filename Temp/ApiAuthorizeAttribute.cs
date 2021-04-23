using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using CoreLib.ViewModels.Generic;
using CoreLib.Models.Accounts;
using System.Threading;
using System.Globalization;
using System.Net.Http.Headers;
using ReservationWeb.Content.Texts;
using System.Web;
using ReservationWeb.Models;
using System.Web.Http.Filters;

namespace ReservationWeb.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class GlobalExecutionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var UserId = HttpContext.Current.User.Identity.GetUserId();
            var db = new ApplicationDbContext();
            var user = db.Users.Find(UserId);

            if (user is Client)
            {
                var client = user as Client;
                var lang = "ar-SA";
                if (client.Language == Enums.Languages.English)
                {
                    lang = "en-US";
                }
                actionContext.Request.Headers.AcceptLanguage.Clear();
                actionContext.Request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(lang));
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }

           

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            
            

            //var users = new Logic.Users(new Database.Models.DBContext(), null);
            //var user = users.Find<ApplicationUser>(UserId);

            //if (user.Locked)
            //{
            //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden,
            //        new WebResult(new { IsBlocked = true }, HttpStatusCode.Forbidden, IsUserAuthenticated: false, Message: "غير مصرح بالوصول!"));
            //}
            //else
            //{
            //    base.OnAuthorization(actionContext);
            //}

            


            base.OnAuthorization(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden,
                new WebResult(new { IsBlocked = false }, HttpStatusCode.Forbidden, IsUserAuthenticated: false, Message: RMessages.Forbidden));
        }

        
    }
}