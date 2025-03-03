using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PryamolineynostWF.Models;

namespace PryamolineynostWF.Controllers.Collimator
{
    
    public class MeasurementController
    {
        private MeasurementForm _view;
        private MeasurementTable _dataSet;
        private Enums.Plane? _selectedPlane;
        public MeasurementController(MeasurementForm view, MeasurementTable dataSet, Enums.Plane? selectedPlane)
        {
            _dataSet = dataSet;
            _view = view;
            _selectedPlane = selectedPlane;
            _view.cbSelectedPlaneChanged += ComboBox1_SelectedValueChange;
        }

        public Enums.Plane? SelectedPlane
        {
            get => _selectedPlane;
            set 
            {
                _selectedPlane = value;
                _view.cbPlaneUse.SelectedValue = value;
            }
        }
        
        private void ComboBox1_SelectedValueChange(object? sender, EventArgs e)
        {
            if (_view.cbPlaneUse.SelectedValue is PryamolineynostWF.Enums.Plane selected)
            {
                _selectedPlane = selected;
            }
            //else
            //{
            //    _selectedPlane = null;
            //}
        }
    }
}
