namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Incoding;
    using Incoding.CQRS;

    #endregion

    public class GetBasketItemsQuery : QueryBase<List<GetBasketItemsQuery.Response>>
    {
        public string Id { get; set; }

        protected override List<Response> ExecuteResult()
        {
            return Repository.Query(whereSpecification: new BasketItemByUserWhereSpec(Dispatcher.Query(new GetCookiesAsStringQuery()
                                                                                                       {
                                                                                                               Key = GetCurrentUserQuery.Key
                                                                                                       })))
                             .Select(item => new Response()
                                             { })
                             .ToList();
        }

        public class Response { }
    }

    public class BasketItemByUserWhereSpec : Specification<Item>
    {
        readonly string userId;

        public BasketItemByUserWhereSpec(string userId)
        {
            this.userId = userId;
        }

        public override Expression<Func<Item, bool>> IsSatisfiedBy()
        {
            return item => item.Basket.User.Id == userId;
        }
    }
}