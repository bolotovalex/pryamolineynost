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
            MidValue = _revStroke != int.MinValue && _revStrokeEnable
                ? (_revStroke + _fStroke) / 2
                : _fStroke;
        }
    }

    public int FStroke
    {
        get => _fStroke;
        set
        {
            _fStroke = value;
            MidValue = _revStroke != int.MinValue && _revStrokeEnable
                ? (_revStroke + _fStroke) / 2
                : _fStroke;
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
            MidValue = _revStroke != int.MinValue && _revStrokeEnable
                ? (_revStroke + _fStroke) / 2
                : this._fStroke;
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

    public DataRow(int fStroke, int revStroke, int step, DataRow? prevDataRow, bool revStrokeEnabled)
    {
        _step = step;
        _prevDataRow = prevDataRow;
        _revStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? _prevDataRow.Position + _step : 0;
        FStroke = fStroke;
        RevStroke = revStroke;
    }

    // пересчет свойств
    public void RecalcRow(int fStroke, int revStroke, int step, DataRow? prevDataRow, bool revStrokeEnabled)
    {
        _step = step;
        _prevDataRow = prevDataRow;
        _revStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? _prevDataRow.Position + _step : 0;
        FStroke = fStroke;
        RevStroke = revStroke;
    }

    //получение сток для печати

    public int FDegree { get => _fDegree; set 
        { 
            _fDegree = value % 360;
            // FStroke = Convert.ToInt32((_fDegree * 3600 + _fMinutes * 60 + _fSeconds) * coef) * (_step / 1000); //TODO
        } }
    public int FMinutes { get => _fMinutes; set {
            (_fDegree, _fMinutes, _fSeconds) = OptimizeDegrees(_fDegree, value, _fSeconds);
            // FStroke = Convert.ToInt32((_fDegree * 3600 + _fMinutes * 60 + _fSeconds) * coef) * (_step / 1000); //TODO
        } }
    public int FSeconds { get => _fSeconds; set {
            (_fDegree, _fMinutes, _fSeconds) = OptimizeDegrees(_fDegree, _fMinutes, value);
            // FStroke = Convert.ToInt32((_fDegree * 3600 + _fMinutes * 60 + _fSeconds) * coef) * (_step / 1000); //TODO
        } }

    public int RevDegree
    {
        get => _rDegree; set
        {
            _rDegree = value % 360;
            // RevStroke = Convert.ToInt32((_rDegree * 3600 + _rMinutes * 60 + _rSeconds) * coef) * (_step / 1000); //TODO
        }
    }
    public int RevMinutes
    {
        get => _rMinutes; set
        {
            (_rDegree, _rMinutes, _rSeconds) = OptimizeDegrees(_rDegree, value, _rSeconds);
            // RevStroke = Convert.ToInt32((_rDegree * 3600 + _rMinutes * 60 + _rSeconds) * coef) * (_step / 1000); //TODO
        }
    }
    public int RevSeconds
    {
        get => _rSeconds; set
        {
            (_rDegree, _rMinutes, _rSeconds) = OptimizeDegrees(_rDegree, _rMinutes, value);
            // RevStroke = Convert.ToInt32((_rDegree * 3600 + _rMinutes * 60 + _rSeconds) * coef) * (_step / 1000); //TODO
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
        return Convert.ToInt32((_step / 1000) * (Math.Round(Math.Tan(degree) + Math.Tan(minutes / 60) + Math.Tan(seconds / 3600))));
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
}