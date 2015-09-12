namespace IncMusicStore.UI
{
    #region << Using >>

    using System;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using Incoding.Block.IoC;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    #endregion

    ////ncrunch: no coverage start
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IncMusicStoreAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var dispatcher = IoCFactory.Instance.TryResolve<IDispatcher>();
            if (dispatcher.Query(new IsAuthorizationUserQuery()))
                return;

            dispatcher.Push(new SignOutUserCommand());
            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var urlHelper = new UrlHelper(filterContext.RequestContext);

            string url = urlHelper.Action("SignIn", "Account");
            filterContext.Result = filterContext.RequestContext.HttpContext.Request.IsAjaxRequest()
                                           ? (ActionResult)IncodingResult.RedirectTo(url)
                                           : new RedirectResult(url);
        }
    }

    ////ncrunch: no coverage end
}