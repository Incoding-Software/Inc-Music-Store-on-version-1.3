namespace IncMusicStore.Domain
{
    using System.Collections.Generic;
    using Incoding.CQRS;

    public class GetGenresQuery : QueryBase<List<GetGenresQuery.Response>>
    {
        public class Response
        {

            public string Name { get; set; }

            public string Id { get; set; }
        }

        protected override List<Response> ExecuteResult()
        {
            throw new System.NotImplementedException();
        }
    }
}