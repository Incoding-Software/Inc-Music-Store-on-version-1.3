namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System.Collections.Generic;
    using IncMusicStore.Domain;
    using Incoding.Extensions;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(SearchAlbumQuery))]
    public class When_search_album
    {
        Establish establish = () =>
                              {
                                  var query = Pleasure.Generator.Invent<SearchAlbumQuery>();
                                  expected = Pleasure.ToList(Pleasure.Generator.Invent<Album>());

                                  mockQuery = MockQuery<SearchAlbumQuery, List<SearchAlbumQuery.Response>>
                                          .When(query)
                                          .StubQuery(whereSpecification: new AlbumContainsTitleOptWhereSpec(query.Title)
                                                             .And(new AblumInArtistsOptWhereSpec(query.ArtistIds))
                                                             .And(new AlbumInGenresOptWhereSpec(query.GenreIds)),
                                                     entities: expected.ToArray());
                              };

        Because of = () => mockQuery.Original.Execute();

        It should_be_result = () => mockQuery.ShouldBeIsResult(list => list.ShouldEqualWeakEach(expected));

        #region Estabilish value

        static MockMessage<SearchAlbumQuery, List<SearchAlbumQuery.Response>> mockQuery;

        static List<Album> expected;

        #endregion
    }
}