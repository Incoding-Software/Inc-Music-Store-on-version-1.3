namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(SignInUserCommand))]
    public class When_sign_in_user_with_wrong_credential
    {
        Establish establish = () =>
                              {
                                  var command = Pleasure.Generator.Invent<SignInUserCommand>();

                                  mockCommand = MockCommand<SignInUserCommand>
                                          .When(command);
                              };

        Because of = () => { exception = Catch.Exception(() => mockCommand.Original.Execute()) as IncWebException; };

        It should_be_exception = () => exception.Message.ShouldEqual("Please use correct email and password");

        #region Estabilish value

        static MockMessage<SignInUserCommand, object> mockCommand;

        static IncWebException exception;

        #endregion
    }
}