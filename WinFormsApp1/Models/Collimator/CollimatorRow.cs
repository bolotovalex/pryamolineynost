using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Models.Collimator
{
    public class CollimatorRow
    {
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

        private CollimatorRow? _previousDataRow; // Предыдущая строка

        private decimal _relativeAngle; // bi Наклон проверяемых участков
        private decimal _relativeAngleToPrevious; // hi Наклон проверяемых участков относительно предыдущего
        private decimal _relativeAngleToFirst; // Hi Наклон проверяемых участков относительно первой точки

        private decimal _ordinateStraightness; // bi Ордината прямой величины в проверяемых точках
        private decimal _straightnessDeviation; // Hi Отклонения прямолинейности от направляющей

        
        public int MeasurementLength { get => _measurementLength; set => _measurementLength = value; }
        public int StepSize { get => _stepSize; set => _stepSize = value; }
        public int ForwardDegrees { get => _forwardDegrees; set => _forwardDegrees = value; }
        public int ForwardMinutes { get => _forwardMinutes; set => _forwardMinutes = value; }
        public decimal ForwardSeconds { get => _forwardSeconds; set => _forwardSeconds = value; }
        public int ReverseDegrees { get => _reverseDegrees; set => _reverseDegrees = value; }
        public int ReverseMinutes { get => _reverseMinutes; set => _reverseMinutes = value; }
        public decimal ReverseSeconds { get => _reverseSeconds; set => _reverseSeconds = value; }
        public int MeanDegrees { get => _meanDegrees; set => _meanDegrees = value; }
        public int MeanMinutes { get => _meanMinutes; set => _meanMinutes = value; }
        public int MeanSeconds { get => _meanSeconds; set => _meanSeconds = value; }
        public bool IsReverseStrokeEnabled { get => _isReverseStrokeEnabled; set => _isReverseStrokeEnabled = value; }
        public CollimatorRow? PreviousDataRow { get => _previousDataRow; set => _previousDataRow = value; }
        public decimal RelativeAngle { get => _relativeAngle; set => _relativeAngle = value; }
        public decimal RelativeAngleToPrevious { get => _relativeAngleToPrevious; set => _relativeAngleToPrevious = value; }
        public decimal RelativeAngleToFirst { get => _relativeAngleToFirst; set => _relativeAngleToFirst = value; }
        public decimal OrdinateStraightness { get => _ordinateStraightness; set => _ordinateStraightness = value; }
        public decimal StraightnessDeviation { get => _straightnessDeviation; set => _straightnessDeviation = value; }
    }
}
