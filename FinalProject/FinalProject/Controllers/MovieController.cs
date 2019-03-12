using System.Web.Mvc;
using FinalProject.Service;

namespace FinalProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieHistoryService _service;

        public MovieController(IMovieHistoryService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Genre()
        {

            return View(_service.GetGenre());
        }

        public ActionResult Popular()
        {
            return View(_service.GetPopularMovies());
        }

        public ActionResult GenreMovieSelector(int id)
        {
            return View(_service.GetByGenre(id));
        }

        
    }
}