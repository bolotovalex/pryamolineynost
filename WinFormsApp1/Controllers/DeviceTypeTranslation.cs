using PryamolineynostWF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Controllers
{
    public static class DeviceTypeTranslation
    {
        public static readonly Dictionary<MeasurementDevices, string> GetTranslation = 
            new Dictionary<MeasurementDevices, string>() { 
                { MeasurementDevices.Level, "Уровень"},
                { MeasurementDevices.Collimator, "Автоколлиматор"} 
            };
    }
}
