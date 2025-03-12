using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator
{
    public class MeasurementRow
    {
        private int _position; // Номер измерений
        private int _measurementLength; // Длина измерения, мм
        private int _stepSize; // Шаг

        private int _forwardDegrees; // Градусы прямой ход
        private int _forwardMinutes; // Минуты прямой ход
        private decimal _forwardSeconds; // Секунды прямой ход

        private int _reverseDegrees; // Градусы обратный ход
        private int _reverseMinutes; // Минуты обратный ход
        private decimal _reverseSeconds; // Секунды обратный ход

        private int _meanDegrees; // Средние градусы
        private int _meanMinutes; // Средние минуты
        private int _meanSeconds; // Средние секунды

        private bool _isReverseStrokeEnabled; // Включен ли учет обратного хода

        private MeasurementRow? _previousDataRow; // Предыдущая строка

        private decimal _relativeAngle; // bi Наклон проверяемых участков
        private decimal _relativeAngleToPrevious; // hi Наклон проверяемых участков относительно предыдущего
        private decimal _relativeAngleToFirst; // Hi Наклон проверяемых участков относительно первой точки

        private decimal _ordinateStraightness; // bi Ордината прямой величины в проверяемых точках
        private decimal _straightnessDeviation; // Hi Отклонения прямолинейности от направляющей

        
        public int Position { get => _position; set => _position = value; }
        public int MeasurementLength { get => _measurementLength; set => _measurementLength = value; }
        public int StepSize { get => _stepSize; set => _stepSize = value; }
        public int ForwardDegrees { get => _forwardDegrees; set => _forwardDegrees = value; }
        public int ForwardMinutes { get => _forwardMinutes; set => _forwardMinutes = value; }
        public decimal ForwardSeconds { get => _forwardSeconds; set => _forwardSeconds = value; }
        public int ReverseDegrees { get => _reverseDegrees; set => _reverseDegrees = value; }
        public int ReverseMinutes { get => _reverseMinutes; set => _reverseMinutes = value; }
        public decimal ReverseSeconds { get => _reverseSeconds; set => _reverseSeconds = value; }
        public int MeanDegrees { get => _meanDegrees; private set => _meanDegrees = value; }
        public int MeanMinutes { get => _meanMinutes; private set => _meanMinutes = value; }
        public int MeanSeconds { get => _meanSeconds; private set => _meanSeconds = value; }
        public bool IsReverseStrokeEnabled { get => _isReverseStrokeEnabled; set => _isReverseStrokeEnabled = value; }
        public MeasurementRow? PreviousDataRow { get => _previousDataRow; set => _previousDataRow = value; }
        public decimal RelativeAngle { get => _relativeAngle; private set => _relativeAngle = value; }
        public decimal RelativeAngleToPrevious { get => _relativeAngleToPrevious; private set => _relativeAngleToPrevious = value; }
        public decimal RelativeAngleToFirst { get => _relativeAngleToFirst; private set => _relativeAngleToFirst = value; }
        public decimal OrdinateStraightness { get => _ordinateStraightness; private set => _ordinateStraightness = value; }
        public decimal StraightnessDeviation { get => _straightnessDeviation; private set => _straightnessDeviation = value; }

        public MeasurementRow(int step, MeasurementRow? prevRow, bool revStrokeEnable)
        {
            if (prevRow != null)
            {
                IsReverseStrokeEnabled = revStrokeEnable;
                PreviousDataRow = prevRow;
                Position = prevRow.Position + 1;
                StepSize = step;
                MeasurementLength = prevRow.MeasurementLength + StepSize;

                ForwardDegrees = int.MinValue;
                ForwardMinutes = int.MinValue;
                ForwardSeconds = int.MinValue;
                ReverseDegrees = int.MinValue;
                ReverseMinutes = int.MinValue;
                ReverseSeconds = int.MinValue;
                
            }
            else
            {
                IsReverseStrokeEnabled = revStrokeEnable;
                PreviousDataRow = null;
                Position = 0;
                StepSize = step;
                MeasurementLength = 0;
                
                ForwardDegrees = 0;
                ForwardMinutes = 0;
                ForwardSeconds = 0;
                ReverseDegrees = 0;
                ReverseMinutes = 0;
                ReverseSeconds = 0;
            }


        }
    }
}
