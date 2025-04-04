using PryamolineynostWF.Models.Collimator;
using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.DTO.Collimator
{
    public class MeasurementTableModelDTO
    {
        public Plane Plane{ get; set; }
        public List<MeasurementRowModelDTO> Rows{ get; set; }
        public decimal? FirstMeanAngle_Horizontal{ get; set; }
        public decimal? FirstMeanAngle_Vertical{ get; set; }
        public decimal? LastRelativeAngleToFirstHorizontal{ get; set; }
        public decimal? LastRelativeAngleToFirstVertical{ get; set; }
        public int Step{ get; set; }
        public bool IsRevStrokeEnabled { get; set; }
    }
}
