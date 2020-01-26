using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IdeaApp.DAL;
using IdeaApp.Entities.Models;

namespace IdeaApp.API.Controllers
{
    public class IdeasController: ApiController
    {
        [Route("api/ideas")]
        [HttpGet]
        public IEnumerable<Idea> Get()
        {
            DatabaseContext dbContext = new DatabaseContext();

            var ideaList = dbContext.Ideas.ToList();

            return ideaList;
        }

        [Route("api/ideas/{id}")]
        [HttpGet]
        public Idea Get(int id)
        {
            DatabaseContext dbContext = new DatabaseContext();

            var idea = dbContext.Ideas.Find(id);
            //or
            var idea1 = dbContext.Ideas.FirstOrDefault(p => p.Id == id);

            return idea;
        }
    }
}