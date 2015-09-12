namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Linq;
    using Incoding.CQRS;

    #endregion

    public class GetAlbumQuery : QueryBase<GetAlbumQuery.Response>
    {
        #region Properties

        public string Id { get; set; }

        #endregion

        protected override Response ExecuteResult()
        {
            var album = Repository.Query(whereSpecification: new EntityByIdSpec<Album>(Id))
                                  .First();
            return new Response
                   {
                           Id = album.Id,
                           Title = album.Title,
                           Price = Dispatcher.Query(new FormatToMoneyQuery(album.Price)),
                           Genre = album.Genre.Name,
                           Artist = album.Artist.Name,
                           ArtUrl = album.ArtUrl
                   };
            ;
        }

        public class Response
        {
            #region Properties

            public string Artist { get; set; }

            public string Genre { get; set; }

            public string Price { get; set; }

            public string Title { get; set; }

            public string Id { get; set; }

            public string ArtUrl { get; set; }

            #endregion
        }
    }
}