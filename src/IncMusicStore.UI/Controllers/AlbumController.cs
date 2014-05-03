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

    public class AlbumController : IncControllerBase
    {
        #region Http action

        [HttpGet]
        public ActionResult Details(GetAlbumQuery query)
        {
            var vm = new AlbumDetailsVm(dispatcher.Query(query));
            return IncView(vm);
        }

        [HttpGet]
        public ActionResult FetchTopSelling()
        {
            var vms = dispatcher
                    .Query(new GetAlbumsTopSellingQuery())
                    .Select(r => new AlbumTopSellingVm(r))
                    .ToList();

            return IncJson(vms);
        }

        #endregion
    }
}