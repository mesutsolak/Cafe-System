using CP.WebUI.App_Start;
using CP.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CP.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)      
        {
            var exception = Server.GetLastError(); //Oluþan hatayý deðiþkene atadýk.
                                                   //Eðer hata kaydý (log) tutulacak ise gerekli kodlar buraya.
            var httpException = exception as HttpException;
            Response.Clear();
            Server.ClearError(); //Sunucudaki hatayý temizledik.
            Response.TrySkipIisCustomErrors = true; //IIS'in tipik hata sayfalarýný görmezden geldik.
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error"; //Hata mesajlarýný yöneteceðimiz Controller ismi
            routeData.Values["action"] = "PageError"; //Controller içindeki default Action ismi
            routeData.Values["exception"] = exception;
            //Response.StatusCode = 500;

            if (httpException != null)
            {
                Response.StatusCode = httpException.GetHttpCode();

                switch (Response.StatusCode)
                {
                    case 403: //Eðer 403 hatasý meydana gelmiþ ise Http403 Action'ý devreye girecek.
                        routeData.Values["action"] = "Page403";
                        break;
                    case 404: //Eðer 404 hatasý meydana gelmiþ ise Http404 Action'ý devreye girecek.
                        routeData.Values["action"] = "Page404";
                        break;
                    case 401:
                        routeData.Values["Action"] = "Page401";
                        break;   
                    case 500:
                        routeData.Values["Action"] = "Page500";
                        break;
                }
            }

            IController errorsController = new Controllers.ErrorController();
            var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
            errorsController.Execute(rc);
        }

    }
}
