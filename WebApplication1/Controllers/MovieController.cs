using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        List<string>[] list = new List<string>[4];
        // GET: Movie
        public ActionResult moviesearch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetMovieInfo()
        {
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            Database DB = new Database();
            DB.OpenConnection();
            list = DB.MovieSelect();
            DB.CloseConnection();
            MessageBox.Show("FDSFFDSasd");
            return View("Moviesearch");
        }


    }
}