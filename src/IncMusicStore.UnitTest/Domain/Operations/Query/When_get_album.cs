namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using IncMusicStore.Domain;
    using Incoding.CQRS;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(GetAlbumQuery))]
    public class When_get_album
    {
        Establish establish = () =>
                              {
                                  var query = Pleasure.Generator.Invent<GetAlbumQuery>();
                                  expected = Pleasure.Generator.Invent<Album>();

                                  mockQuery = MockQuery<GetAlbumQuery, GetAlbumQuery.Response>
                                          .When(query)
                                          .StubQuery(whereSpecification: new EntityByIdSpec<Album>(query.Id),
                                                     entities: expected);
                              };

        Because of = () => mockQuery.Original.Execute();

        It should_be_result = () => mockQuery.ShouldBeIsResult(response => response.ShouldEqualWeak(expected));

        #region Estabilish value

        static MockMessage<GetAlbumQuery, GetAlbumQuery.Response> mockQuery;

        static Album expected;

        #endregion
    }
}