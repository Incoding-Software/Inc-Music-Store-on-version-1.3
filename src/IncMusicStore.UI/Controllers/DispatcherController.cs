namespace IncMusicStore.UI.Controllers
{
    using IncMusicStore.Domain;
    using Incoding.MvcContrib.MVD;    
	
    public class DispatcherController : DispatcherControllerBase
    {
        public DispatcherController()
                : base(typeof(Bootstrapper).Assembly) { }
    }
}