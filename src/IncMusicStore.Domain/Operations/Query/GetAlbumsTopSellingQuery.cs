namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using Incoding.CQRS;
    using Incoding.Data;

    #endregion

    public class GetAlbumsTopSellingQuery : QueryBase<List<GetAlbumsTopSellingQuery.Response>>
    {
        protected override List<Response> ExecuteResult()
        {
            return Repository
                    .Paginated(paginatedSpecification: new PaginatedSpecification(1, 10),                                        
                               orderSpecification: new AlbumByOrderItemCountOrderSpec())
                    .Items
                    .Select(album => new Response()
                                     {
                                             Id = album.Id.ToString(),
                                             Title = album.Title,
                                             ArtUrl = album.ArtUrl
                                     })
                    .ToList();
        }

        public class Response
        {
            public string Id { get; set; }

            public string ArtUrl { get; set; }

            public string Title { get; set; }
        }
    }
}