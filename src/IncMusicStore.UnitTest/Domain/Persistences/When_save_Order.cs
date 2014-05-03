namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(Order))]
    public class When_save_Order : SpecWithPersistenceSpecification<Order>
    {
        Because of = () => persistenceSpecification
                                   .CheckProperty(r => r.CreateDt, Pleasure.Generator.DateTime())
                                   .CheckProperty(r => r.PromoCode, Pleasure.Generator.String())
                                   .CheckProperty(r => r.PaymentInfo, Pleasure.Generator.Invent<PaymentInfo>())
                                   .CheckProperty(r => r.User, Pleasure.Generator.InventEntity<User>())
                                   .CheckProperty(r => r.Items, Pleasure.ToEnumerable(Pleasure.Generator.InventEntity<OrderItem>()), (order, item) => order.AddItem(item));

        It should_be_verify = () => persistenceSpecification.VerifyMappingAndSchema();
    }
}