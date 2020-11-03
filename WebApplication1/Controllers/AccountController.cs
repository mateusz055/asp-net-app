using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{   
    
    public class AccountController : Controller
    {
        List<string>[] list = new List<string>[3];
        
        
            
        public ActionResult Index()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            Database db = new Database();
            db.OpenConnection();
            list=db.LoginSelect();
            db.CloseConnection();
            string login = string.Join("",list[1]);
            string pass = string.Join("",list[2]);


            if (avm.account.Username.Equals(login)&& avm.account.Password.Equals(pass))
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
    }
    
}