using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;
using System.ComponentModel;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementRowModel : INotifyPropertyChanged
    {
        private int _position; // Номер измерений
        private int _measurementLength; // Длина измерения, мм
        
        private int? _forwardDegrees; // Градусы прямой ход
        private int? _forwardMinutes; // Минуты прямой ход
        private decimal? _forwardSeconds; // Секунды прямой ход
        private int? _reverseDegrees; // Градусы обратный ход
        private int? _reverseMinutes; // Минуты обратный ход
        private decimal? _reverseSeconds; // Секунды обратный ход
        private decimal? _meanSeconds; // Средние секунды
        private decimal? _relativeAngle; // bi Наклон проверяемых участков
        private decimal? _relativeAngleToPrevious; // hi Наклон проверяемых участков относительно предыдущего
        private decimal? _relativeAngleToFirst; // Hi Наклон проверяемых участков относительно первой точки
        private decimal? _ordinateStraightness; // bi Ордината прямой величины в проверяемых точках
        private decimal? _straightnessDeviation; // Hi Отклонения прямолинейности от направляющей
        
        private MeasurementRowModel? _previousDataRow; // Предыдущая строка
        private int _stepSize; // Шаг
        private bool _isReverseStrokeEnabled; // Включен ли учет обратного хода

        //public static readonly Dictionary<string, string> ColumnHeaders = new Dictionary<string, string>
        //{
        //    { "Position", "No" },   // Русский
        //    { "MeasurementLength", "Позиция" },
        //    { "ForwardDegrees", "Пр.°" },
        //    { "ForwardMinutes", "Пр.'" },
        //    { "ForwardSeconds", "Пр.\"" },
        //    { "ReverseDegrees", "Обр.°" },
        //    { "ReverseMinutes", "Обр.'" },
        //    { "ReverseSeconds", "Обр.\"" },
        //    { "MeanValue", "Ср." },
        //    { "RelativeAngle", "βi, угл. с" },
        //    { "RelativeAngleToPrevious", "hi, мкм" },
        //    { "RelativeAngleToFirst", "Ai, мкм" },
        //    { "OrdinateStraightness", "Bi, мкм" },
        //    { "StraightnessDeviation", "Hi, мкм" }
        //};

        //public static readonly List<string> ReverseStrokeEnableColumns = new List<string>
        //{
        //    "ReverseDegrees",
        //    "ReverseMinutes",
        //    "ReverseSeconds",
        //    "MeanValue"
        //};

        //public static readonly List<string> AdditionFields = new List<string>
        //{
        //    "RelativeAngle",
        //    "RelativeAngleToPrevious",
        //    "RelativeAngleToFirst",
        //    "OrdinateStraightness",
        //    "StraightnessDeviation"
        //};

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Position
        {
            get => _position;
            private set => _position = value;
        }

        public int MeasurementLength
        {
            get => _measurementLength;
            private set => _measurementLength = value;
        }

        [Browsable(false)]
        public int StepSize
        {
            get => _stepSize;
            set
            {
                _stepSize = value;
            } 
        }

        public int? ForwardDegrees
        {
            get => _forwardDegrees;
            set 
            {
                _forwardDegrees = value != null ? value % 360 : value;
                OnPropertyChanged("ForwardDegrees");
                CalculateMeanValue();
            }
        }

        public int? ForwardMinutes
        {
            get => _forwardMinutes;
            set
            {
                _forwardMinutes = value != null ? value % 60 : value;
                CalculateMeanValue();
                OnPropertyChanged("ForwardMinutes");
            }
        }

        public decimal? ForwardSeconds
        {
            get => _forwardSeconds;
            set 
            {
                _forwardSeconds = value != null ? value % 60.0M : value;
                CalculateMeanValue();
                OnPropertyChanged("ForwardSeconds");
            } 
        }

        public int? ReverseDegrees
        {
            get => _reverseDegrees;
            set
            {
                _reverseDegrees = value != null ? value % 360 : value;
                CalculateMeanValue();
                OnPropertyChanged("ReverseDegrees");
            }
        }

        public int? ReverseMinutes
        {
            get => _reverseMinutes;
            set
            {
                _reverseMinutes = value != null ? value % 60 : value;
                CalculateMeanValue();
                OnPropertyChanged("ReverseMinutes");
            }
        }

        public decimal? ReverseSeconds
        {
            get => _reverseSeconds;
            set
            {
                _reverseSeconds = value != null ? value % 60.0M : value;
                CalculateMeanValue();
                OnPropertyChanged("ReverseSeconds");
            }
        }

        public string? MeanValue
        {
            get
            {
                if (MeanSeconds == null)
                    return null;
                int meanDegrees = (int)(MeanSeconds / 3600 % 360);
                int meanMinutes = (int)(MeanSeconds / 60 % 60);
                decimal meanSeconds = Math.Round((decimal)(MeanSeconds % 60), 1);
                return $"{meanDegrees.ToString()}°{meanMinutes.ToString()}'{meanSeconds.ToString()}\"";
            }
        }

        [Browsable(false)]
        public decimal? MeanSeconds
        {
            get => _meanSeconds;
            private set => _meanSeconds = value;
        }


        [Browsable(false)]
        public bool IsReverseStrokeEnabled
        {
            get => _isReverseStrokeEnabled;
            set
            {
                _isReverseStrokeEnabled = value;
                CalculateMeanValue() ;
            }
        }

        [Browsable(false)]
        public MeasurementRowModel? PreviousDataRow
        {
            get => _previousDataRow;
            set => _previousDataRow = value;
        }

        public decimal? RelativeAngle
        {
            get => _relativeAngle;
            private set 
            {
                _relativeAngle = value;
                OnPropertyChanged("RelativeAngle");
            } 
        }

        public decimal? RelativeAngleToPrevious
        {
            get => _relativeAngleToPrevious;
            private set
            {
                _relativeAngleToPrevious = value;
                OnPropertyChanged("RelativeAngleToPrevious");
            } 
        }

        public decimal? RelativeAngleToFirst
        {
            get => _relativeAngleToFirst;
            private set
            {
                _relativeAngleToFirst = value;
                OnPropertyChanged("RelativeAngleToFirst");
            } 
        }

        public decimal? OrdinateStraightness
        {
            get => _ordinateStraightness;
            private set
            {
                _ordinateStraightness = value;
                OnPropertyChanged("OrdinateStraightness");
            }
        }

        public decimal? StraightnessDeviation
        {
            get => _straightnessDeviation;
            private set
            {
                _straightnessDeviation = value;
                OnPropertyChanged("StraightnessDeviation");
            }
        }

        public MeasurementRowModel(int step, MeasurementRowModel? prevRow, bool revStrokeEnable)
        {
            IsReverseStrokeEnabled = revStrokeEnable;
            StepSize = step;
            
            if (prevRow != null)
            {
                Position = prevRow.Position + 1;
                StepSize = step;
                MeasurementLength = prevRow.MeasurementLength + StepSize;
            }
            else
            {
                Position = 0;
                StepSize = step;
                MeasurementLength = 0;
            }
        }

        private void CalculateMeanValue()
        {
            if (ForwardDegrees == null || ForwardMinutes == null || ForwardSeconds == null)
            {
                MeanSeconds = null;
                return;
            }
            
            if ( IsReverseStrokeEnabled && (ReverseDegrees == null || ReverseMinutes == null || ReverseSeconds == null))
            {
                MeanSeconds = null;
                return;
            }

            if (IsReverseStrokeEnabled)
            {
                MeanSeconds = (decimal)(((ForwardDegrees + ReverseDegrees) * 3600) 
                    + (decimal)((ForwardMinutes + ReverseMinutes) * 60) + ((ForwardSeconds + ReverseSeconds))) / 2M;
            }
            else
            {
                MeanSeconds = (decimal)(ForwardDegrees * 3600 + ForwardMinutes * 60 + ForwardSeconds);
            }
            OnPropertyChanged("MeanValue");

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}