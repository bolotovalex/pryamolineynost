using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator
{
    public class CollimatorModel : INotifyPropertyChanged
    {
        private DateTime _measurementDate = DateTime.Now;
        private DateTime _collimatorCheckDate;
        private CollimatorType _collimatorType;
        private string _actNumber;
        private string _objectName = "";
        private string _description = "";
        private string _workerName = "";
        private int _localAreaSize = 1000;
        private decimal _horizontalTolerLocalAreaSize = 0;
        private decimal _horizontalTolerAllLength = 0;
        private decimal _verticalTolerLocalAreaSize = 0;
        private decimal _verticalTolerAllLength = 0;
        private int _stepSize = 500;
        private int _bedLength = 0;
        private decimal _horizontalMaxDeviation = 0;
        private decimal _horizontalMinDeviation = 0;
        private decimal _verticalMaxDeviation = 0;
        private decimal _verticalMinDeviation = 0;
        private decimal _horizontalMeanDeviation = 0;
        private decimal _verticalMeanDeviation = 0;
        private decimal _horizontalAreaDeviation = 0;
        private decimal _verticalAreaDeviation = 0;
        private bool _revstrokeEnabled;
        private Plane _plane;
        private MeasurementTableModel _dataSet;
        private bool _addtionsFieldEnabled;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public CollimatorModel()
        {
            Plane = Plane.Horizontal;
            _dataSet = new MeasurementTableModel(_plane);
            _dataSet.Table.Add(new MeasurementRowModel(_stepSize, null, _revstrokeEnabled));
            _dataSet.Table.Add(new MeasurementRowModel(_stepSize, _dataSet.Table[^1], _revstrokeEnabled));
        }

        public DateTime MeasurementDate
        {
            get => _measurementDate;
            set
            {
                _measurementDate = value;
                OnPropertyChanged(nameof(MeasurementDate));
            }
        }

        public CollimatorType CollimatorType
        {
            get => _collimatorType;
            set
            {
                _collimatorType = value;
                OnPropertyChanged(nameof(CollimatorType));
            }
        }

        public string ActNumber
        {
            get => _actNumber;
            set
            {
                _actNumber = value;
                OnPropertyChanged(nameof(ActNumber));
            }
        }

        public string ObjectName
        {
            get => _objectName;
            set
            {
                _objectName = value;
                OnPropertyChanged(nameof(ObjectName));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string WorkerName
        {
            get => _workerName;
            set
            {
                _workerName = value;
                OnPropertyChanged(nameof(WorkerName));
            }
        }

        public int LocalAreaSize
        {
            get => _localAreaSize;
            set
            {
                _localAreaSize = value;
                OnPropertyChanged(nameof(LocalAreaSize));
            }
        }

        public decimal HorizontalTolerLocalAreaSize
        {
            get => _horizontalTolerLocalAreaSize;
            set
            {
                _horizontalTolerLocalAreaSize = value;
                OnPropertyChanged(nameof(HorizontalTolerLocalAreaSize));
            }
        }

        public decimal HorizontalTolerAllLength
        {
            get => _horizontalTolerAllLength;
            set
            {
                _horizontalTolerAllLength = value;
                OnPropertyChanged(nameof(HorizontalTolerAllLength));
            }
        }

        public decimal VerticalTolerLocalAreaSize
        {
            get => _verticalTolerLocalAreaSize;
            set
            {
                _verticalTolerLocalAreaSize = value;
                OnPropertyChanged(nameof(VerticalTolerLocalAreaSize));
            }
        }

        public decimal VerticalTolerAllLength
        {
            get => _verticalTolerAllLength;
            set
            {
                _verticalTolerAllLength = value;
                OnPropertyChanged(nameof(VerticalTolerAllLength));
            }
        }

        public int StepSize
        {
            get => _stepSize;
            set
            {
                _stepSize = value;
                OnPropertyChanged(nameof(StepSize));
            }
        }

        public int BedLength
        {
            get => _bedLength;
            set
            {
                _bedLength = value;
                OnPropertyChanged(nameof(BedLength));
            }
        }

        public decimal HorizontalMaxDeviation
        {
            get => _horizontalMaxDeviation;
            set
            {
                _horizontalMaxDeviation = value;
                OnPropertyChanged(nameof(HorizontalMaxDeviation));
            }
        }

        public decimal VerticalMaxDeviation 
        { 
            get => _verticalMaxDeviation; 
            set 
            { 
                _verticalMaxDeviation = value; 
                OnPropertyChanged(nameof(VerticalMaxDeviation)); 
            } 
        }

        public decimal HorizontalMinDeviation 
        { 
            get => _horizontalMinDeviation; 
            set 
            { 
                _horizontalMinDeviation = value; 
                OnPropertyChanged(nameof(HorizontalMinDeviation)); 
            } 
        }

        public decimal VerticalMinDeviation 
        { 
            get => _verticalMinDeviation; 
            set { _verticalMinDeviation = value; 
                OnPropertyChanged(nameof(VerticalMinDeviation)); 
            } 
        }

        public decimal HorizontalMeanDeviation { 
            get => _horizontalMeanDeviation; 
            set 
            { 
                _horizontalMeanDeviation = value; 
                OnPropertyChanged(nameof(HorizontalMeanDeviation)); 
            } 
        }

        public decimal VerticalMeanDeviation 
        { 
            get => _verticalMeanDeviation; 
            set 
            { 
                _verticalMeanDeviation = value; 
                OnPropertyChanged(nameof(VerticalMeanDeviation)); 
            } 
        }

        public decimal HorizontalAreaDeviation 
        { 
            get => _horizontalAreaDeviation; 
            set 
            { 
                _horizontalAreaDeviation = value; 
                OnPropertyChanged(nameof(HorizontalAreaDeviation)); 
            } 
        }

        public decimal VerticalAreaDeviation 
        { 
            get => _verticalAreaDeviation; 
            set 
            { 
                _verticalAreaDeviation = value; 
                OnPropertyChanged(nameof(VerticalAreaDeviation)); 
            } 
        }

        public bool RevStrokeEnabled
        {
            get => _revstrokeEnabled;
            set
            {
                _revstrokeEnabled = value;
                OnPropertyChanged(nameof(RevStrokeEnabled));
            }
        }

        public Plane Plane
        {
            get => _plane;
            set
            {
                _plane = value;
            }
        }

        public MeasurementTableModel MeasurementTable
        {
            get => _dataSet;
            private set
            {
                _dataSet = value;
            }
        }

        public DateTime CollimatorCheckDate
        {
            get => _collimatorCheckDate;
            set
            {
                _collimatorCheckDate = value;
            }
        }

        public bool AdditionsFieldEnabled
        {
            get => _addtionsFieldEnabled;
            set
            {
                _addtionsFieldEnabled = value;
                OnPropertyChanged(nameof(AdditionsFieldEnabled));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
