namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Incoding.CQRS;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class ApproveBasketCommand : CommandBase
    {
        public class GetById : QueryBase<ApproveBasketCommand>
        {
            protected override ApproveBasketCommand ExecuteResult()
            {
                var userId = Dispatcher.Query(new GetCookiesAsStringQuery()
                                              {
                                                      Key = GetCurrentUserQuery.Key
                                              });
                var car = Repository.Query(whereSpecification: new CartByUserWhereSpec(userId))
                                    .First();
                return new ApproveBasketCommand()
                       {
                               CartId = car.Id,
                               Items = car.Items.Select(r => new ApproveCartItemSubCommand(r))
                                          .ToArray()
                       };
            }
        }


        #region Properties

        public ApproveCartItemSubCommand[] Items { get; set; }

        public string PromoCode { get; set; }

        public string CartId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        #endregion

        #region Nested classes

        public class ApproveCartItemSubCommand
        {
            #region Constructors

            public ApproveCartItemSubCommand(Item item)
            {
                Album = item.Album.Title;
                Quantity = item.Quantity.ToString();
            }

            #endregion

            #region Properties

            public string Quantity { get; set; }

            public string Album { get; set; }

            #endregion
        }

        #endregion

        public override void Execute()
        {
            var user = Dispatcher.Query(new GetCurrentUserQuery());

            var order = new Order(PromoCode, new PaymentInfo
                                                 {
                                                         Address = Address, 
                                                         City = City, 
                                                         Country = Country, 
                                                         Phone = Phone, 
                                                         PostalCode = PostalCode, 
                                                         State = State, 
                                                 });
            foreach (var orderItem in user.Basket.Items.Select(r => new OrderItem(r)))
                order.AddItem(orderItem);
            user.AddOrder(order);

            user.NewCart();
        }
    }
}