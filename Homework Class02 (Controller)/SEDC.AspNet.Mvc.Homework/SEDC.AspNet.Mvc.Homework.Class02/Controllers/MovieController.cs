using Microsoft.AspNetCore.Mvc;
using System;

namespace SEDC.AspNet.Mvc.Homework.Class02.Controllers
{
    [Route("homework")]
    public class MovieController : Controller
    {
        [HttpGet("movie/get-movies/{date}")]
        public IActionResult GetMovies(DateTime date)
        {
            return Json(new
            {
                DateTime = date.ToShortDateString()
            });
        }

        [HttpGet("movie/get-available/{isAvailable:bool}")]
        public IActionResult GetAvailable(bool isAvailable)
        {
            
            if (isAvailable)
            {
                return Ok("This movie is available");
            }
            else
            {
                return NotFound("This movie is not available");
            }
            
        }


    }
}
