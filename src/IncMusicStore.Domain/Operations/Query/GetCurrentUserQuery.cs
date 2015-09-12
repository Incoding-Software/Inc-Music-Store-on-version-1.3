namespace IncMusicStore.Domain
{
    using Incoding.CQRS;

    public class GetCurrentUserQuery : QueryBase<User>
    {
        protected override User ExecuteResult()
        {
            return Repository.LoadById<User>(Dispatcher.Query(new GetCookiesAsStringQuery()
                                                              {
                                                                      Key = Key,
                                                              }));
        }

        public const string Key = "UserId";
    }
}