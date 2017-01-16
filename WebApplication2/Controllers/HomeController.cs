using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GoalCreation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GoalCreation(GoalItem model)
        {
            DataProvider provider = new DataProvider();
            provider.AddGoalToList(model);

            IEnumerable<GoalItem> listToView = provider.GetSavedGoalItems();
            return View("GoalsList", listToView);
        }
    }
}