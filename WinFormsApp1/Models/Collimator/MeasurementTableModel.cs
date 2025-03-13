using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementTableModel
    {
        private string _name;
        private BindingList<MeasurementRowModel> _table;
        public const int IntPlaceholder = int.MinValue;
        public const decimal DecimalPlaceholder = decimal.MinValue;

        public MeasurementTableModel(string name)
        {
            _name = name;
            _table = new BindingList<MeasurementRowModel>();
        }

        public string Name { get => _name; }
        public BindingList<MeasurementRowModel> Table { get => _table; }
    }
}
