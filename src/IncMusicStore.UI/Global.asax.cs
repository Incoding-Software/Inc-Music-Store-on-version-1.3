﻿namespace IncMusicStore.UI
{
    #region << Using >>

    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using IncMusicStore.UI.App_Start;

    #endregion

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    ////ncrunch: no coverage start
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }

    ////ncrunch: no coverage end
}