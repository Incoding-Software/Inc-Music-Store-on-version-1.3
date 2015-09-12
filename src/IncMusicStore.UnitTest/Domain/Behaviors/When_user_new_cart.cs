namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(User))]
    public class When_user_new_cart
    {
        #region Estabilish value

        static User original;

        static Basket oldBasket;

        #endregion

        Establish establish = () =>
                                  {
                                      oldBasket = Pleasure.Generator.Invent<Basket>(dsl => dsl.Callback(cart => cart.AddItem(Pleasure.Generator.Invent<Item>())));
                                      original = Pleasure.Generator.Invent<User>(dsl => dsl.Tuning(r => r.Basket, oldBasket));
                                  };

        Because of = () => original.NewCart();

        It should_not_be_old_cart = () => original.Basket.IsEqualWeak(oldBasket).ShouldBeFalse();

        It should_be_new_cart = () => original.Basket.ShouldEqualWeak(new
                                                                        {
                                                                                Items = Pleasure.ToReadOnly<Item>(), 
                                                                        }, dsl => dsl.IgnoreBecauseNotUse(r => r.User));
    }
}