using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CP.WebUI.Models
{
    public class AccessDeniedAuthorizeAttribute : AuthorizeAttribute
    {
        public string AccessDeniedViewName { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //Action'ın veya Controllerın Rolleri
            var roles = this.Roles;

            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated &&
                filterContext.Result is HttpUnauthorizedResult)
            {

                //controller yönlendirmw
                var request = filterContext.HttpContext.Request;
                var url = new UrlHelper(filterContext.RequestContext);


                var a=HttpContext.Current.Request.RequestContext.RouteData.Values["action"];
                var b=HttpContext.Current.Request.RequestContext.RouteData.Values["controller"];
                //string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                if (string.IsNullOrWhiteSpace(AccessDeniedViewName))
                    AccessDeniedViewName = "~/Base/AccessDenied?roles=" + roles;


                //filterContext.Result = new View("Deneme", roles);
                filterContext.Result = new RedirectResult(AccessDeniedViewName);
            }
        }
    }
}