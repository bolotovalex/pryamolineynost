using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Models.Collimator
{
    public class CombinedMeasurementRowModel
    {
        public int Position { get; set; }
        public int MeasurementLength { get; set; }

        public int? ForwardDegreesHorizontal { get; set; }
        public int? ForwardMinutesHorizontal { get; set; }
        public decimal? ForwardSecondsHorizontal { get; set; }
        public int? ReverseDegreesHorizontal { get; set; }
        public int? ReverseMinutesHorizontal { get; set; }
        public decimal? ReverseSecondsHorizontal { get; set; }
        public string? MeanSecondsHorizontal { get; set; }
        public decimal? RelativeAngleHorizontal { get; set; }
        public decimal? RelativeAngleToPreviousHorizontal { get; set; }
        public decimal? RelativeAngleToFirstHorizontal { get; set; }
        public decimal? OrdinateStraightnessHorizontal { get; set; }
        public decimal? StraightnessDeviationHorizontal { get; set; }
        
        public int? ForwardDegreesVertical { get; set; }
        public int? ForwardMinutesVertical { get; set; }
        public decimal? ForwardSecondsVertical { get; set; }
        public int? ReverseDegreesVertical { get; set; }
        public int? ReverseMinutesVertical { get; set; }
        public decimal? ReverseSecondsVertical { get; set; }
        public string? MeanSecondsVertical { get; set; }
        public decimal? RelativeAngleVertical { get; set; }
        public decimal? RelativeAngleToPreviousVertical { get; set; }
        public decimal? RelativeAngleToFirstVertical { get; set; }
        public decimal? OrdinateStraightnessVertical { get; set; }
        public decimal? StraightnessDeviationVertical { get; set; }


        
        
    }
}
