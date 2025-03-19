using System.ComponentModel;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementTableModel : INotifyPropertyChanged
    {
        private Plane _plane;
        private BindingList<CombinedMeasurementRowModel> _table;
        
        private BindingList<MeasurementRowModel> _horizontalTable;
        private BindingList<MeasurementRowModel> _verticalTable;
        public BindingList<CombinedMeasurementRowModel> _combinedTable;

        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isRevStrokeEnabled;
        public MeasurementTableModel(Plane plane)
        {
            _horizontalTable = new BindingList<MeasurementRowModel>();
            _verticalTable = new BindingList<MeasurementRowModel>();
            Table = CreateCombinedBindingList(_horizontalTable, _verticalTable);
            Plane = plane;

        }

        public BindingList<CombinedMeasurementRowModel> Table { get; private set; }

        public Plane Plane
        {
            get => _plane;
            set
            {
                if (_plane != value)
                {
                    switch (value)
                    {
                        case Plane.Horizontal:
                            
                            break;
                        case Plane.Vertical:
                            
                            break;
                        case Plane.Both:
                            
                            break;
                    }
                }
                
                _plane = value;
            }
        }

        public bool IsRevStrokeEnabled
        {
            get => _isRevStrokeEnabled;
            set
            {
                _isRevStrokeEnabled = value;
                foreach (var row in _horizontalTable)
                    row.IsReverseStrokeEnabled = _isRevStrokeEnabled;
                foreach (var row in _verticalTable)
                    row.IsReverseStrokeEnabled = _isRevStrokeEnabled;
            }
        }

        public MeasurementRowModel HorizontalRow { get; set; }
        public MeasurementRowModel VerticalRow { get; set; }

        public BindingList<CombinedMeasurementRowModel> CreateCombinedBindingList(BindingList<MeasurementRowModel> horizontalTable, BindingList<MeasurementRowModel> verticalTable)
        {
            var combinedList = new BindingList<CombinedMeasurementRowModel>();

            // Предполагаем, что обе таблицы имеют одинаковое количество строк
            for (int i = 0; i < horizontalTable.Count; i++)
            {
                var horizontalRow = horizontalTable[i];
                var verticalRow = verticalTable[i];

                combinedList.Add(new CombinedMeasurementRowModel
                {
                    // Общие поля
                    Position = horizontalRow.Position,
                    MeasurementLength = horizontalRow.MeasurementLength,
                    
                    ForwardDegreesHorizontal = horizontalRow.ForwardDegrees,
                    ForwardMinutesHorizontal  = horizontalRow.ForwardMinutes,
                    ForwardSecondsHorizontal = horizontalRow.ForwardSeconds,
                    ReverseDegreesHorizontal = horizontalRow.ReverseDegrees,
                    ReverseMinutesHorizontal = horizontalRow.ReverseMinutes,
                    ReverseSecondsHorizontal = horizontalRow.ReverseSeconds,
                    
                    MeanHorizontal = horizontalRow.MeanValue,
                    RelativeAngleHorizontal = horizontalRow.RelativeAngle,
                    RelativeAngleToPreviousHorizontal = horizontalRow.RelativeAngleToPrevious,
                    RelativeAngleToFirstHorizontal = horizontalRow.RelativeAngleToFirst,
                    OrdinateStraightnessHorizontal = horizontalRow.OrdinateStraightness,
                    StraightnessDeviationHorizontal = horizontalRow.StraightnessDeviation,
                    
                    ForwardDegreesVertical = verticalRow.ForwardDegrees,
                    ForwardMinutesVertical = verticalRow.ForwardMinutes,
                    ForwardSecondsVertical = verticalRow.ForwardSeconds,
                    ReverseDegreesVertical = verticalRow.ReverseDegrees,
                    ReverseMinutesVertical = verticalRow.ReverseMinutes,
                    ReverseSecondsVertical = verticalRow.ReverseSeconds,

                    MeanVertical = verticalRow.MeanValue,
                    RelativeAngleVertical = verticalRow.RelativeAngle,
                    RelativeAngleToPreviousVertical = verticalRow.RelativeAngleToPrevious,
                    RelativeAngleToFirstVertical = verticalRow.RelativeAngleToFirst,
                    OrdinateStraightnessVertical = verticalRow.OrdinateStraightness,
                    StraightnessDeviationVertical = verticalRow.StraightnessDeviation
                });
            }
            return combinedList;
        }

        public static readonly Dictionary<string, string> ColumnHeaders = new Dictionary<string, string>
        {
            { "Position", "No" },   // Русский
            { "MeasurementLength", "Позиция" },

            { "ForwardDegreesHorizontal", "Пр.°" },
            { "ForwardMinutesHorizontal", "Пр.'" },
            { "ForwardSecondsHorizontal", "Пр.\"" },
            { "ReverseDegreesHorizontal", "Обр.°" },
            { "ReverseMinutesHorizontal", "Обр.'" },
            { "ReverseSecondsHorizontal", "Обр.\"" },
            { "MeanHorizontal", "Ср." },
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
            { "MeanVertical", "Ср." },
            { "RelativeAngleVertical", "βi, угл. с" },
            { "RelativeAngleToPreviousVertical", "hi, мкм" },
            { "RelativeAngleToFirstVertical", "Ai, мкм" },
            { "OrdinateStraightnessVertical", "Bi, мкм" },
            { "StraightnessDeviationVertical", "Hi, мкм" }
        };

        public static readonly List<string> ReverseStrokeEnableColumns = new List<string>
        {
            "ReverseDegreesHorizontal",
            "ReverseMinutesHorizontal",
            "ReverseSecondsHorizontal",
            "MeanHorizontal",
            "ReverseDegreesVertical",
            "ReverseMinutesVertical",
            "ReverseSecondsVertical",
            "MeanVertical"
        };

        public static readonly List<string> AdditionFields = new List<string>
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

        public static readonly List<string> HorizontalFields = new List<string>
        {
            "Position",
            "MeasurementLength",
            "ForwardDegreesHorizontal",
            "ForwardMinutesHorizontal",
            "ForwardSecondsHorizontal",
            "ReverseDegreesHorizontal",
            "ReverseMinutesHorizontal",
            "ReverseSecondsHorizontal",
            "MeanHorizontal",
            "RelativeAngleHorizontal",
            "RelativeAngleToPreviousHorizontal",
            "RelativeAngleToFirstHorizontal",
            "OrdinateStraightnessHorizontal",
            "StraightnessDeviationHorizontal"
        };

        public static readonly List<string> VerticalFields = new List<string>
        {
            "Position",
            "MeasurementLength",
            "ForwardDegreesVertical",
            "ForwardMinutesVertical",
            "ForwardSecondsVertical",
            "ReverseDegreesVertical",
            "ReverseMinutesVertical",
            "ReverseSecondsVertical",
            "MeanVertical",
            "RelativeAngleVertical",
            "RelativeAngleToPreviousVertical",
            "RelativeAngleToFirstVertical",
            "OrdinateStraightnessVertical",
            "StraightnessDeviationVertical"
        };

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
