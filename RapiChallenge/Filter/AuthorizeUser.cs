using Newtonsoft.Json;
using RapiChallenge.BusinessLogic;
using RapiChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapiChallenge.Filter
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private string roles;
        public AuthorizeUser(string Roles= "")
        {
            this.roles = Roles;
        }
        

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                var rolActual = HttpContext.Current.Session["Rol"].ToString();

                if (rolActual != roles)
                {
                    filterContext.Result = new RedirectResult("~/Error");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error");
            }
        }
    }
}