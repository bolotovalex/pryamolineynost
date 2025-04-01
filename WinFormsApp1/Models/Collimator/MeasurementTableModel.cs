using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator;

public class MeasurementTableModel : INotifyPropertyChanged
{
    private Plane _plane;
    private BindingList<MeasurementRowModel> _table;
    private decimal? _firstMeanAngle_Horizontal;
    private decimal? _firstMeanAngle_Vertical;
    private decimal? _lastRelativeAngleToFirstHorizontal;
    private decimal? _lastRelativeAngleToFirstVertical;
    private int _step;
    private bool _isRevStrokeEnabled;

    public event PropertyChangedEventHandler PropertyChanged;


    public MeasurementTableModel(Plane plane, int step)
    {
        Plane = plane;
        _step = step;
        _table = new BindingList<MeasurementRowModel>();
        _table.Add(new MeasurementRowModel(_step,null,_isRevStrokeEnabled));
        _table.Add(new MeasurementRowModel(_step, _table[^1], _isRevStrokeEnabled));
        _table[1].PropertyChanged += OnRow1PropertyChanged;
    }

    public int Step
    {
        get => _step;
        set
        {
            _step = value;
            foreach (var row in _table)
                row.StepSize = _step;
            RecalAllFields();
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

    public decimal? FirstMeanAngle_Horizontal
    {
        get => _firstMeanAngle_Horizontal;
        set
        {
            _firstMeanAngle_Horizontal = value;
            for (var i = 2; i < _table.Count; i++)
            {
                _table[i].FirstMeanAngle_Horizontal = _firstMeanAngle_Horizontal;
            }
        }
    }

    public decimal? FirstMeanAngle_Vertical
    {
        get => _firstMeanAngle_Vertical;
        set
        {
            _firstMeanAngle_Vertical = value;
            for (var i = 2; i < _table.Count; i++)
            {
                _table[i].FirstMeanAngle_Vertical = value;
            }
        }
    }

    private void OnRow1PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MeasurementRowModel.MeanSecondsHorizontal))
        {
            FirstMeanAngle_Horizontal = _table[1].MeanSecondsHorizontal;
        }
        else if (e.PropertyName == nameof(MeasurementRowModel.MeanSecondsVertical))
        {
            FirstMeanAngle_Vertical = _table[1].MeanSecondsVertical;
        }
    }


    public BindingList<MeasurementRowModel> Table
    {
        get => _table;
        private set => _table = value;
    }
    
    public void UpdateTableRow(int rowIndex)
    {
        var row = _table[rowIndex];
        UpdateRows(rowIndex, row);
        RecalcRelativeAngleToFirst(rowIndex);
    }

    private void RecalcRelativeAngleToFirst(int rowIndex)
    {
        for (var i = rowIndex - 1; i < _table.Count; i++)
        {
            _table[i].RecalcAllRelativeAngleFromFirst();
            
        }
    }



    public void UpdateRows(int rowIndex, MeasurementRowModel? row)
    {
        var horizontalForwardHasValue = row.ForwardMinutesHorizontal.HasValue || row.ForwardSecondsHorizontal.HasValue;
        var horizontalReverseHasValue = row.ReverseMinutesHorizontal.HasValue || row.ReverseSecondsHorizontal.HasValue;
        var verticalForwardHasValue = row.ForwardMinutesVertical.HasValue || row.ForwardSecondsVertical.HasValue;
        var verticalReverseHasValue = row.ReverseMinutesVertical.HasValue || row.ReverseSecondsVertical.HasValue;

        if (Table.Count <= rowIndex + 1)
        {
            switch (Plane)
            {
                case Enums.Plane.Horizontal when !horizontalForwardHasValue &&
                                                 (IsRevStrokeEnabled || horizontalReverseHasValue):
                case Enums.Plane.Vertical
                    when !verticalForwardHasValue && (IsRevStrokeEnabled || !verticalReverseHasValue):
                case Enums.Plane.Both when !horizontalForwardHasValue && !verticalForwardHasValue &&
                                           (!IsRevStrokeEnabled ||
                                            (!verticalReverseHasValue &&
                                             !horizontalForwardHasValue)):
                    return;
                default:
                    _table.Add(new MeasurementRowModel(_step, _table[^1], _isRevStrokeEnabled));
                    LastRelativeAngleToFirstHorizontal = _table[^1].RelativeAngleToFirstHorizontal;
                    LastRelativeAngleToFirstVertical = _table[^1].RelativeAngleToFirstVertical;
                    _table[^1].FirstMeanAngle_Horizontal = _firstMeanAngle_Horizontal;
                    _table[^1].FirstMeanAngle_Vertical = _firstMeanAngle_Vertical;
                    break;
            }
        }
        else
        {
            switch (Plane)
            {
                case Enums.Plane.Horizontal:
                    {
                        if (horizontalForwardHasValue && (IsRevStrokeEnabled || horizontalReverseHasValue))
                        {
                            Table.RemoveAt(rowIndex);
                            UpdatePositions();

                        }

                        break;
                    }
                case Enums.Plane.Vertical:
                    {
                        if (verticalForwardHasValue || (IsRevStrokeEnabled || !verticalReverseHasValue))
                        {
                            Table.RemoveAt(rowIndex);
                            UpdatePositions();
                        }

                        break;
                    }
                case Enums.Plane.Both:
                    {
                        if (!horizontalForwardHasValue && !verticalForwardHasValue && (IsRevStrokeEnabled ||
                                (!verticalReverseHasValue &&
                                 !horizontalForwardHasValue)))
                        {
                            Table.RemoveAt(rowIndex);
                            UpdatePositions();
                        }

                        break;
                    }
            }
            
        }
        RecalAllFields();
    }

    private void RecalAllFields()
    {
        for (var i = 1; i< _table.Count - 2; i++)
        {
            _table[i].ForwardMinutesHorizontal = _table[i].ForwardMinutesHorizontal;
            _table[i].ForwardMinutesVertical = _table[i].ForwardMinutesVertical;
            _table[i].ReverseSecondsHorizontal = _table[i].ReverseSecondsHorizontal;
            _table[i].ReverseSecondsVertical = _table[i].ReverseSecondsVertical;
            _table[i].FirstMeanAngle_Horizontal = _firstMeanAngle_Horizontal;
            _table[i].FirstMeanAngle_Vertical = _firstMeanAngle_Vertical;
        }
        LastRelativeAngleToFirstHorizontal = _table[_table.Count - 2].RelativeAngleToFirstHorizontal;
        LastRelativeAngleToFirstVertical = _table[_table.Count - 2].RelativeAngleToFirstVertical;
    }

    private decimal? LastRelativeAngleToFirstHorizontal
    {
        get => _lastRelativeAngleToFirstHorizontal;
        set
        {
            _lastRelativeAngleToFirstHorizontal = value;
            var coef = _lastRelativeAngleToFirstHorizontal != null ? _lastRelativeAngleToFirstHorizontal / (_table.Count - 2) : null;
            for (var i = 1; i < _table.Count - 1; i++)
            {
                _table[i].LastPointAngleCoeficentHorizontal = coef;
            }
        }
    }

    private decimal? LastRelativeAngleToFirstVertical
    {
        get => _lastRelativeAngleToFirstVertical; 
        set
        {
            var coef = _lastRelativeAngleToFirstVertical != null ? _lastRelativeAngleToFirstVertical / (_table.Count - 2) : null;
            for (var i = 1; i < _table.Count-1; i++)
            {
                _table[i].LastPointAngleCoeficentVertical = coef;
            }
        }
    }


    private void UpdatePositions()
    {
        for (var i = 1; i < Table.Count; i++)
        {
            var row = Table[i];
            row.PreviousDataRow = Table[i - 1];
            row.UpdatePosition(i);
        }
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

    public static readonly Dictionary<string, string> ColumnFormat = new()
    {
        { "Position", "N0" },
        { "MeasurementLength", "N0" },
        { "ForwardMinutesHorizontal", "N0" },
        { "ForwardSecondsHorizontal", "0.00" },
        { "ReverseMinutesHorizontal", "N0" },
        { "ReverseSecondsHorizontal", "0.00" },
        { "FormatedMeanHorizontal", "" },
        { "RelativeAngleHorizontal", "0.00" },
        { "RelativeAngleToPreviousHorizontal", "0.00" },
        { "RelativeAngleToFirstHorizontal", "0.00" },
        { "OrdinateStraightnessHorizontal", "0.00" },
        { "StraightnessDeviationHorizontal", "0.00" },

        { "ForwardMinutesVertical", "N0" },
        { "ForwardSecondsVertical", "0.00" },
        { "ReverseMinutesVertical", "N0" },
        { "ReverseSecondsVertical", "0.00" },
        { "FormatedMeanVertical", "" },
        { "RelativeAngleVertical", "0.00" },
        { "RelativeAngleToPreviousVertical", "0.00" },
        { "RelativeAngleToFirstVertical", "0.00" },
        { "OrdinateStraightnessVertical", "0.00" },
        { "StraightnessDeviationVertical", "0.00" }

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