using System.ComponentModel;
using System.Globalization;
using PryamolineynostWF.Enums;

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
    private decimal? _relativeAngleToFirstHorizontal; // Ai Наклон проверяемых участков относительно первой точки
    private decimal? _ordinateStraightnessHorizontal; // Bi Ордината прямой величины в проверяемых точках
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
    private decimal? _relativeAngleToFirstVertical; // Ai Наклон проверяемых участков относительно первой точки
    private decimal? _ordinateStraightnessVertical; // Bi Ордината прямой величины в проверяемых точках
    private decimal? _straightnessDeviationVertical; // Hi Отклонения прямолинейности от направляющей
    private string? _formatedMeanVertical;

    private decimal? _firstMeanAngleHorizontal;
    private decimal? _firstMeanAngleVertical;
    private decimal? _lastPointAngleCoeficentHorizontal;
    private decimal? _lastPointAngleCoeficentVertical;


    private MeasurementRowModel? _previousDataRow; // Предыдущая строка
    private int _stepSize; // Шаг
    private bool _isReverseStrokeEnabled; // Включен ли учет обратного хода
    private decimal multipler = 0;
    private bool _isLastRow;


    public event PropertyChangedEventHandler? PropertyChanged;

    public MeasurementRowModel(int step, MeasurementRowModel? prevRow, bool revStrokeEnable, bool isLastRow)
    {
        IsReverseStrokeEnabled = revStrokeEnable;
        StepSize = step;

        if (prevRow != null)
        {
            Position = prevRow.Position + 1;
            StepSize = step;
            MeasurementLength = prevRow.MeasurementLength + StepSize;
            _forwardMinutesHorizontal = prevRow.ForwardMinutesHorizontal;
            _forwardMinutesVertical = prevRow.ForwardMinutesVertical;
        }
        else
        {
            Position = 0;
            StepSize = step;
            MeasurementLength = 0;
        }

        IsLastRow = isLastRow;
        _previousDataRow = prevRow;
    }

    [Browsable(false)]
    public bool IsLastRow
    {
        get => IsLastRow;
        set
        {
            
            if (_previousDataRow != null && _previousDataRow.IsLastRow == true)
                _previousDataRow.IsLastRow = false;
            _isLastRow = value;
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
        set
        {
            _position = value;
            MeasurementLength = value * _stepSize;
            OnPropertyChanged("Position");
        }
    }

    public int MeasurementLength
    {
        get => _measurementLength;
        set
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
            multipler = 5 * 0.000001M * _stepSize * 1000;
            RelativeAngleToPreviousHorizontal = CalcRelativeAngleToPrevious(Plane.Horizontal);
            RelativeAngleToPreviousVertical = CalcRelativeAngleToPrevious(Plane.Vertical);
        }
    }

    public int? ForwardMinutesHorizontal
    {
        get => _forwardMinutesHorizontal;
        set
        {
            _forwardMinutesHorizontal = GetFormatedMinutes(value);
            MeanSecondsHorizontal = CalculateHorizontalMean();
            SetPrevRowMinutes();
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
            SetPrevRowMinutes();
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
            SetPrevRowMinutes();
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
            SetPrevRowMinutes();
            OnPropertyChanged("ReverseSecondsHorizontal");
        }
    }

    [Browsable(false)]
    public decimal? MeanSecondsHorizontal
    {
        get => _meanSecondsHorizontal;
        private set
        {
            _meanSecondsHorizontal = RoundNullableDecimal(value, 2);
            FormatedMeanHorizontal = _meanSecondsHorizontal == null ? null : GetMeanString(_meanSecondsHorizontal);
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
            RelativeAngleToPreviousHorizontal = CalcRelativeAngleToPrevious(Plane.Horizontal);
            OnPropertyChanged(nameof(RelativeAngleHorizontal));
        }
    }

    public decimal? RelativeAngleToPreviousHorizontal
    {
        get => _relativeAngleToPreviousHorizontal;
        private set
        {
            _relativeAngleToPreviousHorizontal = value;
            RelativeAngleToFirstHorizontal = CalcRelativeAngleFromFirst(Plane.Horizontal);
            OnPropertyChanged("RelativeAngleToPreviousHorizontal");
        }
    }

    public decimal? RelativeAngleToFirstHorizontal
    {
        get => _relativeAngleToFirstHorizontal;
        set
        {
            _relativeAngleToFirstHorizontal = value;
            StraightnessDeviationHorizontal = RelativeAngleToFirstHorizontal - OrdinateStraightnessHorizontal;
            OnPropertyChanged("RelativeAngleToFirstHorizontal");
        }
    }

    public decimal? OrdinateStraightnessHorizontal
    {
        get => _ordinateStraightnessHorizontal;
        set
        {
            _ordinateStraightnessHorizontal = value;
            StraightnessDeviationHorizontal = RelativeAngleToFirstHorizontal - OrdinateStraightnessHorizontal;
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
            SetPrevRowMinutes();
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
            SetPrevRowMinutes();
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
            SetPrevRowMinutes();
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
            SetPrevRowMinutes();
            OnPropertyChanged("ReverseSecondsVertical");
        }
    }

    [Browsable(false)]
    public decimal? MeanSecondsVertical
    {
        get => _meanSecondsVertical;
        private set
        {
            _meanSecondsVertical = RoundNullableDecimal(value, 2);
            FormatedMeanVertical = _meanSecondsVertical == null ? null : GetMeanString(_meanSecondsVertical);
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
            RelativeAngleToPreviousVertical = CalcRelativeAngleToPrevious(Plane.Vertical);
            OnPropertyChanged("RelativeAngleVertical");
        }
    }

    public decimal? RelativeAngleToPreviousVertical
    {
        get => _relativeAngleToPreviousVertical;
        private set
        {
            _relativeAngleToPreviousVertical = value;
            RelativeAngleToFirstVertical = CalcRelativeAngleFromFirst(Plane.Vertical);
            OnPropertyChanged("RelativeAngleToPreviousVertical");
        }
    }

    public decimal? RelativeAngleToFirstVertical
    {
        get => _relativeAngleToFirstVertical;
        private set
        {
            _relativeAngleToFirstVertical = value;
            StraightnessDeviationVertical = RelativeAngleToFirstVertical - OrdinateStraightnessVertical;
            OnPropertyChanged("RelativeAngleToFirstVertical");
        }
    }

    public decimal? OrdinateStraightnessVertical
    {
        get => _ordinateStraightnessVertical;
        private set
        {
            _ordinateStraightnessVertical = value;
            StraightnessDeviationVertical = RelativeAngleToFirstVertical - OrdinateStraightnessVertical;
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
        if (fMinutes == null || fSeconds == null) return null;

        //if (IsReverseStrokeEnabled && (rMinutes == null || rSeconds == null)) return null;
        if (rMinutes == null || rSeconds == null) return null;

        return IsReverseStrokeEnabled switch
        {
            true => ((fMinutes + rMinutes) * 60 + fSeconds + rSeconds) / 2M,
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
        var meanSeconds = Math.Round((decimal)(seconds % 60), 2);
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
            return _previousDataRow == null ? null : 0;
        return meanSeconds - firstMeanSeconds;
    }

    private void SetPrevRowMinutes()
    {
        //if (_previousDataRow != null)
        //{
        //    _forwardMinutesHorizontal = _forwardMinutesHorizontal == null ? _previousDataRow.ForwardMinutesHorizontal : null;
        //    _forwardMinutesVertical = _forwardMinutesVertical == null ? _previousDataRow.ForwardMinutesVertical : null;
        //    _reverseMinutesHorizontal = _reverseMinutesHorizontal == null && _isReverseStrokeEnabled ? _previousDataRow.ReverseMinutesHorizontal : null;
        //    _reverseMinutesVertical = _reverseMinutesVertical == null && _isReverseStrokeEnabled ? _previousDataRow.ReverseMinutesVertical : null;
        //}
    }

    private decimal? CalcRelativeAngleToPrevious(Plane plane)
    {
        switch (plane)
        {
            case Plane.Horizontal:
                return multipler * _relativeAngleHorizontal;
            case Plane.Vertical:
                return multipler * _relativeAngleVertical;
            default:
                return null;
        }
    }

    public void RecalcAllRelativeAngleFromFirst()
    {
        RelativeAngleToFirstHorizontal = CalcRelativeAngleFromFirst(Plane.Horizontal);
        RelativeAngleToFirstVertical = CalcRelativeAngleFromFirst(Plane.Vertical);
    }

    private decimal? CalcRelativeAngleFromFirst(Plane plane)
    {
        switch (plane)
        {
            case Plane.Horizontal:
                if (_previousDataRow == null)
                    return null;
                return _previousDataRow.RelativeAngleToPreviousHorizontal != null
                    ? RoundNullableDecimal(
                        _previousDataRow.RelativeAngleToFirstHorizontal + _relativeAngleToPreviousHorizontal, 2)
                    : _isLastRow ? 0 : 0; //TODO Нужно реализовать для корректного отображения последней строки

            case Plane.Vertical:
                if (_previousDataRow == null)
                    return null;
                return _previousDataRow.RelativeAngleToPreviousVertical != null
                    ? RoundNullableDecimal(
                        _previousDataRow.RelativeAngleToFirstVertical + _relativeAngleToPreviousVertical, 2)
                    : _isLastRow ? 0 : 0;
            default:
                return null;
        }
    }

    private static decimal? RoundNullableDecimal(decimal? value, int decimals)
    {
        if (value == null)
            return null;

        return Math.Round(value.Value, decimals, MidpointRounding.AwayFromZero);
    }

    [Browsable(false)]
    public decimal? LastPointAngleCoeficentHorizontal
    {
        get => _lastPointAngleCoeficentHorizontal;
        set => OrdinateStraightnessHorizontal = Position * value;
    }

    [Browsable(false)]
    public decimal? LastPointAngleCoeficentVertical
    {
        get => _lastPointAngleCoeficentVertical;
        set => OrdinateStraightnessVertical = Position * value;
    }
}