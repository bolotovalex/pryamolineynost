using LogicLibrary;
using PryamolineynostWF.Interfaces;

namespace PryamolineynostWF.Models.Level
{
    public class Angle : IUnit
    {
        private int _degree;
        private int _minutes;
        private int _seconds;

        public int Degree
        {
            get => _degree;
            set
            {
                _degree = value;
                Value = ConvertToInt();
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                _minutes = value;
                Value = ConvertToInt();
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                _seconds = value;
                Value = ConvertToInt();
            }
        }

        public int Value { get; private set; }
        public IUnit? LinkedUnit { get; set; }

        public Angle(int value, IUnit? linkedObject = null)
        {
            Value = value;
            LinkedUnit = linkedObject ?? new Micrometer(Value, this);
        }

        public Angle(int degree = 0, int minutes = 0, int seconds = 0, IUnit? linkedObject = null)
        {
            (_degree, _minutes, _seconds) = (degree, minutes, seconds);
            Value = ConvertToInt();
            LinkedUnit = linkedObject ?? new Micrometer(Value, this);
        }

        public void SetValue(int value)
        {
            Value = value;
            ConvertFromInt(value);
            LinkedUnit?.UpdateValue(value);
        }

        public void UpdateValue(int value)
        {
            Value = value;
            ConvertFromInt(value);
        }

        public int ConvertFromInt(int value)
        {
            throw new Exception("Invalid value");
        }

        public int ConvertToInt()
        {
            return Convert.ToInt32(Math.Tan(Degree) + Math.Tan(Minutes / 60) + Math.Tan(Seconds / 3600));
        }

        public static int? GetAngleValue(Angle? angle)
        {
            return angle?.Value;
        }

        public void UpdateFieldValue(string field, int value)
        {
            throw new NotImplementedException();
        }
    }
}