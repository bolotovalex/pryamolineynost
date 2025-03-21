using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator;

public class MeasurementTableModel : INotifyPropertyChanged
{
    private Plane _plane;
    private BindingList<MeasurementRowModel> _table;
    private int _step;
    private bool _isRevStrokeEnabled;
    private decimal? _firstRelativeAngle;
    public event PropertyChangedEventHandler PropertyChanged;

    public MeasurementTableModel(Plane plane, int step)
    {
        Plane = plane;
        _step = step;
        Table = new BindingList<MeasurementRowModel>();
        
    }

    public int Step
    {
        get => _step;
        set
        {
            foreach (var row in _table)
                row.StepSize = _step;
        }
    }

    public Plane Plane
    {
        get => _plane;
        set
        {
            if (_plane != value)
                switch (value)
                {
                    case Plane.Horizontal:

                        break;
                    case Plane.Vertical:

                        break;
                    case Plane.Both:

                        break;
                }

            _plane = value;
            OnPropertyChanged(nameof(Plane));
        }
    }

    public bool IsRevStrokeEnabled
    {
        get => _isRevStrokeEnabled;
        set
        {
            _isRevStrokeEnabled = value;
            foreach (var row in _table)
                row.IsReverseStrokeEnabled = _isRevStrokeEnabled;
        }
    }

    public BindingList<MeasurementRowModel> Table
    {
        get => _table;
        private set => _table = value;
    }

    public static readonly Dictionary<string, string> ColumnHeaders = new()
    {
        { "Position", "No" }, // Русский
        { "MeasurementLength", "Позиция" },

        { "ForwardMinutesHorizontal", "Пр.'" },
        { "ForwardSecondsHorizontal", "Пр.\"" },
        { "ReverseMinutesHorizontal", "Обр.'" },
        { "ReverseSecondsHorizontal", "Обр.\"" },
        { "FormatedMeanHorizontal", "Ср." },
        { "RelativeAngleHorizontal", "βi, угл. с" },
        { "RelativeAngleToPreviousHorizontal", "hi, мкм" },
        { "RelativeAngleToFirstHorizontal", "Ai, мкм" },
        { "OrdinateStraightnessHorizontal", "Bi, мкм" },
        { "StraightnessDeviationHorizontal", "Hi, мкм" },

        { "ForwardMinutesVertical", "Пр.'" },
        { "ForwardSecondsVertical", "Пр.\"" },
        { "ReverseMinutesVertical", "Обр.'" },
        { "ReverseSecondsVertical", "Обр.\"" },
        { "FormatedMeanVertical", "Ср." },
        { "RelativeAngleVertical", "βi, угл. с" },
        { "RelativeAngleToPreviousVertical", "hi, мкм" },
        { "RelativeAngleToFirstVertical", "Ai, мкм" },
        { "OrdinateStraightnessVertical", "Bi, мкм" },
        { "StraightnessDeviationVertical", "Hi, мкм" }
    };
    public static readonly List<string> ReverseStrokeEnableColumns = new()
    {
        "ReverseMinutesHorizontal",
        "ReverseSecondsHorizontal",
        "FormatedMeanHorizontal",
        "ReverseMinutesVertical",
        "ReverseSecondsVertical",
        "FormatedMeanVertical"
    };
    public static readonly List<string> AdditionFields = new()
    {
        "RelativeAngleHorizontal",
        "RelativeAngleToPreviousHorizontal",
        "RelativeAngleToFirstHorizontal",
        "OrdinateStraightnessHorizontal",
        "StraightnessDeviationHorizontal",
        "RelativeAngleVertical",
        "RelativeAngleToPreviousVertical",
        "RelativeAngleToFirstVertical",
        "OrdinateStraightnessVertical",
        "StraightnessDeviationVertical"
    };
    public static readonly List<string> HorizontalFields = new()
    {
        "Position",
        "MeasurementLength",
        "ForwardMinutesHorizontal",
        "ForwardSecondsHorizontal",
        "ReverseMinutesHorizontal",
        "ReverseSecondsHorizontal",
        "FormatedMeanHorizontal",
        "RelativeAngleHorizontal",
        "RelativeAngleToPreviousHorizontal",
        "RelativeAngleToFirstHorizontal",
        "OrdinateStraightnessHorizontal",
        "StraightnessDeviationHorizontal"
    };
    public static readonly List<string> VerticalFields = new()
    {
        "Position",
        "MeasurementLength",
        "ForwardMinutesVertical",
        "ForwardSecondsVertical",
        "ReverseMinutesVertical",
        "ReverseSecondsVertical",
        "FormatedMeanVertical",
        "RelativeAngleVertical",
        "RelativeAngleToPreviousVertical",
        "RelativeAngleToFirstVertical",
        "OrdinateStraightnessVertical",
        "StraightnessDeviationVertical"
    };
    public static readonly List<string> ReadonlyColumns = new()
    {
        "Position",
        "MeasurementLength",
        "FormatedMeanHorizontal",
        "RelativeAngleHorizontal",
        "RelativeAngleToPreviousHorizontal",
        "RelativeAngleToFirstHorizontal",
        "OrdinateStraightnessHorizontal",
        "StraightnessDeviationHorizontal",
        "FormatedMeanVertical",
        "RelativeAngleVertical",
        "RelativeAngleToPreviousVertical",
        "RelativeAngleToFirstVertical",
        "OrdinateStraightnessVertical",
        "StraightnessDeviationVertical"
    };
    

    [Browsable(false)]
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}