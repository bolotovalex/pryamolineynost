using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class Angle
    {
        public int Degree { get; init; }
        public int Minutes { get; init; }
        public int Seconds { get; init; }

        public Angle(int degree, int minutes, int seconds)
        {
            var calcSeconds = GetNumParts(seconds, 60);
            seconds = calcSeconds.FractPart;
            var calcMinutes = GetNumParts(minutes, 60);
            minutes = calcMinutes.FractPart + calcSeconds.IntPart;
            Degree = degree + calcMinutes.IntPart;
        }

        private (int IntPart, int FractPart) GetNumParts(int number,int devider) => 
            (number / devider, number % devider);

        public Micrometer ConvertToMicrometers()
        {
            return new Micrometer(Convert.ToInt32(Math.Tan(Degree) + Math.Tan(Minutes / 60) + Math.Tan(Seconds / 3600)));
        }
        
    }
}
