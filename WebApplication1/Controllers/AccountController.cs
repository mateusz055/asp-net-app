using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            if(avm.account.Username.Equals("admin")&& avm.account.Password.Equals("123"))
            {
                Session["username"] = avm.account.Username;
                return View("Welcome");
            }
            else
            {
                ViewBag.Error = "Account's Invalid";
                return View("Index");
            }
            
        }
        public ActionResult Conections()
        {
            Database database = new Database();
            database.OpenConnection();
            return View("Index");
        }

    }
    
}