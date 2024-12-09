using System.Drawing;
namespace LogicLibrary;

public class DB
{
    private string _backendVersion = "1.5.0.0";
    public DateTime Date { get; set; } //Дата
    public required string Name { get; set; } //Наименование
    public required string Description { get; set; } //Обозначение
    public required string Fio { get; set; } //Измерения произвел
    private decimal _minDeviation { get; set; } //Наибольшее отклонение, мкм
    private decimal _maxDeviation { get; set; } //Наименьшее отклонение, мкм
    private decimal _verticalDeflection { get; set; } //Отклонение от прямолинейности в вертикальной плоскости, мкм - 
    private decimal _meterDeflection { get; set; } //Отклонение от прямолинейности на 1 метр, мкм -
    private decimal _localAreaDeflection { get; set; }
    public int FullTolerance { get; set; } //Допуск на всю длину, мкм -
    public int MeterTolerance { get; set; } //Допуск на 1 метр, мкм -
    public int LocalAreaLength { get; set; } //Локальный участок, мм
    private int _bedAreaLength { get; set; } //Длина станины, мм
    public int Step { get; set; } //Шаг измерения (расстояние между опорами мостика), мм
    private decimal _programFactor1; //Программный коэффициент
    private decimal _programFactor2; //Программный коэффициент
    public List<DataRow> DataList { get; set; } //Таблица измерений
    private int _stepsPerMeter { get; set; }
    private bool _revStrokeEnbled = false;
    private DPoint[] CurvePoints { get; set; }
    private DPoint[] StraightPoints { get; set; }

    private AreaDeviation[]? maxLocalAreaDeviations { get; set; }
    public Units currUnit = Units.Micrometer;

    public bool RevStrokeEnable
    {
        get => _revStrokeEnbled;
        set
        {
            _revStrokeEnbled = value;
            _revStrokeEnbled = value;
            foreach (var row in DataList)
                row.RevStrokeEnable = _revStrokeEnbled;
        }
    }

 
    public DPoint[] GetCurvePoints() => CurvePoints;
    public DPoint[] GetStraightPoint() => StraightPoints;
    public AreaDeviation[] GetAreaDeviations() => maxLocalAreaDeviations ?? new AreaDeviation[0];
    public void SetAreaDeviation(AreaDeviation[] area)
    {
        maxLocalAreaDeviations = area;
    }

    public string GetVersion() => _backendVersion;

    public DB()
    {
        _maxDeviation = 0;
        DataList = [];
        Date = DateTime.Now.Date;
        Step = 200;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow(0,0,null, RevStrokeEnable, Direction.Forward));
        LocalAreaLength = 1000;
    }

    public void SetVerticalDeflection(decimal deflection)
    {
        _verticalDeflection = deflection;
    }

    public decimal GetVerticalDeflection() => _verticalDeflection;
    public decimal GetMinDeviation() => _minDeviation;
    public  decimal GetMaxDeviation() => _maxDeviation;
    public decimal GetMeterDeflection() => _meterDeflection;
    public int GetBedAreaLength() => _bedAreaLength;
    

    public void UpdateStepsPerMeter(int stepsLength)
    {
        if (stepsLength != 0)
        {
            _stepsPerMeter = 1000 % stepsLength >= 5 ? 1000 / stepsLength + 1 : 1000 / stepsLength;
            foreach (var row in DataList)
                row.Step = _stepsPerMeter;
        }
    }

    private void UpdateProgramFactors()
    {
        if (DataList[^1].Position != 0)
        {
            _programFactor1 = DataList[^1].FactProfile /
                              DataList[^1].Position;
            foreach (var row in DataList)
                row.ProgrmaFactor = _programFactor1;
        }
    }

    public void AddRow(int value, Direction direction, Units unit, AngleUnits angleUnits = AngleUnits.Second)
    {
        var prevRow = DataList[^1];
        DataRow row = null;
        switch (unit)
        {
            case Units.Micrometer:
                row = new DataRow(value, Step, prevRow, _revStrokeEnbled, direction);
                break;
            case Units.Angle:
                switch (angleUnits)
                {
                    case AngleUnits.Degree:
                        row = new DataRow(value, Step, prevRow, _revStrokeEnbled, direction, AngleUnits.Degree);
                        break;
                    case AngleUnits.Minute:
                        row = new DataRow(value, Step, prevRow, _revStrokeEnbled, direction, AngleUnits.Minute);
                        break;
                    case AngleUnits.Second:
                        row = new DataRow(value, Step, prevRow, _revStrokeEnbled, direction, AngleUnits.Second);
                        break;
                }
                // row = new DataRow(value, Step, prevRow, _revStrokeEnbled, direction, angleUnits);
                break;
        }
        
        
        DataList.Add(row);
        UpdateProgramFactors();
        UpdateAllRows(currUnit);
    }

    private decimal GetMaxDeviationPerMeterForStep(int maxIndex)
    {
        //Нужно для расчета при шаге более 500мм
        var delimeter = _stepsPerMeter >= 2 ? _stepsPerMeter : 2; 

        var startIndex = maxIndex - delimeter + 1;
        var lengthOnMeter = new List<decimal>() { };
        
        for (var length = 0; length <= 1000; length += 1000 / delimeter)
            lengthOnMeter.Add(length);

        var factProfileList = new List<decimal>() { 0 };

        for (var i = startIndex; i < DataList.Count && i <= maxIndex; i++)
        {
            var factProfile = DataList[i].MidValue * Step / 1000 + factProfileList[i - startIndex];
            factProfileList.Add(factProfile);
        }

        var coefficient = factProfileList[^1] / lengthOnMeter[^1];
        var listDeviations = new List<decimal>() { 0 };
        decimal maxDeviation = 0;
        decimal minDeviation = 0;

        for (var i = startIndex; i < DataList.Count && i <= maxIndex; i++)
        {
            var prilPryamaya =
                coefficient * lengthOnMeter[i - startIndex + 1] +
                0; //TODO в документе указано ссылка на T15, но она пустая всегда.

            var deviation = factProfileList[i - startIndex + 1] - prilPryamaya;
            listDeviations.Add(deviation);
            if (maxDeviation < deviation)
                maxDeviation = deviation;
            else if (minDeviation > deviation)
                minDeviation = deviation;
        }

        return maxDeviation - minDeviation;
    }

    public void UpdateMeterDeflection()
    {
        decimal maxDeflection = 0;
        decimal minDeflection = 0;
        for (var i = 1; i <= DataList.Count - _stepsPerMeter; i++)
        {
            var rowDeviationPerMeter = DataList[i].DeviationPerMeter;
            if (rowDeviationPerMeter > maxDeflection)
                maxDeflection = rowDeviationPerMeter;
            else if (rowDeviationPerMeter < minDeflection)
                minDeflection = rowDeviationPerMeter;
        }

        _meterDeflection = Math.Max(maxDeflection, -1 * minDeflection);
    }

    public void UpdateAllAdjStrokeDataList()
    {
        UpdateProgramFactors();
        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            selRow.ProgrmaFactor = _programFactor1;
        }
    }

    public void UpdateAllStroksDataList(Units unit)
    {
        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            var prevRow = DataList[i - 1];

            selRow.RecalcRow(Step, prevRow, _revStrokeEnbled, unit);
        }
    }

    //public void UpdateAllDeviationsDataList()
    //{
    //    for (var i = 1; i < DataList.Count; i++)
    //    {
    //        var selRow = DataList[i];
    //        selRow.CalculateDeviation();
    //    }
    //}

    public void UpdateMinMaxDeviations()
    {
        _maxDeviation = 0;
        _minDeviation = 0;

        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            var deviationValue = selRow.Deviation;
            if (deviationValue > _maxDeviation)
                _maxDeviation = deviationValue;
            else if (deviationValue < _minDeviation)
                _minDeviation = deviationValue;
        }
        _verticalDeflection = _maxDeviation + _minDeviation * -1;
    }

    public void UpdateMeterDeflectionAllDataList()
    {
        for (var i = 1; i < DataList.Count; i++)
        {
            var index = i - _stepsPerMeter + 1;
            if (DataList.Count - i >= 1 && DataList.Count > _stepsPerMeter && index >= 1)
            {
                DataList[index].DeviationPerMeter = GetMaxDeviationPerMeterForStep(i);
            }
            if (DataList.Count - i < _stepsPerMeter)
            {
                DataList[i].DeviationPerMeter = 0;
            }
        }
    }
    
    public decimal GetY(int x1, decimal y1, int x2, decimal y2, int x3)
    {
        return Math.Round((x3 * y2 - x3 * y1 - x1 * y2 + x2 * y1) / (x2 - x1), 2);
    }

    private decimal GetYBetweenStepIndex(int index, int coord)
    {
        
        return GetY(x1: DataList[index - 1].Position,
                    y1: DataList[index - 1].FactProfile,
                    x2: DataList[index].Position,
                    y2: DataList[index].FactProfile,
                    x3: coord);
    }

    public AreaDeviation GetAreaDeviation(int startPos)
    {
        int startX = startPos;
        decimal startY;
        int endX = startX + LocalAreaLength;
        decimal endY;

        var interval = GetIntervalIndex(startX, endX);
        var adjStraightStepList = new List<(int x, decimal y)>();

        startY = DataList[interval.startIndex].Position > startX 
            ? GetYBetweenStepIndex(interval.startIndex, startX) 
            : DataList[interval.startIndex++].FactProfile;
        endY = DataList[interval.endIndex].Position > endX
            ? GetYBetweenStepIndex(interval.endIndex, endX)
            : DataList[interval.endIndex].FactProfile;

        adjStraightStepList.Add((startX, startY));

        for (var i = interval.startIndex; i < interval.endIndex; i++)
        {
            var x = DataList[i].Position;
            var y = GetY(startX, startY, endX, endY, DataList[i].Position);
            adjStraightStepList.Add((x, y));
        }
        adjStraightStepList.Add((endX, endY));

        var delta = GetDeltaAreaDeviation(interval.startIndex, interval.endIndex, adjStraightStepList);

        return new AreaDeviation(delta.startX, startY, delta.endX, endY, delta.delta);
    }


    public (int startX, int endX, decimal delta) GetDeltaAreaDeviation(int startInteval, int endInterval, List<(int x, decimal y)> LocalAreaStraight)
    {
        var lst = new List<decimal>();
        decimal minDeviation = 0;
        decimal maxDeviation = 0;

        for (var i = 1; i < endInterval - startInteval + 1; i++)
        {
            var value = DataList[startInteval + i - 1].FactProfile - LocalAreaStraight[i].y;
            if (value < minDeviation)
                minDeviation = value;
            else if (value > maxDeviation)
                maxDeviation = value;
        }
            
        return (LocalAreaStraight[0].x, LocalAreaStraight[^1].x, maxDeviation - minDeviation);
    }

    public AreaDeviation[]? GetMaxLocalAreaDeviation(int count = 10, decimal tolerance = 0)
    {
        var deviationList = new SortedQueueDeviation();
        int localStep;
        int i;

        if (Step == LocalAreaLength)
        {
            localStep = Step;
            i = 1;
        }
        else if (LocalAreaLength > Step) 
        {
            localStep = Step / 2;
            i = 0;
        }
        else
        {
            return null;
        }

        for (; i + LocalAreaLength <= _bedAreaLength; i += localStep)
        {
            var areaDeviation = GetAreaDeviation(i);
            deviationList.AddArea(areaDeviation);
        }
        
        _localAreaDeflection = deviationList.GetMaxDeviationValue();

        return deviationList.GetItemsArr();
    }

    public (int startIndex, int endIndex) GetIntervalIndex(int startPos, int endPos)
    {
        var startIndexIsFind = false;
        var endIndexIsFind = false;
        var startIndex = 0;
        var endIndex = DataList.Count - 1;
        for (var i = 0; i < DataList.Count; i++)
        {
            if (!startIndexIsFind && DataList[i].Position >= startPos)
            {
                startIndex = i;
                startIndexIsFind = true;
                continue;
            }

            if (!endIndexIsFind &&  DataList[i].Position >= endPos)
            {
                endIndex = i;
                endIndexIsFind = true;
            }
            if (startIndexIsFind && endIndexIsFind) break;
        }

        return (startIndex, endIndex);
    }

    public void UpdateAllRows(Units unit)
    {
        //TODO Не оптимально. Множественные проходы. Нужно оптимизировать, но набор данных не большой. Пока сделано, чтобы считалось так-же как в excel
        UpdateAllStroksDataList(unit);
        UpdateAllAdjStrokeDataList();
        UpdateMinMaxDeviations();
        UpdateMeterDeflectionAllDataList();
        UpdateMeterDeflection();
        _bedAreaLength = DataList[^1].Position;
        maxLocalAreaDeviations = GetMaxLocalAreaDeviation(30);
        UpdatePoints(); 
    }

    public void UpdateRow(int index, int value, Direction direction, Units unit, AngleUnits angleUnits = AngleUnits.Second) //int index, int value)
    {
        if (index > 0)
            switch (unit)
            {
                case Units.Micrometer:
                    if (direction == Direction.Forward)
                        DataList[index].FStroke = value;
                    
                    else if (direction == Direction.Reverse)
                        DataList[index].RevStroke = value;
                    
                    break;
                
                case Units.Angle:
                    switch (angleUnits)
                    {
                        case AngleUnits.Degree:
                            if (direction == Direction.Forward)
                                DataList[index].FDegree = value;
                            else if (direction == Direction.Reverse)
                                DataList[index].RevDegree = value;
                            break;
                        case AngleUnits.Minute:
                            if (direction == Direction.Forward)
                                DataList[index].FMinutes = value;
                            else if (direction == Direction.Reverse)
                                DataList[index].RevMinutes = value;
                            break;
                        case AngleUnits.Second:
                            if (direction == Direction.Forward)
                                DataList[index].FSeconds = value;
                            else if (direction == Direction.Reverse)
                                DataList[index].RevSeconds = value;
                            break;
                    }
                    break;
            }
        UpdateAllRows(currUnit);
    }

    public void CleanDb()
    {
        Date = DateTime.Now.Date;
        DataList.Clear(); //= new List<DataRow>();
        _programFactor1 = 0;
        _programFactor2 = 0;
        _verticalDeflection = 0;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow(0, 0, null, _revStrokeEnbled, Direction.Forward));
        UpdateAllRows(currUnit);
    }

    //public (string Name, object Value)[] GetDBFields()
    //{
    //    return [
    //        ( "Дата", Date.Date),
    //        ( "Наименование", Name ),
    //        ( "Обозначение", Description ),
    //        ( "Измерения произвел", Fio ),
    //        ( "Наибольшее отклонение", _maxDeviation ),
    //        ( "Наименьшее отклонение", _minDeviation ),
    //        ( "Отклонение от прямолинейности в вертикальной плоскости, мкм",_verticalDeflection ),
    //        ( "Отклонение от прямолинейности на 1 метр, мкм",  _meterDeflection ),
    //        ( "Допуск на всю длину измерения, мкм",  FullTolerance ),
    //        ( "Допуск на 1 метр (или локальный), мкм",  MeterTolerance ),
    //        ( "Локальный участок, мм",  LocalAreaLength ),
    //        ( "Длина измерения, мм",  _bedAreaLength ),
    //        ( "Шаг измерения (расстояние между опорами мостика), мм", Step)
    //    ];
    //}

    public (string[][] dbValues, string[][] dataListValues) GetPrintLists()
    {
        string[][] dbValues = [
            [ "Дата", Date.ToString().Split(" ")[0]],
            [ "Наименование", Name ],
            [ "Обозначение", Description ],
            [ "Измерения произвел",Fio ],
            [ "Наибольшее отклонение", Math.Round(_maxDeviation,2).ToString() ],
            [ "Наименьшее отклонение", Math.Round(_minDeviation, 2).ToString() ],
            [ "Отклонение от прямолинейности в вертикальной плоскости, мкм", Math.Round(_verticalDeflection, 2).ToString() ],
            [ "Допуск на всю длину измерения, мкм", FullTolerance.ToString() ],
            [ "Локальный участок, мм", LocalAreaLength.ToString() ],
            [ "Отклонение на локальном участке, мкм",  Math.Round(_localAreaDeflection, 2).ToString() ],
            [ "Допуск на локальном участке, мкм", MeterTolerance.ToString() ],
            [ "Длина измерения, мм", _bedAreaLength.ToString() ],
            [ "Шаг измерения (расстояние между опорами мостика), мм", Step.ToString() ]];

        var dataListValues = new string[DataList.Count + 1][];

        dataListValues[0] = [
            "No",
            "Длина измерения, мм",
            "Отклонение, мкм",
            "Прямой ход, мкм"];


        if (!_revStrokeEnbled)
        {
            dataListValues[0] = [
           "No",
            "Длина измерения, мм",
            "Отклонение, мкм",
            "Прямой ход, мкм"];
        }
        else
        {
            dataListValues[0] = [
           "No",
            "Длина измерения, мм",
            "Отклонение, мкм",
            "Прямой ход, мкм",
            "Обратный ход, мкм"];
        }

        for (var i = 0; i < DataList.Count; i++)
        {
            var list1 = new string[] { $"{i}" };
            if (_revStrokeEnbled)
            {
                dataListValues[i + 1] = list1.Concat(DataList[i].GetAllCellsStringArray()).ToArray();
            }
            else
            {
                dataListValues[i + 1] = list1.Concat(DataList[i].GetAllCellsStringArray()).ToArray()[..^1];
            }
            
        }
        return (dbValues, dataListValues);

    }

    public (double[] positions, double[] graph1, double[] graph2) GetGraphicPoints()
    {
        var pos = new double[DataList.Count];
        var graph1 = new double[DataList.Count];
        var graph2 = new double[DataList.Count];
        for (int i = 0; i < DataList.Count; i++)
        {
            pos[i] = decimal.ToDouble(DataList[i].Position);
            graph1[i] = decimal.ToDouble(DataList[i].FactProfile);
            graph2[i] = decimal.ToDouble(DataList[i].AdjStraight);
        }

        return new(pos, graph1, graph2);
    }
    public void UpdatePoints()
    {
        CurvePoints = new DPoint[DataList.Count];
        StraightPoints = new DPoint[DataList.Count];
        for (var i = 0; i < DataList.Count; ++i)
        {
            CurvePoints[i] = new DPoint(DataList[i].Position, DataList[i].FactProfile);
            StraightPoints[i] = new DPoint(DataList[i].Position, DataList[i].AdjStraight);
        }
    }

    public decimal GetAreaDeflection() => _localAreaDeflection;

    public string GetUnitDescription(Units unit)
    {
        switch (unit)
        {
            case Units.Micrometer:
                return "мкм";
            case Units.Angle:
                return "Градусы,Минуты,Секунды";
            default:
                throw new Exception("Не известный тип измерения.");
        }
    }

    public int GetUnitOrder(Units unit)
    {
        switch (unit)
        {
            case Units.Micrometer:
                return 0;
            case Units.Angle:
                return 1;
            default:
                throw new Exception("Не известный тип измерения.");
        }
    }

    public Units GetUnitFromIndex(int index)
    {
        switch (index)
        {
            case 0:
                return Units.Micrometer;
            case 1:
                return Units.Angle;
            default:
                throw new Exception("Не известный тип измерения.");
        }
    }
}