using IdeaApp.Entities.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaApp.UI.Controllers
{
    public class IdeasController : Controller
    {
        // GET: Ideas
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var client = new RestClient("https://localhost:44357/api/ideas/" + id);
            var request = new RestRequest(Method.GET);

            var idea = client.Get<Idea>(request);

            return View(idea.Data);
        }
    }
}