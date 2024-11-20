using AppDev.API.Data;
using AppDev.API.Models.DataTransferObject.Waypoint;
using AppDev.API.Models.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AppDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaypointsController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public WaypointsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetAllWaypoints() { 
            return Ok(applicationDbContext.Waypoints.ToList());
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetWaypointById(Guid id) {
            var waypoint = applicationDbContext.Waypoints.Find(id);
            return waypoint is null ? NotFound() : Ok(waypoint);
        }
        [HttpPost]
        public IActionResult AddWaypoint(WaypointDTO waypointDTO) { 
            var newWaypoint = WaypointMapper.ConvertFromDTO(waypointDTO);
            applicationDbContext.Waypoints.Add(newWaypoint);
            applicationDbContext.SaveChanges();
            return CreatedAtAction(
                nameof(GetWaypointById),
                new { id = newWaypoint.WaypointId},
                newWaypoint
                );
        }
        [HttpPut("{id:guid}/update")]
        public IActionResult UpdateWaypoint(Guid id, WaypointDTO waypointDTO) {
            var waypoint = applicationDbContext.Waypoints.Find(id);
            if(waypoint is null) return NotFound();
            var updateWaypoint = WaypointMapper.ConvertFromDTO(waypointDTO);
            if (!string.IsNullOrEmpty(updateWaypoint.WaypointName))
            {

            }
            if (!string.IsNullOrEmpty(updateWaypoint.WaypointType))
            {

            }
            waypoint.PointX = updateWaypoint.PointX;
            waypoint.PointY = updateWaypoint.PointY;
            applicationDbContext.SaveChanges(); 
            return Ok(waypoint);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteWaypoint(Guid id) {
            var deleteWaypoint = applicationDbContext.Waypoints.Find(id);
            if(deleteWaypoint is null) return NotFound();
            applicationDbContext.Waypoints.Remove(deleteWaypoint);
            applicationDbContext.SaveChanges();
            return Ok();
        }
    }
}
