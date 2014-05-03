namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(Cart))]
    public class When_save_Cart : SpecWithPersistenceSpecification<Cart>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.User, Pleasure.Generator.InventEntity<User>())
                                   .CheckProperty(r => r.Items, Pleasure.ToEnumerable(Pleasure.Generator.InventEntity<CartItem>()), (cart, item) => cart.AddItem(item));

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}