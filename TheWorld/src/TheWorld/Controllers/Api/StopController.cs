using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using TheWorld.Entities;
using TheWorld.Repository;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Api
{
    [Route("api/trips/{tripName}/stop")]
    public class StopController : Controller
    {
        private IRepository repository;

        public StopController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get(string tripName)
        {
            try
            {
                var results = repository.GetAllTripsWithStops()
                                        .Where(t => t.Name == tripName)
                                        .SelectMany(t => t.Stops)
                                        .OrderBy(s => s.Order)
                                        .ToList();

                var resultsViewModel = Mapper.Map<IEnumerable<StopViewModel>>(results);
                return Json(resultsViewModel);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }
        }

        public JsonResult Post(string tripName, [FromBody] StopViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStop = Mapper.Map<Stop>(model);

                    repository.AddStop(tripName, newStop);
                    if (repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(true);
                    }

                    return Json(true);
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }
        }
    }
}
