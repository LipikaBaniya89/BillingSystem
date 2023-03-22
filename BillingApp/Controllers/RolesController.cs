using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;
using BusinessLogicLayer.RolesService;
namespace BillingApp.Controllers
{
    public class RolesController : Controller
    {
        RolesService roleSrv = new RolesService();
        
        // GET: Roles
        public ActionResult Index()
        {
            RoleInfoViewModel model = new RoleInfoViewModel();

            model.RoleList= roleSrv.GetRoles();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddRole ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(RoleInfoViewModel model)
        {
            roleSrv.AddRole(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditRole(long roleId)
        {
            RoleInfoViewModel model = new RoleInfoViewModel();
            model = roleSrv.GetRoleById(roleId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditRole(RoleInfoViewModel model)
        {
            roleSrv.EditRole(model);
            return RedirectToAction("Index");
        }


    }
}