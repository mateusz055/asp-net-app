using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using WebApplication1.Models;
using WebApplication1.ViewModels;

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
        public ActionResult sds()
        {
            Movie.GetMovieValue();
            return View("Moviesearch");
        }
        public ActionResult GetMovieInfo(MovieViewModel model)
        {
            string query = "SELECT id_filmu,tytul,opis,autor FROM filmy WHERE tytul='" + model.Movie + "';";

            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            Database DB = new Database();
            DB.OpenConnection();
            list = DB.MovieSelect(query);
            DB.CloseConnection();
            ViewBag.movieid = list[0][0];
            ViewBag.title = list[1][0];
            ViewBag.description = list[2][0];
            ViewBag.author = list[3][0];
            return View("Moviesearch");

        }


    }
}