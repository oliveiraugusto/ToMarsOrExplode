using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToMarsOrExplode.Api.Models;
using ToMarsOrExplode.Core;
using Core = ToMarsOrExplode.Core;

namespace ToMarsOrExplode.Api.Controllers
{    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProbeController : Controller
    {
        public Grid Grid { get; set; }

        //GET api/v1/probe
        [HttpGet]
        public IActionResult Get([FromQuery] ProbeModel probe)
        {
            try
            {
                if(!string.IsNullOrEmpty(probe.cardinalPoint) || !string.IsNullOrEmpty(probe.command))
                {
                    int x = Convert.ToInt32(probe.xPoint);
                    int y = Convert.ToInt32(probe.yPoint);
                    var position = new Core.Position(x, y, probe.cardinalPoint);                   

                    var control = new Core.ProbeControl(position, Grid, probe.command);
                    control.ExecuteCommands();
                    return StatusCode(200, $"{probe.xPoint} {probe.yPoint} {probe.cardinalPoint}");
                }
                else
                {
                    return StatusCode(400, "ERROR: Cardinal Point and Command is Mandatory");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"ERROR: {ex.Message}");
            }                      
        }

        //POST api/v1/probe
        [HttpPost]
        public IActionResult Post([FromBody] GridModel grid)
        {
            if (grid.width > 0 || grid.height > 0)
            {
                Grid = new Grid(grid.width, grid.height);
                return StatusCode(200, $"{grid.width} {grid.height}");
            }                
            else
            {
                return StatusCode(400, "ERROR: wrong values");
            }            
        }
    }
}
