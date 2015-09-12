namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Linq;
    using Incoding;
    using Incoding.CQRS;

    #endregion

    public class SignInUserCommand : CommandBase
    {
        public override void Execute()
        {
            var user = Repository
                    .Query(whereSpecification: new UserByCredentialWhereSpec(Email, Password))
                    .FirstOrDefault();

            if (user == null)
                throw IncWebException.ForServer("Please use correct email and password");

            Dispatcher.Push(new SignInFormCommand()
                            {
                                    Login = user.Email,
                                    Id = user.Id,
                                    Persistence = RememberMe
                            });
        }

        #region Properties

        public string Password { get; set; }

        public string Email { get; set; }

        public bool RememberMe { get; set; }

        #endregion
    }
}