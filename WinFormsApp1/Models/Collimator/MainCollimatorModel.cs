using System;
using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator
{
    public class MainCollimatorModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime AutocollimatorCheckDate { get; set; }
        public string AutocollimatorCheckAct { get; set; }
        public DateTime MeasurementDate { get; set; }
        public CollimatorType CollimatorType { get; set; }
        public string ToolName { get; set; }
        public string Description { get; set; }
        public string WorkerName { get; set; }

        public MeasurementPlane HorizontalPlane { get; set; } = new MeasurementPlane();
        public MeasurementPlane VerticalPlane { get; set; } = new MeasurementPlane();

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
