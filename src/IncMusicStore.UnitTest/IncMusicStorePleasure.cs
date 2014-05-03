namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using System.Linq.Expressions;
    using System.Net;
    using IncMusicStore.Domain;
    using Incoding;
    using Incoding.Block.IoC;
    using Incoding.MSpecContrib;
    using Incoding.Extensions;
    using System.Linq;

    #endregion

    public static class IncMusicStorePleasure
    {
        #region Factory constructors

        public static void ShouldBeExceptionFor<T>(this IncWebException exception, Expression<Func<T, object>> prop, params string[] messages)
        {
            exception.Errors.ShouldBeKeyValue(prop.GetMemberNameAsHtmlId(), messages.ToList());
        }

        public static void ShouldBeExceptionFor(this IncWebException exception, string prop, params string[] messages)
        {
            exception.Errors.ShouldBeKeyValue(prop, messages.ToList());
        }

        public static string TheUserId()
        {
            const string userid = "userId";
            var sessionContext = Pleasure.MockStrictAsObject<ISessionContext>(mock => mock.SetupGet(r => r.UserId).Returns(userid));
            IoCFactory.Instance.StubTryResolve(sessionContext);
            return userid;
        }

        #endregion
    }
}