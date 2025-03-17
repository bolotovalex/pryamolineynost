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
        private BindingList<MeasurementRowModel> _table;
        public const int IntPlaceholder = int.MinValue;
        public const decimal DecimalPlaceholder = decimal.MinValue;
        public event PropertyChangedEventHandler PropertyChanged;
        public MeasurementTableModel(Plane plane)
        {
            Table = new BindingList<MeasurementRowModel>();
            Plane = plane;
        }

        public string Name { get => _name; }
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
                _plane = value;
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
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
