namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using FluentNHibernate.Testing;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(Item))]
    public class When_save_CartItem : SpecWithPersistenceSpecification<Item>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.Quantity, Pleasure.Generator.PositiveNumber())
                                   .CheckProperty(r => r.Album, Pleasure.Generator.InventEntity<Album>())
                                   .CheckProperty(r => r.Basket, Pleasure.Generator.InventEntity<Basket>());

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}