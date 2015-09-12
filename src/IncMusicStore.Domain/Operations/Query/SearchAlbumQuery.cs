namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using Incoding.CQRS;
    using Incoding.Extensions;

    #endregion

    public class SearchAlbumQuery : QueryBase<List<SearchAlbumQuery.Response>>
    {
        protected override List<Response> ExecuteResult()
        {
            return Repository
                    .Query(whereSpecification: new AlbumContainsTitleOptWhereSpec(this.Title)
                                   .And(new AblumInArtistsOptWhereSpec(ArtistIds))
                                   .And(new AlbumInGenresOptWhereSpec(GenreIds)))
                    .ToList()
                    .Select(album => new Response()
                                     {
                                             Artist = album.Artist.Name,
                                             Genre = album.Genre.Name,
                                             Price = Dispatcher.Query(new FormatToMoneyQuery(album.Price)),
                                             Title = album.Title
                                     })
                    .ToList();
        }

        public class Response
        {
            public string Title { get; set; }

            public string Genre { get; set; }

            public string Artist { get; set; }

            public string Price { get; set; }
        }

        #region Properties

        public string[] GenreIds { get; set; }

        public string[] ArtistIds { get; set; }

        public string Title { get; set; }

        #endregion
    }
}