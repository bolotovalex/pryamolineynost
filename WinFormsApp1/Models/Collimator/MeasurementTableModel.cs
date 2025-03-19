using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PryamolineynostWF.Enums;
using PryamolineynostWF.Services;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementTableModel : INotifyPropertyChanged
    {
        private string _name;
        private Plane _plane;
        private BindingList<CombinedMeasurementRowModel> _table;
        
        private BindingList<MeasurementRowModel> _horizontalTable;
        private BindingList<MeasurementRowModel> _verticalTable;
        public BindingList<CombinedMeasurementRowModel> _combinedTable;

        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isRevStrokeEnabled;
        public MeasurementTableModel(Plane plane)
        {
            Table = new BindingList<MeasurementRowModel>();
            Plane = plane;

        }


        public BindingList<MeasurementRowModel> Table 
        {
            get => _table; 
            private set => _table = value; 
        }
        
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
                            _name = "Горизонтальная";
                            
                            break;
                        case Plane.Vertical:
                            _name = "Вертикальная";
                            break;
                        case Plane.Both:
                            _name = "Горизовнтальная и вертикальная";
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
                foreach (var row in Table)
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
                    
                    MeanSecondsHorizontal = horizontalRow.MeanValue,
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

                    MeanSecondsVertical = verticalRow.MeanValue,
                    RelativeAngleVertical = verticalRow.RelativeAngle,
                    RelativeAngleToPreviousVertical = verticalRow.RelativeAngleToPrevious,
                    RelativeAngleToFirstVertical = verticalRow.RelativeAngleToFirst,
                    OrdinateStraightnessVertical = verticalRow.OrdinateStraightness,
                    StraightnessDeviationVertical = verticalRow.StraightnessDeviation
                });
            }
            return combinedList;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
