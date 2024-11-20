using AppDev.API.Models.DataTransferObject.Student;
using AppDev.API.Models.DataTransferObject.Waypoint;
using AppDev.API.Models.Entities;
using AppDev.API.Models;

namespace AppDev.API.Models.Mapper
{
    public class WaypointMapper
    {
        public static WaypointDTO ConvertToDTO(Waypoint waypoint)
        {
            return new WaypointDTO
            {
                WaypointName = waypoint.WaypointName,
                WaypointType = waypoint.WaypointType,
                PointX = waypoint.PointX,
                PointY = waypoint.PointY,
            };
        }

        public static Waypoint ConvertFromDTO(WaypointDTO dto)
        {
            return new Waypoint
            {
                WaypointName = dto.WaypointName,
                WaypointType = dto.WaypointType,
                PointX = dto.PointX,
                PointY = dto.PointY,
            };
        }
    }
}
