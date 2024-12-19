using System.Dynamic;

namespace LogicLibrary;

public class DataRow
{
    /// <summary>
    /// Класс для хранения точек измерения и расчета служебных параметров.
    /// </summary>
    // private const decimal coef;
    private int _position { get; set; } //Длина измерения, мм
    private int _step { get; set; } //Шаг
    private decimal _factProfile { get; set; } //Фактический профиль проверяемой поверхности, мкм
    private decimal _adjStraight { get; set; } //Прилегающая прямая, мкм
    private decimal _deviation { get; set; } //Отклонение, мкм
    private decimal _devationPerMeter { get; set; } //Отклонение на метре, мкм
    private decimal _midValue { get; set; } //Среднее значение, мкм
    private int _fStroke { get; set; } //Прямой ход, мкм
    private int _revStroke { get; set; } //Обратный ход, мкм
    private bool _revStrokeEnable { get; set; } //Включен-ли учет обратного хода
    private DataRow? _prevDataRow { get; set; } //Предыдущая строка
    private decimal _progrmaFactor { get; set; } //Коэффициент для расчета прилегающей прямой
    private int _fDegree { get; set; } //Градусы прямой ход
    private int _fMinutes { get; set; } //Минуты прямой ход
    private int _fSeconds { get; set; } //Секунды прямой ход
    private int _rDegree { get; set; } //Градусы обратный ход
    private int _rMinutes { get; set; } //Минуты обратный ход
    private int _rSeconds { get; set; } //Секунды обратный ход

    public decimal ProgrmaFactor
    {
        get => _progrmaFactor;
        set
        {
            _progrmaFactor = value;
            AdjStraight = value * _position;
            Deviation = _factProfile - _adjStraight;
        }
    }

    public bool RevStrokeEnable
    {
        get => _revStrokeEnable;
        set
        {
            _revStrokeEnable = value;
            UpdateMidValue();
        }
    }

    public int FStroke
    {
        get => _fStroke;
        set
        {
            _fStroke = value;
            UpdateMidValue();
            var a = IntToSeconds(value);
            (_fDegree, _fMinutes, _fSeconds) = OptimizeDegrees(0,0,IntToSeconds(value));
        }
    }

    public int RevStroke
    {
        get => _revStroke;
        set
        {
            _revStroke = value;
            UpdateMidValue();
            (_rDegree, _rMinutes, _rSeconds) = OptimizeDegrees(0, 0, IntToSeconds(value == int.MinValue ? 0 : value));
        }
    }

    public DataRow? PrevDataRow
    {
        get => _prevDataRow;
        set
        {
            _prevDataRow = value;
            FactProfile = _prevDataRow != null ? MidValue * _step / 1000 + _prevDataRow.FactProfile : MidValue * _step / 1000 ;
        }
    }

    public int Position
    {
        get => _position;
        set
        {
            _position = value;
            AdjStraight = _progrmaFactor * _position;
        }
    }

    public int Step
    {
        get => _step;
        set
        {
            FactProfile = _prevDataRow != null ? MidValue * _step / 1000 + _prevDataRow.FactProfile : MidValue * _step / 1000 ;
        }
    }

    public decimal FactProfile
    {
        get => _factProfile;
        private set
        {
            _factProfile = value;
            Deviation = _factProfile - _adjStraight;
        }
    }

    public decimal AdjStraight
    {
        get => _adjStraight;
        set
        {
            _adjStraight = value;
            Deviation = _factProfile - _adjStraight;
        }
    }

    public decimal Deviation
    {
        get => _deviation;
        set
        {
            _deviation = value;
        }
    }

    public decimal MidValue
    {
        get => _midValue;
        set
        {
            _midValue = value;
            FactProfile = _prevDataRow != null ? MidValue * _step / 1000 + _prevDataRow.FactProfile : MidValue * _step / 1000 ;
        }
    }

    public decimal DeviationPerMeter
    {
        get => _devationPerMeter;
        set
        {
            _devationPerMeter = value;
        }
    }

    public DataRow(int value, int step, DataRow? prevDataRow, bool revStrokeEnabled, Direction direction)
    {
        _step = step;
        _prevDataRow = prevDataRow;
        _revStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? _prevDataRow.Position + _step : 0;
        FStroke = direction == Direction.Forward ? value : 0;
        RevStroke = direction == Direction.Reverse ? value : int.MinValue;
    }

    public DataRow(int value, int step, DataRow? prevDataRow,
        bool revStrokeEnabled, Direction direction, AngleUnits unit)
    {
        _step = step;
        _prevDataRow = prevDataRow;
        _revStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? _prevDataRow.Position + _step : 0;
        switch (unit)
        {
            case AngleUnits.Degree:
                FDegree = direction == Direction.Forward ? value : 0;
                RevDegree = direction == Direction.Reverse ? value : 0;
                break;
            case AngleUnits.Minute:
                FMinutes = direction == Direction.Forward ?  value : 0;
                RevMinutes = direction == Direction.Reverse ? value : 0;
                break;
            case AngleUnits.Second:
                FSeconds = direction == Direction.Forward ? value : 0;
                RevSeconds = direction == Direction.Reverse ? value : 0;
                break;
        }
    }

    // пересчет свойств
    public void RecalcRow(int step, DataRow? prevDataRow, bool revStrokeEnabled, Units unit)
    {
        _step = step;
        _prevDataRow = prevDataRow;
        _revStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? _prevDataRow.Position + _step : 0;
        if (unit == Units.Micrometer)
        {
            FStroke = _fStroke;
            RevStroke = _revStroke;            
        }
        else if (unit == Units.Angle)
        {
            FDegree = _fDegree;
            FMinutes = _fMinutes;
            FSeconds = _fSeconds;
            RevDegree = _rDegree;
            RevMinutes = _rMinutes;
            RevSeconds = _rSeconds;
        }
    }

    //получение сток для печати



    public int FDegree { get => _fDegree; set 
        { 
            _fDegree = value % 360;
            _fStroke = DegreeToMicrometers(degree: value, minutes: _fMinutes, seconds: _fSeconds);
            UpdateMidValue();
        } }
    public int FMinutes { get => _fMinutes; set {
            (_fDegree, _fMinutes, _fSeconds) = OptimizeDegrees(_fDegree, value, _fSeconds);
            _fStroke = DegreeToMicrometers(degree: _fDegree, minutes: value, seconds: _fSeconds);
            UpdateMidValue();
        } }
    public int FSeconds { get => _fSeconds; set {
            (_fDegree, _fMinutes, _fSeconds) = OptimizeDegrees(_fDegree, _fMinutes, value);
            _fStroke = DegreeToMicrometers(degree: _fDegree, minutes: _fMinutes, seconds: value);
            UpdateMidValue();
        } }

    public int RevDegree
    {
        get => _rDegree; set
        {
            _rDegree = value % 360;
            _revStroke = DegreeToMicrometers(degree: value, minutes: _rMinutes, seconds: _rSeconds);
            UpdateMidValue();
        }
    }
    public int RevMinutes
    {
        get => _rMinutes; set
        {
            (_rDegree, _rMinutes, _rSeconds) = OptimizeDegrees(_rDegree, value, _rSeconds);
            _revStroke = DegreeToMicrometers(degree: _rDegree, minutes: value, seconds: _rSeconds);
            UpdateMidValue();
        }
    }
    public int RevSeconds
    {
        get => _rSeconds; set
        {
            (_rDegree, _rMinutes, _rSeconds) = OptimizeDegrees(_rDegree, _rMinutes, value);
            _revStroke = DegreeToMicrometers(degree: _rDegree, minutes: _rMinutes, seconds: value);
            UpdateMidValue();
        }
    }

    private (int degree, int minutes, int seconds) OptimizeDegrees(int degrees, int minutes, int seconds)
    {
        var calcSeconds = GetNumParts(seconds, 60);
        var optSeconds = calcSeconds.FractPart;
        var calcMinutes = GetNumParts(minutes + calcSeconds.IntPart, 60);
        var optMinutes = calcMinutes.FractPart;
        var optDegree = (degrees + calcMinutes.IntPart) % 360;
        return (optDegree, optMinutes, optSeconds);
    }

    private (int IntPart, int FractPart) GetNumParts(int number, int devider) => (number / devider, number % devider);

    //Перевод микрометры в секунды
    public int IntToSeconds(int value)
    {
        return (int)Math.Round(Math.Atan((double)value / 1000000) * (180 / Math.PI) * 3600);
    }
    
    public int DegreeToMicrometers(int degree = 0, int minutes = 0, int seconds = 0)
    {
        var deg = (double)degree + (double)minutes / 60D + (double)seconds / 3600D;
        return Convert.ToInt32(Math.Tan(deg * Math.PI / 180) * 1000000);
    }

    public string[] GetAllCellsStringArray()
    {
        ///<summary>
        ///Получение списка строк для графика
        /// </summary>
        return [Position.ToString(),
                Math.Round(Deviation,2).ToString(),
                _fStroke == int.MinValue ? "0": FStroke.ToString(),
                _revStroke == int.MinValue ? "0" : RevStroke.ToString(),
                FDegree.ToString(),
                FMinutes.ToString(),
                FSeconds.ToString(),
                RevDegree.ToString(),
                RevMinutes.ToString(),
                RevSeconds.ToString()];
    }
    public void UpdateMidValue()
    {
        MidValue = _revStroke != int.MinValue && _revStrokeEnable
                ? (_revStroke + _fStroke) / 2
                : this._fStroke;
    }
}