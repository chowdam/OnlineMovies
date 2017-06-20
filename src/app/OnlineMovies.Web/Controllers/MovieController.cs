using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineMovies.BL;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OnlineMovies.Web.Models;

namespace OnlineMovies.Web.Controllers
{
    public class MovieController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Movie
        public ActionResult Index()
        {
            //var moviesList = unitOfWork.MovieRepository.Get(includeProperties: "Movies_Review");

            //MoviesViewModel vm = new MoviesViewModel();
            //vm.MoviesVMs = unitOfWork.MovieRepository.Get().ToList();
            //vm.MovieReviewsVMs = unitOfWork.MovieReviewsRepository.Get().ToList();
            //return View(vm);

            //var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            //return View("Index", "", JsonConvert.SerializeObject(moviesList, Formatting.None, settings));

            return View();
        }


        public JsonResult GetMoviesJsonResult()
        {
            return new JsonResult
            {
                Data = unitOfWork.MovieRepository.Get().ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public JsonResult GetMovieReviewsByMovieId(int Id)
        {
            List<Movie_Reviews> reviews = unitOfWork.MovieReviewsRepository.Get().ToList();
            var movieReviews = from r in reviews
                               where r.MovieId == Id
                               select r;

            return new JsonResult
            {
                Data = movieReviews,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            @ViewBag.movie = movie.Name;
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);


        }

        // GET: Movie/Create
        [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            Movie movie = new Movie();
            try
            {
                // TODO: Add insert logic here


                if (ModelState.IsValid)
                {

                    // movie.Id = Convert.ToInt32(Request.Form["Id"]);
                    movie.Name = Request.Form["Name"];
                    movie.Description = Request.Form["Description"];
                    DateTime dtReleased = DateTime.ParseExact(Request.Form["ReleaseDate"], "mm/dd/yyyy", CultureInfo.InvariantCulture);
                    movie.ReleaseDate = dtReleased;
                    movie.Rating = Convert.ToInt32(Request.Form["Rating"]);
                    movie.IsReleased = dtReleased < DateTime.Today ? true : false;


                    unitOfWork.MovieRepository.Insert(movie);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");

            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);

            return View(movie);

        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Movie movie = new Movie();
            try
            {
                // TODO: Add insert logic here


                if (ModelState.IsValid)
                {

                    // movie.Id = Convert.ToInt32(Request.Form["Id"]);
                    movie.Name = Request.Form["Name"];
                    movie.Description = Request.Form["Description"];
                    DateTime dtReleased = Convert.ToDateTime(Request.Form["ReleaseDate"]);
                    movie.ReleaseDate = dtReleased;
                    movie.Rating = Convert.ToInt32(Request.Form["Rating"]);
                    movie.IsReleased = dtReleased < DateTime.Today ? true : false;

                    unitOfWork.MovieRepository.Update(movie);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");

            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Movie movie = unitOfWork.MovieRepository.GetByID(id);
            try
            {
                // TODO: Add delete logic here
                unitOfWork.MovieRepository.Delete(movie);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");

            }
            return View(movie);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
