using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementTableModel
    {
        private string _name;
        private List<MeasurementRow> _table;

        public MeasurementTableModel(string name)
        {
            _name = name;
            _table = new List<MeasurementRow>();
        }

        public string Name { get => _name; }
        public List<MeasurementRow> Table { get => _table; }
    }
}
