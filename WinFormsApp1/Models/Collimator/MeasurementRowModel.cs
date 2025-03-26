using System.ComponentModel;
using System.Globalization;

namespace PryamolineynostWF.Models.Collimator;

public class MeasurementRowModel : INotifyPropertyChanged
{
    private int _position; // Номер измерений
    private int _measurementLength; // Длина измерения, мм

    //Горизонтальная поверхность
    private int? _forwardMinutesHorizontal; // Минуты прямой ход
    private decimal? _forwardSecondsHorizontal; // Секунды прямой ход
    private int? _reverseMinutesHorizontal; // Минуты обратный ход
    private decimal? _reverseSecondsHorizontal; // Секунды обратный ход
    private decimal? _meanSecondsHorizontal; // Средние секунды
    private decimal? _relativeAngleHorizontal; // bi Наклон проверяемых участков
    private decimal? _relativeAngleToPreviousHorizontal; // hi Наклон проверяемых участков относительно предыдущего
    private decimal? _relativeAngleToFirstHorizontal; // Hi Наклон проверяемых участков относительно первой точки
    private decimal? _ordinateStraightnessHorizontal; // bi Ордината прямой величины в проверяемых точках
    private decimal? _straightnessDeviationHorizontal; // Hi Отклонения прямолинейности от направляющей
    private string? _formatedMeanHorizontal;

    //Вертикальная поверхность
    // private int? _forwardDegrees_Vertical; // Градусы прямой ход
    private int? _forwardMinutesVertical; // Минуты прямой ход

    private decimal? _forwardSecondsVertical; // Секунды прямой ход

    // private int? _reverseDegrees_Vertical; // Градусы обратный ход
    private int? _reverseMinutesVertical; // Минуты обратный ход
    private decimal? _reverseSecondsVertical; // Секунды обратный ход
    private decimal? _meanSecondsVertical; // Средние секунды
    private decimal? _relativeAngleVertical; // bi Наклон проверяемых участков
    private decimal? _relativeAngleToPreviousVertical; // hi Наклон проверяемых участков относительно предыдущего
    private decimal? _relativeAngleToFirstVertical; // Hi Наклон проверяемых участков относительно первой точки
    private decimal? _ordinateStraightnessVertical; // bi Ордината прямой величины в проверяемых точках
    private decimal? _straightnessDeviationVertical; // Hi Отклонения прямолинейности от направляющей
    private string? _formatedMeanVertical;

    private decimal? _firstMeanAngleHorizontal;
    private decimal? _firstMeanAngleVertical;


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
    [Browsable(false)]
    public decimal? FirstMeanAngle_Horizontal
    {
        get => _firstMeanAngleHorizontal;
        set
        {
            _firstMeanAngleHorizontal = value;
            RelativeAngleHorizontal = GetRelativeAngle(_meanSecondsHorizontal, _firstMeanAngleHorizontal);
        }
    }
    [Browsable(false)]
    public decimal? FirstMeanAngle_Vertical
    {
        get => _firstMeanAngleVertical;
        set
        {
            _firstMeanAngleVertical = value;
            RelativeAngleVertical = GetRelativeAngle(_meanSecondsVertical, _firstMeanAngleVertical);
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

    public int? ForwardMinutesHorizontal
    {
        get => _forwardMinutesHorizontal;
        set
        {
            _forwardMinutesHorizontal = GetFormatedMinutes(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ForwardMinutesHorizontal");
        }
    }

    public decimal? ForwardSecondsHorizontal
    {
        get => _forwardSecondsHorizontal;
        set
        {
            _forwardSecondsHorizontal = GetFormatedSeconds(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ForwardSecondsHorizontal");
        }
    }

    public int? ReverseMinutesHorizontal
    {
        get => _reverseMinutesHorizontal;
        set
        {
            _reverseMinutesHorizontal = GetFormatedMinutes(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ReverseMinutesHorizontal");
        }
    }

    public decimal? ReverseSecondsHorizontal
    {
        get => _reverseSecondsHorizontal;
        set
        {
            _reverseSecondsHorizontal = GetFormatedSeconds(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("ReverseSecondsHorizontal");
        }
    }

    [Browsable(false)]
    public decimal? MeanSecondsHorizontal
    {
        get => _meanSecondsHorizontal;
        private set
        {
            _meanSecondsHorizontal = value;
            FormatedMeanHorizontal = value == null ? null : GetMeanString(value);
            OnPropertyChanged("MeanSecondsHorizontal");
            RelativeAngleHorizontal = GetRelativeAngle(_meanSecondsHorizontal, _firstMeanAngleHorizontal);
        }
    }

    public string? FormatedMeanHorizontal
    {
        get => _formatedMeanHorizontal;
        private set
        {
            _formatedMeanHorizontal = value;
            OnPropertyChanged("FormatedMeanHorizontal");
        }
    }

    public decimal? RelativeAngleHorizontal
    {
        get => _relativeAngleHorizontal;
        private set
        {
            _relativeAngleHorizontal = value;
            OnPropertyChanged("RelativeAngleHorizontal");
        }
    }

    public decimal? RelativeAngleToPreviousHorizontal
    {
        get => _relativeAngleToPreviousHorizontal;
        private set
        {
            _relativeAngleToPreviousHorizontal = value;
            OnPropertyChanged("RelativeAngleToPreviousHorizontal");
        }
    }

    public decimal? RelativeAngleToFirstHorizontal
    {
        get => _relativeAngleToFirstHorizontal;
        private set
        {
            _relativeAngleToFirstHorizontal = value;
            OnPropertyChanged("RelativeAngleToFirstHorizontal");
        }
    }

    public decimal? OrdinateStraightnessHorizontal
    {
        get => _ordinateStraightnessHorizontal;
        private set
        {
            _ordinateStraightnessHorizontal = value;
            OnPropertyChanged("OrdinateStraightnessHorizontal");
        }
    }

    public decimal? StraightnessDeviationHorizontal
    {
        get => _straightnessDeviationHorizontal;
        private set
        {
            _straightnessDeviationHorizontal = value;
            OnPropertyChanged("StraightnessDeviationHorizontal");
        }
    }

    public int? ForwardMinutesVertical
    {
        get => _forwardMinutesVertical;
        set
        {
            _forwardMinutesVertical = GetFormatedMinutes(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ForwardMinutesVertical");
        }
    }

    public decimal? ForwardSecondsVertical
    {
        get => _forwardSecondsVertical;
        set
        {
            _forwardSecondsVertical = GetFormatedSeconds(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ForwardSecondsVertical");
        }
    }

    public int? ReverseMinutesVertical
    {
        get => _reverseMinutesVertical;
        set
        {
            _reverseMinutesVertical = GetFormatedMinutes(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ReverseMinutesVertical");
        }
    }

    public decimal? ReverseSecondsVertical
    {
        get => _reverseSecondsVertical;
        set
        {
            _reverseSecondsVertical = GetFormatedSeconds(value);
            MeanSecondsVertical = CalculateVerticalMean();
            OnPropertyChanged("ReverseSecondsVertical");
        }
    }

    [Browsable(false)]
    public decimal? MeanSecondsVertical
    {
        get => _meanSecondsVertical;
        private set
        {
            _meanSecondsVertical = value;
            FormatedMeanVertical = value == null ? null : GetMeanString(value);
            OnPropertyChanged("MeanSecondsVertical");
            RelativeAngleVertical = GetRelativeAngle(_meanSecondsVertical, _firstMeanAngleVertical);
        }
    }

    public string? FormatedMeanVertical
    {
        get => _formatedMeanVertical;
        set
        {
            _formatedMeanVertical = value;
            OnPropertyChanged("FormatedMeanVertical");
        }
    }

    public decimal? RelativeAngleVertical
    {
        get => _relativeAngleVertical;
        private set
        {
            _relativeAngleVertical = value;
            OnPropertyChanged("RelativeAngleVertical");
        }
    }

    public decimal? RelativeAngleToPreviousVertical
    {
        get => _relativeAngleToPreviousVertical;
        private set
        {
            _relativeAngleToPreviousVertical = value;
            OnPropertyChanged("RelativeAngleToPreviousVertical");
        }
    }

    public decimal? RelativeAngleToFirstVertical
    {
        get => _relativeAngleToFirstVertical;
        private set
        {
            _relativeAngleToFirstVertical = value;
            OnPropertyChanged("RelativeAngleToFirstVertical");
        }
    }

    public decimal? OrdinateStraightnessVertical
    {
        get => _ordinateStraightnessVertical;
        private set
        {
            _ordinateStraightnessVertical = value;
            OnPropertyChanged("OrdinateStraightnessVertical");
        }
    }

    public decimal? StraightnessDeviationVertical
    {
        get => _straightnessDeviationVertical;
        private set
        {
            _straightnessDeviationVertical = value;
            OnPropertyChanged("StraightnessDeviationVertical");
        }
    }


    private decimal? CalculateHorizontalMean()
    {
        return CalculateMeanValue(_forwardMinutesHorizontal,
            _forwardSecondsHorizontal,
            _reverseMinutesHorizontal,
            _reverseSecondsHorizontal);
    }

    private decimal? CalculateVerticalMean()
    {
        return CalculateMeanValue(_forwardMinutesVertical,
            _forwardSecondsVertical,
            _reverseMinutesVertical,
            _reverseSecondsVertical);
    }

    private decimal? CalculateMeanValue(int? fMinutes, decimal? fSeconds, int? rMinutes, decimal? rSeconds)
    {
        if (fMinutes == null || fSeconds == null)
        {
            return null;
        }

        if (IsReverseStrokeEnabled && (rMinutes == null || rSeconds == null))
        {
            return null;
        }

        return IsReverseStrokeEnabled switch
        {
            true => (((fMinutes + rMinutes) * 60) + fSeconds + rSeconds) / 2M,
            false => fMinutes * 60 + fSeconds
        };
    }

    [Browsable(false)]
    public bool IsReverseStrokeEnabled
    {
        get => _isReverseStrokeEnabled;
        set
        {
            _isReverseStrokeEnabled = value;
            _meanSecondsHorizontal = CalculateHorizontalMean();
            OnPropertyChanged("FormatedMeanHorizontal");
        }
    }

    [Browsable(false)]
    public MeasurementRowModel? PreviousDataRow
    {
        get => _previousDataRow;
        set => _previousDataRow = value;
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
        var meanMinutes = (int)(seconds / 60 % 60);
        var meanSeconds = Math.Round((decimal)(seconds % 60), 1);
        return $"{meanMinutes.ToString()}'{meanSeconds.ToString(CultureInfo.InvariantCulture)}\"";
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

    private decimal? GetRelativeAngle(decimal? meanSeconds, decimal? firstMeanSeconds)
    {
        if (firstMeanSeconds == null)
            return 0;
        return meanSeconds - firstMeanSeconds;
    }
}