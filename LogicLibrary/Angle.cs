using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class Angle : IUnit
    {
        public int Degree
        {
            get => Degree;
            set
            {
                Degree = value;
                Value = 0;
            }
        }

        public int Minutes
        {
            get => Minutes;
            set
            {
                Minutes = value;
                Value = 0;
            }
        }

        public int Seconds
        {
            get => Seconds;
            set
            {
                Seconds = value;
                Value = 0;
            }
        }

        public int Value { 
            get => Value;
            set { Value = ConvertToInt(); }
        }

    public Angle(int degree, int minutes, int seconds)
    {
        CalcDegree(degree, minutes, seconds);
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
}

}