using System;
using PryamolineynostNew.Interfaces;

namespace PryamolineynostNew.Models.Level
{
    public class Angle : IUnit
    {
        public int Degree
        {
            get => Degree;
            set
            {
                Degree = value;
                Value = ConvertToInt();
            }
        }

        public int Minutes
        {
            get => Minutes;
            set
            {
                Minutes = value;
                Value = ConvertToInt();
            }
        }

        public int Seconds
        {
            get => Seconds;
            set
            {
                Seconds = value;
                Value = ConvertToInt();
            }
        }

        public int Value { get; private set; }

        public Angle(int value, IUnit? linkedObject = null) 
        {
            Value = value;
            LinkedUnit = linkedObject ?? new Micrometer(Value, this);
        }

        public Angle(int degree = 0, int minutes = 0, int seconds = 0, IUnit? linkedObject = null)
        {
            (Degree, Minutes, Seconds) = (degree, minutes, seconds);
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

        public void UpdateFieldValue(string field, int value)
        {
            throw new NotImplementedException();
        }

        public int ConvertFromInt(int value)
        {
            throw new Exception("Invalid value");
            //TODO
        }

        private void CalcDegree(int degree = 0, int minutes = 0, int seconds = 0)
        {
            var calcSeconds = GetNumParts(seconds, 60);
            seconds = calcSeconds.FractPart;
            var calcMinutes = GetNumParts(minutes, 60);
            minutes = calcMinutes.FractPart + calcSeconds.IntPart;
            Degree = degree + calcMinutes.IntPart;
        }

        private (int IntPart, int FractPart) GetNumParts(int number, int devider) =>
            (number / devider, number % devider);

        public int ConvertToInt()
        {
            return Convert.ToInt32(Math.Tan(Degree) + Math.Tan(Minutes / 60) + Math.Tan(Seconds / 3600));
        }


        
        public IUnit? LinkedUnit { get; set; }
    }
}