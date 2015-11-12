using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5RealWorld.Models.EntityManager;
using MVC5RealWorld.Models.ViewModel;

namespace MVC5RealWorld.Controllers
{
  public class AccountController : Controller
  {
    // GET: Account
    //public ActionResult Index()
    //{
    //    return View();
    //}
    public ActionResult SignUp()
    {
      return View();
    }

    [HttpPost]
    public ActionResult SignUp(UserSignUpView USV)
    {
      if (ModelState.IsValid)
      {
        var UM = new UserManager();
        if (!UM.IsLoginNameExist(USV.LoginName))
        {
          UM.AddUserAccount(USV);
          FormsAuthentication.SetAuthCookie(USV.FirstName, false);
          return RedirectToAction("Welcome", "Home");
        }
        else
        {
          ModelState.AddModelError("", "Login Name already taken.");
        }
      }
      return View();
    }
  }
}