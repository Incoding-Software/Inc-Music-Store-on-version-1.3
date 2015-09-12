namespace IncMusicStore.UI.Controllers
{
    #region << Using >>

    using System.Linq;
    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using IncMusicStore.UI.Models;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    #endregion

    [IncMusicStoreAuthorize]
    public class CartController : IncControllerBase
    {
        #region Http action

        [HttpGet]
        public ActionResult AddItem(AddCartItemCommand input)
        {
            /*            if (!ModelState.IsValid)
                return IncodingResult.Error(ModelState);

            try
            {
                this.dispatcher.Push(input);
                return IncodingResult.Success();
            }
            catch (IncWebException incWebException)
            {
                ModelState.AddModelError(incWebException.Property, incWebException.Message);
                return IncodingResult.Error(ModelState);
            }*/
            return TryPush(input); // above show how it work in depth
        }


        [HttpPost]
        public ActionResult Approve(ApproveBasketCommand input)
        {
            return TryPush(input); // above show how it work in depth
        }



        #endregion
    }
}