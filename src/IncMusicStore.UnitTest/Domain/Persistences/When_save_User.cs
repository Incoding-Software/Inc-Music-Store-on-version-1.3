namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(User))]
    public class When_save_User : SpecWithPersistenceSpecification<User>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.Email, Pleasure.Generator.String())
                                   .CheckProperty(r => r.Password, Pleasure.Generator.String())
                                   .CheckProperty(r => r.Cart, Pleasure.Generator.InventEntity<Cart>())
                                   .CheckProperty(r => r.Orders, Pleasure.ToEnumerable(Pleasure.Generator.InventEntity<Order>()), (user, order) => user.AddOrder(order))
                                   .CheckProperty(r => r.Name, Pleasure.Generator.Invent<FullName>());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}