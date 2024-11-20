using System.ComponentModel.DataAnnotations;
using System.Drawing;
using AppDev.API.Models;

namespace AppDev.API.Models.DataTransferObject.Waypoint
{
    public class WaypointDTO
    {
        [Required]
        [StringLength(200)]
        public string WaypointName { get; set; }
        [Required]
        [StringLength(200)]
        public string WaypointType { get; set; }
        [Required]
        public int PointX { get; set; }
        [Required]
        public int PointY { get; set; }

        public override string ToString()
        {
            return $"User: WaypointName = {WaypointName}, WaypointType = {WaypointType}, Waypoint Coordinates = {PointX}, {PointY}";
        }
    }
}
