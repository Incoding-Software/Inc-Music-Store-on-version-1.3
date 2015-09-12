namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using System.Collections.ObjectModel;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;
    using Moq;
    using It = Machine.Specifications.It;

    #endregion

    [Subject(typeof(ApproveBasketCommand))]
    public class When_approve_cart
    {
        #region Estabilish value

        static MockMessage<ApproveBasketCommand, object> mockCommand;

        static Mock<User> user;

        static ReadOnlyCollection<Item> cartItems;

        #endregion

        Establish establish = () =>
                                  {
                                      var command = Pleasure.Generator.Invent<ApproveBasketCommand>();

                                      user = Pleasure.Mock<User>(mockUser =>
                                                                     {
                                                                         cartItems = Pleasure.ToReadOnly(Pleasure.Generator.Invent<Item>(dsl => dsl.GenerateTo<Album>(r => r.Album)));
                                                                         var cart = Pleasure.MockAsObject<Basket>(mockCart => mockCart.SetupGet(r => r.Items).Returns(cartItems));
                                                                         mockUser.SetupGet(r => r.Basket).Returns(cart);
                                                                     });

                                      mockCommand = MockCommand<ApproveBasketCommand>
                                              .When(command);

                                  };

        Because of = () => mockCommand.Original.Execute();

        It should_be_add_order = () =>
                                     {
                                         Action<Order> predicateOrderItem = order => order.Items.ShouldEqualWeakEach(cartItems, (dsl, i) => dsl.ForwardToValue(r => r.UnitPrice, cartItems[i].Album.Price)
                                                                                                                                               .ForwardToAction(r => r.Order, item => item.Order.ShouldNotBeNull()));
                                         Action<ICompareFactoryDsl<Order, ApproveBasketCommand>> predicateOrder = dsl => dsl.IgnoreBecauseRoot(r => r.User)
                                                                                                                          .ForwardToAction(r => r.Items, predicateOrderItem)
                                                                                                                          .ForwardToAction(r => r.PaymentInfo, order => order.PaymentInfo.ShouldEqualWeak(mockCommand.Original))
                                                                                                                          .ForwardToAction(r => r.CreateDt, order => order.CreateDt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-10)));
                                         user.Verify(r => r.AddOrder(Pleasure.MockIt.IsWeak(mockCommand.Original, predicateOrder)));
                                     };

        It should_be_new_cart = () => user.Verify(r => r.NewCart());
    }
}