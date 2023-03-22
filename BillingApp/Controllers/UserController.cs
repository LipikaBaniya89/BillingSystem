using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;
using BusinessLogicLayer.UsersService;

namespace BillingApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UsersService userSrv = new UsersService();

        public ActionResult Index()
        {
            UserViewModel model = new UserViewModel();

            model.UserList = userSrv.GetUsers();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUser(UserViewModel user)
        {
            userSrv.AddUser(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditUser(long UserId)
        {
            UserViewModel userModel = new UserViewModel();
            userModel = userSrv.GetUserById(UserId);
            return View(userModel);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel model)
        {
            userSrv.EditUser(model);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult DeleteUser(long UserId)
        {
            userSrv.DeleteUserById(UserId);
            return RedirectToAction("Index");

        }

        public JsonResult GetUserById(long UserId)
        {
            var data = userSrv.GetUserById(UserId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void DeleteUserById(long UserId)
        {
            userSrv.DeleteUserById(UserId);

        }

    }
}
