using PryamolineynostWF.Enums;
namespace PryamolineynostWF.DTO.Collimator
{
    public class CollimatorModelDTO
    {
        public int DTOVersion { get; set; }
        public string DTOTool { get; set; }
        public DateTime MeasurementDate{ get; set; }
        public DateTime CollimatorCheckDate{ get; set; }
        public CollimatorType CollimatorType{ get; set; }
        public string ActNumber { get; set; }
        public string ObjectName{ get; set; }
        public string Description{ get; set; }
        public string WorkerName{ get; set; }
        public int LocalAreaSize{ get; set; }
        public decimal HorizontalTolerLocalAreaSize{ get; set; }
        public decimal HorizontalTolerAllLength{ get; set; }
        public decimal VerticalTolerLocalAreaSize{ get; set; }
        public decimal VerticalTolerAllLength{ get; set; }
        public int StepSize{ get; set; }
        public int BedLength{ get; set; }
        public bool IsRevstrokeEnabled{ get; set; }
        public Plane Plane{ get; set; }
        public MeasurementTableModelDTO Table{ get; set; }
        public bool IsAddtionsFieldEnabled{ get; set; }
    }
}
