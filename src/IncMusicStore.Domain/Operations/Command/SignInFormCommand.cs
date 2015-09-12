namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Web;
    using System.Web.Security;
    using Incoding.CQRS;

    #endregion

    public class SignInFormCommand : CommandBase
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public bool Persistence { get; set; }

        public override void Execute()
        {
            const int countPersistence = 10;
            var expiration = Persistence ? DateTime.Now.AddDays(countPersistence) : DateTime.Now.AddMinutes(countPersistence);
            string encryptTick = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, Login, DateTime.Now, expiration, true, Id));

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTick);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}