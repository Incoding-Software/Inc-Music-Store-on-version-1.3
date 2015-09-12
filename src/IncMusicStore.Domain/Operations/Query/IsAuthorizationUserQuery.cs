namespace IncMusicStore.Domain
{
    using System.Web;
    using Incoding.CQRS;

    public class IsAuthorizationUserQuery : QueryBase<IncBoolResponse>
    {
        protected override IncBoolResponse ExecuteResult()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated &&
                   Dispatcher.Query(new GetCurrentUserQuery()) != null;
        }
    }
}