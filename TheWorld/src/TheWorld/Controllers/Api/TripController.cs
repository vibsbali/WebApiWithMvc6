using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheWorld.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld.Controllers.Api
{
    public class TripController : Controller
    {
        private readonly IRepository repository;

        public TripController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("api/trips")]
        public JsonResult Get()
        {
            return Json(repository.GetAllTrips().ToList());
        }
    }
}
