using PryamolineynostWF.Enums;
using System.ComponentModel;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementRowModel
    {
        private int _position; // Номер измерений
        private int _measurementLength; // Длина измерения, мм
        private int? _forwardDegrees; // Градусы прямой ход
        private int? _forwardMinutes; // Минуты прямой ход
        private decimal? _forwardSeconds; // Секунды прямой ход
        private int? _reverseDegrees; // Градусы обратный ход
        private int? _reverseMinutes; // Минуты обратный ход
        private decimal? _reverseSeconds; // Секунды обратный ход
        private int? _meanDegrees; // Средние градусы
        private int? _meanMinutes; // Средние минуты
        private decimal? _meanSeconds; // Средние секунды
        private decimal? _relativeAngle; // bi Наклон проверяемых участков
        private decimal? _relativeAngleToPrevious; // hi Наклон проверяемых участков относительно предыдущего
        private decimal? _relativeAngleToFirst; // Hi Наклон проверяемых участков относительно первой точки
        private decimal? _ordinateStraightness; // bi Ордината прямой величины в проверяемых точках
        private decimal? _straightnessDeviation; // Hi Отклонения прямолинейности от направляющей
        private string? _meanValue;
        private MeasurementRowModel? _previousDataRow; // Предыдущая строка
        private int _stepSize; // Шаг
        private bool _isReverseStrokeEnabled; // Включен ли учет обратного хода

        public static readonly Dictionary<string, string> ColumnHeaders = new Dictionary<string, string>
        {
            { "Position", "No" },   // Русский
            { "MeasurementLength", "Позиция" },
            { "ForwardDegrees", "Пр.°" },
            { "ForwardMinutes", "Пр.'" },
            { "ForwardSeconds", "Пр.\"" },
            { "ReverseDegrees", "Обр.°" },
            { "ReverseMinutes", "Обр.'" },
            { "ReverseSeconds", "Обр.\"" },
            { "MeanValue", "Ср." },
            { "RelativeAngle", "βi, угл. с" },
            { "RelativeAngleToPrevious", "hi, мкм" },
            { "RelativeAngleToFirst", "Ai, мкм" },
            { "OrdinateStraightness", "Bi, мкм" },
            { "StraightnessDeviation", "Hi, мкм" }
        };

        public static readonly List<string> ReverseStrokeEnableColumns = new List<string>
        {
            "ReverseDegrees",
            "ReverseMinutes",
            "ReverseSeconds",
            "MeanValue"
        };

        public static readonly List<string> AdditionFields = new List<string>
        {
            "RelativeAngle",
            "RelativeAngleToPrevious",
            "RelativeAngleToFirst",
            "OrdinateStraightness",
            "StraightnessDeviation"
        };s

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
            }
        }

        public decimal? ForwardSeconds
        {
            get => _forwardSeconds;
            set 
            {
                _forwardSeconds = value != null ? value % 60.0M : value;
                CalculateMeanValue();
            } 
        }

        public int? ReverseDegrees
        {
            get => _reverseDegrees;
            set
            {
                _reverseDegrees = value != null ? value % 360 : value;
                CalculateMeanValue();
            }
        }

        public int? ReverseMinutes
        {
            get => _reverseMinutes;
            set
            {
                _reverseMinutes = value != null ? value % 60 : value;
                CalculateMeanValue();
            }
        }

        public decimal? ReverseSeconds
        {
            get => _reverseSeconds;
            set
            {
                _reverseSeconds = value != null ? value % 60.0M : value;
                CalculateMeanValue();
            }
        }

        public string MeanValue
        {
            get => _meanValue;
            private set => _meanValue = value;
        }

        [Browsable(false)]
        public int? MeanDegrees
        {
            get => _meanDegrees;
            private set => _meanDegrees = value;
        }
        
        [Browsable(false)]
        public int? MeanMinutes
        {
            get => _meanMinutes;
            private set => _meanMinutes = value;
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
            set => _isReverseStrokeEnabled = value;
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
            private set => _relativeAngle = value;
        }

        public decimal? RelativeAngleToPrevious
        {
            get => _relativeAngleToPrevious;
            private set => _relativeAngleToPrevious = value;
        }

        public decimal? RelativeAngleToFirst
        {
            get => _relativeAngleToFirst;
            private set => _relativeAngleToFirst = value;
        }

        public decimal? OrdinateStraightness
        {
            get => _ordinateStraightness;
            private set => _ordinateStraightness = value;
        }

        public decimal? StraightnessDeviation
        {
            get => _straightnessDeviation;
            private set => _straightnessDeviation = value;
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
                MeanValue = "";
                return;
            }
            
            if ( IsReverseStrokeEnabled && (ReverseDegrees == null || ReverseMinutes == null || ReverseSeconds == null))
            {
                MeanValue = "";
                return;
            }

            if (IsReverseStrokeEnabled)
            {
                var meanInSeconds = (ForwardDegrees * 3600 + ForwardMinutes * 60 + ForwardSeconds) +
                                   (ReverseDegrees * 3600 + ReverseMinutes * 60 + ReverseSeconds) / 2M;

                MeanDegrees = (int)(meanInSeconds / 3600 % 360);
                MeanMinutes = (int)(meanInSeconds / 60 % 60);
                MeanSeconds = meanInSeconds % 60;
            }
            else
            {
                MeanDegrees = ForwardDegrees;
                MeanMinutes = ForwardMinutes;
                MeanSeconds = ForwardSeconds;
            }
            MeanValue = $"{MeanDegrees.ToString()}°{MeanMinutes.ToString()}'{MeanSeconds.ToString()}\"";
        }
    }
}