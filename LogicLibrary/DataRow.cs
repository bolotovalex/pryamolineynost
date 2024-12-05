namespace LogicLibrary;

public class DataRow
{
    /// <summary>
    /// Класс для хранения точек измерения и расчета служебных параметров.
    /// </summary>
    private int _position { get; set; } //Длина измерения, мм

    private int _step { get; set; }
    private decimal _factProfile { get; set; } //Фактический профиль проверяемой поверхности, мкм
    private decimal _adjStraight { get; set; } //Прилегающая прямая, мкм
    private decimal _deviation { get; set; } //Отклонение, мкм
    private decimal _devationPerMeter { get; set; } //Отклонение на метре, мкм
    private decimal _midValue { get; set; } //Среднее значение, мкм
    private int _fStroke { get; set; } //Прямой ход, мкм
    private int _revStroke { get; set; } //Обратный ход, мкм
    private bool _revStrokeEnable { get; set; }
    private DataRow? _prevDataRow { get; set; }
    private decimal _progrmaFactor { get; set; }

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
        _fStroke = fStroke;
        _revStroke = revStroke;
        RevStrokeEnable = revStrokeEnabled;
        Step = step;
        PrevDataRow = prevDataRow;
        
    }
    public string[] GetAllCellsStringArray()
    {
        ///<summary>
        ///Получение списка строк для графика
        /// </summary>
        return [Position.ToString(),
                //Math.Round(FactProfile,2).ToString(),
                //Math.Round(AdjStraight,2).ToString(),
                Math.Round(Deviation,2).ToString(),
                //Math.Round(DevationPerMeter,2).ToString(),
                //Math.Round(MidValue,2).ToString(),
                _fStroke == int.MinValue ? "0": FStroke.ToString(),
                _revStroke == int.MinValue ? "0" : RevStroke.ToString()];
    }

}