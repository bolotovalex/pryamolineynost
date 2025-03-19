using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator;

public class MeasurementTableModel : INotifyPropertyChanged
{
    private Plane _plane;
    private BindingList<MeasurementRowModel> _table;
    private int _step;
    private bool _isRevStrokeEnabled;
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

        { "ForwardDegreesHorizontal", "Пр.°" },
        { "ForwardMinutesHorizontal", "Пр.'" },
        { "ForwardSecondsHorizontal", "Пр.\"" },
        { "ReverseDegreesHorizontal", "Обр.°" },
        { "ReverseMinutesHorizontal", "Обр.'" },
        { "ReverseSecondsHorizontal", "Обр.\"" },
        { "FormatedMeanHorizontal", "Ср." },
        { "RelativeAngleHorizontal", "βi, угл. с" },
        { "RelativeAngleToPreviousHorizontal", "hi, мкм" },
        { "RelativeAngleToFirstHorizontal", "Ai, мкм" },
        { "OrdinateStraightnessHorizontal", "Bi, мкм" },
        { "StraightnessDeviationHorizontal", "Hi, мкм" },

        { "ForwardDegreesVertical", "Пр.°" },
        { "ForwardMinutesVertical", "Пр.'" },
        { "ForwardSecondsVertical", "Пр.\"" },
        { "ReverseDegreesVertical", "Обр.°" },
        { "ReverseMinutesVertical", "Обр.'" },
        { "ReverseSecondsVertical", "Обр.\"" },
        { "FormatedMeanVertical", "Ср." },
        { "RelativeAngleVertical", "βi, угл. с" },
        { "RelativeAngleToPreviousVertical", "hi, мкм" },
        { "RelativeAngleToFirstVertical", "Ai, мкм" },
        { "OrdinateStraightnessVertical", "Bi, мкм" },
        { "StraightnessDeviationVertical", "Hi, мкм" }
    };

    [Browsable(false)] public static readonly List<string> ReverseStrokeEnableColumns = new()
    {
        "ReverseDegreesHorizontal",
        "ReverseMinutesHorizontal",
        "ReverseSecondsHorizontal",
        "FormatedMeanHorizontal",
        "ReverseDegreesVertical",
        "ReverseMinutesVertical",
        "ReverseSecondsVertical",
        "FormatedMeanVertical"
    };

    [Browsable(false)] public static readonly List<string> AdditionFields = new()
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

    [Browsable(false)] public static readonly List<string> HorizontalFields = new()
    {
        "Position",
        "MeasurementLength",
        "ForwardDegreesHorizontal",
        "ForwardMinutesHorizontal",
        "ForwardSecondsHorizontal",
        "ReverseDegreesHorizontal",
        "ReverseMinutesHorizontal",
        "ReverseSecondsHorizontal",
        "FormatedMeanHorizontal",
        "RelativeAngleHorizontal",
        "RelativeAngleToPreviousHorizontal",
        "RelativeAngleToFirstHorizontal",
        "OrdinateStraightnessHorizontal",
        "StraightnessDeviationHorizontal"
    };

    [Browsable(false)] public static readonly List<string> VerticalFields = new()
    {
        "Position",
        "MeasurementLength",
        "ForwardDegreesVertical",
        "ForwardMinutesVertical",
        "ForwardSecondsVertical",
        "ReverseDegreesVertical",
        "ReverseMinutesVertical",
        "ReverseSecondsVertical",
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