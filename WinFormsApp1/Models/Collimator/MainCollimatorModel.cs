using System;
using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator
{
    public class MainCollimatorModel : INotifyPropertyChanged
    {
        private DateTime _measurementDate;
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime MeasurementDate
        {
            get => _measurementDate;
            set
            {
                _measurementDate = value;
                OnPropertyChanged(nameof(MeasurementDate));
            }
        }

        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
