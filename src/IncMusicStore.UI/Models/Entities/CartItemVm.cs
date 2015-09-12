namespace IncMusicStore.UI.Models
{
    #region << Using >>

    using IncMusicStore.Domain;

    #endregion

    public class CartItemVm
    {

        #region Properties

        public string Album { get; set; }

        public decimal Cost { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public string Id { get; set; }

        #endregion
    }
}