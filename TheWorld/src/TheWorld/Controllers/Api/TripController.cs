using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using TheWorld.Entities;
using TheWorld.Repository;
using TheWorld.ViewModels;

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
            var results = repository.GetAllTripsWithStops().ToList();
            //Notice the use of IEnumberable<T>
            var mappedResults = Mapper.Map<IEnumerable<TripViewModel>>(results);
            return Json(mappedResults);
        }

        [HttpPost]
        public JsonResult Post([FromBody]TripViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = Mapper.Map<Trip>(vm);
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }
            

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json(new {Message = "failed", ModelState = ModelState});
        }
    }
}
