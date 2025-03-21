using MigraDoc.DocumentObjectModel.Fields;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;
using System.ComponentModel;

namespace PryamolineynostWF.Models.Collimator;

public class MeasurementRowModel : INotifyPropertyChanged
{
    private int _position; // Номер измерений
    private int _measurementLength; // Длина измерения, мм

    //Горизонтальная поверхность
    private int? _forwardDegrees_Horizontal; // Градусы прямой ход
    private int? _forwardMinutes_Horizontal; // Минуты прямой ход
    private decimal? _forwardSeconds_Horizontal; // Секунды прямой ход
    private int? _reverseDegrees_Horizontal; // Градусы обратный ход
    private int? _reverseMinutes_Horizontal; // Минуты обратный ход
    private decimal? _reverseSeconds_Horizontal; // Секунды обратный ход
    private decimal? _meanSeconds_Horizontal; // Средние секунды
    private decimal? _relativeAngle_Horizontal; // bi Наклон проверяемых участков
    private decimal? _relativeAngleToPrevious_Horizontal; // hi Наклон проверяемых участков относительно предыдущего
    private decimal? _relativeAngleToFirst_Horizontal; // Hi Наклон проверяемых участков относительно первой точки
    private decimal? _ordinateStraightness_Horizontal; // bi Ордината прямой величины в проверяемых точках
    private decimal? _straightnessDeviation_Horizontal; // Hi Отклонения прямолинейности от направляющей
    private string? _formatedMean_Horizontal;

    //Вертикальная поверхность
    private int? _forwardDegrees_Vertical; // Градусы прямой ход
    private int? _forwardMinutes_Vertical; // Минуты прямой ход
    private decimal? _forwardSeconds_Vertical; // Секунды прямой ход
    private int? _reverseDegrees_Vertical; // Градусы обратный ход
    private int? _reverseMinutes_Vertical; // Минуты обратный ход
    private decimal? _reverseSeconds_Vertical; // Секунды обратный ход
    private decimal? _meanSeconds_Vertical; // Средние секунды
    private decimal? _relativeAngle_Vertical; // bi Наклон проверяемых участков
    private decimal? _relativeAngleToPrevious_Vertical; // hi Наклон проверяемых участков относительно предыдущего
    private decimal? _relativeAngleToFirst_Vertical; // Hi Наклон проверяемых участков относительно первой точки
    private decimal? _ordinateStraightness_Vertical; // bi Ордината прямой величины в проверяемых точках
    private decimal? _straightnessDeviation_Vertical; // Hi Отклонения прямолинейности от направляющей
    private string? _formatedMean_Vertical;

    private MeasurementRowModel? _previousDataRow; // Предыдущая строка
    private int _stepSize; // Шаг
    private bool _isReverseStrokeEnabled; // Включен ли учет обратного хода


    public event PropertyChangedEventHandler? PropertyChanged;

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

    public int Position
    {
        get => _position;
        private set
        {
            _position = value;
            MeasurementLength = Position * StepSize;
            OnPropertyChanged("Position");
        }
    }

    public int MeasurementLength
    {
        get => _measurementLength;
        private set
        {
            _measurementLength = value;
            OnPropertyChanged("MeasurementLength");
        }
    }

    [Browsable(false)]
    public int StepSize
    {
        get => _stepSize;
        set
        {
            _stepSize = value;
            MeasurementLength = Position * StepSize;
        }
            
    }

    public int? ForwardDegreesHorizontal
    {
        get => _forwardDegrees_Horizontal;
        set
        {
            _forwardDegrees_Horizontal = GetFormatedDegree(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ForwardDegreesHorizontal");
        }
    }

    public int? ForwardMinutesHorizontal
    {
        get => _forwardMinutes_Horizontal;
        set
        {
            _forwardMinutes_Horizontal = GetFormatedMinutes(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ForwardMinutesHorizontal");
        }
    }

    public decimal? ForwardSecondsHorizontal
    {
        get => _forwardSeconds_Horizontal;
        set
        {
            _forwardSeconds_Horizontal = GetFormatedSeconds(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ForwardSecondsHorizontal");
        }
    }

    public int? ReverseDegreesHorizontal
    {
        get => _reverseDegrees_Horizontal;
        set
        {
            _reverseDegrees_Horizontal = GetFormatedDegree(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ReverseDegreesHorizontal");
        }
    }

    public int? ReverseMinutesHorizontal
    {
        get => _reverseMinutes_Horizontal;
        set
        {
            _reverseMinutes_Horizontal = GetFormatedMinutes(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ReverseMinutesHorizontal");
        }
    }

    public decimal? ReverseSecondsHorizontal
    {
        get => _reverseSeconds_Horizontal;
        set
        {
            _reverseSeconds_Horizontal = GetFormatedSeconds(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ReverseSecondsHorizontal");
        }
    }

    [Browsable(false)]
    public decimal? MeanSecondsHorizontal
    {
        get => _meanSeconds_Horizontal;
        private set
        {
            _meanSeconds_Horizontal = value;
            FormatedMeanHorizontal = value == null ? null : GetMeanString(value);
        }
    }

    public string? FormatedMeanHorizontal
    {
        get => _formatedMean_Horizontal;
        private set
        {
            _formatedMean_Horizontal = value;
            OnPropertyChanged("FormatedMeanHorizontal");
        }
    }

    public decimal? RelativeAngleHorizontal
    {
        get => _relativeAngle_Horizontal;
        private set
        {
            _relativeAngle_Horizontal = value;
            OnPropertyChanged("RelativeAngleHorizontal");
        }
    }

    public decimal? RelativeAngleToPreviousHorizontal
    {
        get => _relativeAngleToPrevious_Horizontal;
        private set
        {
            _relativeAngleToPrevious_Horizontal = value;
            OnPropertyChanged("RelativeAngleToPreviousHorizontal");
        }
    }

    public decimal? RelativeAngleToFirstHorizontal
    {
        get => _relativeAngleToFirst_Horizontal;
        private set
        {
            _relativeAngleToFirst_Horizontal = value;
            OnPropertyChanged("RelativeAngleToFirstHorizontal");
        }
    }

    public decimal? OrdinateStraightnessHorizontal
    {
        get => _ordinateStraightness_Horizontal;
        private set
        {
            _ordinateStraightness_Horizontal = value;
            OnPropertyChanged("OrdinateStraightnessHorizontal");
        }
    }

    public decimal? StraightnessDeviationHorizontal
    {
        get => _straightnessDeviation_Horizontal;
        private set
        {
            _straightnessDeviation_Horizontal = value;
            OnPropertyChanged("StraightnessDeviationHorizontal");
        }
    }


    public int? ForwardDegreesVertical
    {
        get => _forwardDegrees_Vertical;
        set
        {
            _forwardDegrees_Vertical = GetFormatedDegree(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ForwardDegreesVertical");
        }
    }

    public int? ForwardMinutesVertical
    {
        get => _forwardMinutes_Vertical;
        set
        {
            _forwardMinutes_Vertical = GetFormatedMinutes(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ForwardMinutesVertical");
        }
    }

    public decimal? ForwardSecondsVertical
    {
        get => _forwardSeconds_Vertical;
        set
        {
            _forwardSeconds_Vertical = GetFormatedSeconds(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ForwardSecondsVertical");
        }
    }

    public int? ReverseDegreesVertical
    {
        get => _reverseDegrees_Vertical;
        set
        {
            _reverseDegrees_Vertical = GetFormatedDegree(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ReverseDegreesVertical");
        }
    }

    public int? ReverseMinutesVertical
    {
        get => _reverseMinutes_Vertical;
        set
        {
            _reverseMinutes_Vertical = GetFormatedMinutes(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ReverseMinutesVertical");
        }
    }

    public decimal? ReverseSecondsVertical
    {
        get => _reverseSeconds_Vertical;
        set
        {
            _reverseSeconds_Vertical = GetFormatedSeconds(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ReverseSecondsVertical");
        }
    }

    [Browsable(false)]
    public decimal? MeanSecondsVertical
    {
        get => _meanSeconds_Vertical;
        private set
        {
            _meanSeconds_Vertical = value;
            FormatedMeanVertical = value == null ? null : GetMeanString(value);
        } 
    }

    public string? FormatedMeanVertical
    {
        get => _formatedMean_Vertical;
        set
        {
            _formatedMean_Vertical = value;
            OnPropertyChanged("FormatedMeanVertical");
        }
    }

    public decimal? RelativeAngleVertical
    {
        get => _relativeAngle_Vertical;
        private set
        {
            _relativeAngle_Vertical = value;
            OnPropertyChanged("RelativeAngleVertical");
        }
    }

    public decimal? RelativeAngleToPreviousVertical
    {
        get => _relativeAngleToPrevious_Vertical;
        private set
        {
            _relativeAngleToPrevious_Vertical = value;
            OnPropertyChanged("RelativeAngleToPreviousVertical");
        }
    }

    public decimal? RelativeAngleToFirstVertical
    {
        get => _relativeAngleToFirst_Vertical;
        private set
        {
            _relativeAngleToFirst_Vertical = value;
            OnPropertyChanged("RelativeAngleToFirstVertical");
        }
    }

    public decimal? OrdinateStraightnessVertical
    {
        get => _ordinateStraightness_Vertical;
        private set
        {
            _ordinateStraightness_Vertical = value;
            OnPropertyChanged("OrdinateStraightnessVertical");
        }
    }

    public decimal? StraightnessDeviationVertical
    {
        get => _straightnessDeviation_Vertical;
        private set
        {
            _straightnessDeviation_Vertical = value;
            OnPropertyChanged("StraightnessDeviationVertical");
        }
    }


    private decimal? CalculateHorizontalMean()
    {
        return CalculateMeanValue(_forwardDegrees_Horizontal,
            _forwardMinutes_Horizontal,
            _forwardSeconds_Horizontal,
            _reverseDegrees_Horizontal,
            _reverseMinutes_Horizontal,
            _reverseSeconds_Horizontal);
    }

    private decimal? CalculateVerticalMean()
    {
        return CalculateMeanValue(_forwardDegrees_Vertical,
            _forwardMinutes_Vertical,
            _forwardSeconds_Vertical,
            _reverseDegrees_Vertical,
            _reverseMinutes_Vertical,
            _reverseSeconds_Vertical);
    }

    private decimal? CalculateMeanValue(int? fDegrees, int? fMinutes, decimal? fSeconds, int? rDegrees,
        int? rMinutes, decimal? rSeconds)
    {
        decimal? mean;
        if (fDegrees == null || fMinutes == null || fSeconds == null)
        {
            return null;
        }

        if (IsReverseStrokeEnabled && (rDegrees == null || rMinutes == null || rSeconds == null))
        {
            return null;
        }

        if (IsReverseStrokeEnabled)
            mean = (decimal)((fDegrees + rDegrees) * 3600
                             + (decimal)((fMinutes + rMinutes) * 60) + fSeconds + rSeconds) / 2M;
        else
            mean = (decimal)(fDegrees * 3600 + fMinutes * 60 + fSeconds);

        return mean;
    }

    [Browsable(false)]
    public bool IsReverseStrokeEnabled
    {
        get => _isReverseStrokeEnabled;
        set
        {
            _isReverseStrokeEnabled = value;
            _meanSeconds_Horizontal = CalculateHorizontalMean();
            OnPropertyChanged("FormatedMeanHorizontal");
        }
    }

    [Browsable(false)]
    public MeasurementRowModel? PreviousDataRow
    {
        get => _previousDataRow;
        set => _previousDataRow = value;
    }

    [Browsable(false)]
    private int? GetFormatedDegree(int? value)
    {
        return value != null ? value % 360 : value;
    }

    private int? GetFormatedMinutes(int? value)
    {
        return value != null ? value % 60 : value;
    }

    private decimal? GetFormatedSeconds(decimal? value)
    {
        return value != null ? value % 60.0M : value;
    }

    private string? GetMeanString(decimal? seconds)
    {
        if (seconds == null)
            return null;
        var meanDegrees = (int)(seconds / 3600 % 360);
        var meanMinutes = (int)(seconds / 60 % 60);
        var meanSeconds = Math.Round((decimal)(seconds % 60), 1);
        return $"{meanDegrees.ToString()}°{meanMinutes.ToString()}'{meanSeconds.ToString()}\"";
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    [Browsable(false)]
    public void UpdatePosition(int position)
    {
        Position = position;
    }
}