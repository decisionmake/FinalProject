using System.Web.Mvc;
using FinalProject.DAL;
using FinalProject.Service;

namespace FinalProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieHistoryService _service;
        private MovieVotingHistoryDbContext db = new MovieVotingHistoryDbContext();
        public MovieController(IMovieHistoryService service)
        {
           
            _service = service;
        }

        public ActionResult Index()
        {
            Session.Clear();
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