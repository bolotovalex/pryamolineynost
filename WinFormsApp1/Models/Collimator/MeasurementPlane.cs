using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementPlane : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private decimal _maxDeviation;
        private decimal _minDeviation;
        private decimal _deviation;
        private decimal _lineDeviation;
        private int _bedLength;
        private int _localAreaSize;
        private int _tolerLocalAreaSize;
        private int _tolerAllLength;
        private int _stepSize;

        public decimal MaxDeviation { get => _maxDeviation; set { _maxDeviation = value; OnPropertyChanged(nameof(MaxDeviation)); } }
        public decimal MinDeviation { get => _minDeviation; set { _minDeviation = value; OnPropertyChanged(nameof(MinDeviation)); } }
        public decimal Deviation { get => _deviation; set { _deviation = value; OnPropertyChanged(nameof(Deviation)); } }
        public decimal LineDeviation { get => _lineDeviation; set { _lineDeviation = value; OnPropertyChanged(nameof(LineDeviation)); } }
        public int BedLength { get => _bedLength; set { _bedLength = value; OnPropertyChanged(nameof(BedLength)); } }
        public int LocalAreaSize { get => _localAreaSize; set { _localAreaSize = value; OnPropertyChanged(nameof(LocalAreaSize)); } }
        public int TolerLocalAreaSize { get => _tolerLocalAreaSize; set { _tolerLocalAreaSize = value; OnPropertyChanged(nameof(TolerLocalAreaSize)); } }
        public int TolerAllLength { get => _tolerAllLength; set { _tolerAllLength = value; OnPropertyChanged(nameof(TolerAllLength)); } }
        public int StepSize { get => _stepSize; set { _stepSize = value; OnPropertyChanged(nameof(StepSize)); } }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
