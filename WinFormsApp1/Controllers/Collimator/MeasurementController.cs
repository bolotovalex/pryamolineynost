using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Controllers.Collimator
{
    
    public class MeasurementController
    {
        private MeasurementForm _view;
        private DataSet _dataSet;
        public MeasurementController(DataSet dataSet, MeasurementForm view)
        {
            _dataSet = dataSet;
            _view = view;
            //_view.dataGridView1.DataSource = _dataSet.Tables["Горизонтальная поверхность"];
        }

    }
}
