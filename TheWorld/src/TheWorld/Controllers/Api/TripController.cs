using System.Linq;
using Microsoft.AspNet.Mvc;
using TheWorld.Entities;
using TheWorld.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld.Controllers.Api
{
    [Route("api/trips")]
    public class TripController : Controller
    {
        private readonly IRepository repository;

        public TripController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(repository.GetAllTrips().ToList());
        }

        [HttpPost]
        public JsonResult Post([FromBody]Trip trip)
        {
            return Json(true);
        }
    }
}
