namespace IncMusicStore.Domain
{
    #region << Using >>

    using Incoding.CQRS;

    #endregion

    public class AddCartItemCommand : CommandBase
    {
        public override void Execute()
        {
            var user = Dispatcher.Query(new GetCurrentUserQuery());
            var album = Repository.GetById<Album>(AlbumId);

            user.Basket.AddItem(new Item(album, Quantity));
        }

        #region Properties

        public string AlbumId { get; set; }

        public int Quantity { get; set; }

        #endregion
    }
}