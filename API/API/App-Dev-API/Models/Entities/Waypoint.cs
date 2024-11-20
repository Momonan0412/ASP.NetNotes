using System.ComponentModel.DataAnnotations;
using System.Drawing;
using AppDev.API.Models;

namespace AppDev.API.Models.Entities
{
    public class Waypoint
    {
        [Key]
        public Guid WaypointId { get; set; }
        [Required]
        [StringLength(200)]
        public string WaypointName { get; set; }
        [Required]
        [StringLength(200)]
        public string WaypointType { get; set; }
        [Required]
        public int PointX { get; set; }
        public int PointY { get; set; }
    }
}
