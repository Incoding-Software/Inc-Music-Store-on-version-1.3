namespace IncMusicStore.UI.Controllers
{
    #region << Using >>

    using System.Web.Mvc;
    using IncMusicStore.Domain;
    using Incoding.MvcContrib;

    #endregion

    public class AccountController : IncControllerBase
    {
        #region Http action

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInUserCommand input)
        {
            return TryPush(input, setting => { setting.SuccessResult = () => RedirectToAction("Index", "Home"); });
        }

        [HttpPost]
        public ActionResult SignUp(SignUpUserCommand input)
        {
            return TryPush(input, setting => { setting.SuccessResult = () => RedirectToAction("SignIn", "Account"); });
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        #endregion
    }
}