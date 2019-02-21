using Actors.Helpers;
using Actors.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace Actors.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return PartialView();
		}

		public ActionResult All()
		{
			var actors = ActorsRepository.GetAllActors();
			return PartialView("Actors", actors);
		}

		public ActionResult Actresses()
		{
			var actresses = ActorsRepository.GetAllActors().Where(m => m.Gender == Enums.Gender.female.ToString());
			return PartialView("Actors", actresses);
		}

		public ActionResult Actors()
		{
			var actors = ActorsRepository.GetAllActors().Where(m => m.Gender == Enums.Gender.male.ToString());
			return PartialView("Actors", actors);
		}

		public ActionResult ActorInfo(int id)
		{
			var fullInfo = ActorsRepository.ActorInfo(id);

			return PartialView(fullInfo);
		}

		public ActionResult About()
		{
			return PartialView();
		}
	}
}