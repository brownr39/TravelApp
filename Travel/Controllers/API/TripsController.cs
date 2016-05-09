using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Travel.ViewModels;
using Travel.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Travel.Controllers.API
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var trip = db.Trip.Include(s => s.Stop);
            var result = Mapper.Map<IEnumerable<TripViewModel>>(trip);
            return Json(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var trip = db.Trip.Include(a => a.Stop).Where(a => a.ID == id).Single();
            var result = Mapper.Map<Trip>(trip);
            return Json(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
