using System;
using PryamolineynostNew.Interfaces;

namespace PryamolineynostNew.Models.Level
{
    public class Micrometer : IUnit
    {
        public int Value { get; private set; }

        public IUnit? LinkedUnit { get; set; }
        
        public Micrometer(int value, IUnit? linkedObject = null) 
        {
            Value = value;
            LinkedUnit = linkedObject ?? new Angle(Value, this);
        }

        public void SetValue(int value)
        {
            Value = value;
            LinkedUnit.UpdateValue(value);
        }

        public void UpdateValue(int value)
        {
            Value = value;
        }

        public void UpdateFieldValue(string field, int value)
        {
            
            throw new NotImplementedException();
        }
    }
}
