using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PryamolineynostNew.Enums;

namespace PryamolineynostNew.Models.LevelTool;

public partial class LevelDataItem : ObservableObject
{
    /// <summary>
    /// Класс для хранения точек измерения и расчета служебных параметров.
    /// </summary>
    // private const decimal coef;
    [ObservableProperty] private int id;
    [ObservableProperty] private int position; //Длина измерения, мм
    [ObservableProperty] private int step; //Шаг
    [ObservableProperty] private decimal factProfile; //Фактический профиль проверяемой поверхности, мкм
    [ObservableProperty] private decimal adjStraight; //Прилегающая прямая, мкм
    [ObservableProperty] private decimal deviation; //Отклонение, мкм
    [ObservableProperty] private decimal devationPerMeter; //Отклонение на метре, мкм
    [ObservableProperty] private decimal midValue; //Среднее значение, мкм
    [ObservableProperty] private int fStroke; //Прямой ход, мкм
    [ObservableProperty] private int revStroke; //Обратный ход, мкм
    [ObservableProperty] private LevelDataItem? prevDataRow; //Предыдущая строка
    [ObservableProperty] private decimal progrmaFactor; //Коэффициент для расчета прилегающей прямой
    [ObservableProperty] private int fDegree; //Градусы прямой ход
    [ObservableProperty] private int fMinutes; //Минуты прямой ход
    [ObservableProperty] private int fSeconds; //Секунды прямой ход
    [ObservableProperty] private int rDegree; //Градусы обратный ход
    [ObservableProperty] private int rMinutes; //Минуты обратный ход
    [ObservableProperty] private int rSeconds; //Секунды обратный ход
    [ObservableProperty] private bool revStrokeEnable; //Включен-ли учет обратного хода

    partial void OnProgrmaFactorChanged(decimal value)
    {
        AdjStraight = value * Position;
        Deviation = FactProfile - AdjStraight;
    }


    partial void OnRevStrokeEnableChanged(bool value)
    {
        UpdateMidValue();
    }

    partial void OnFStrokeChanged(int value)
    {
        UpdateMidValue();
        var a = IntToSeconds(value);
        (FDegree, FMinutes, FSeconds) = OptimizeDegrees(0, 0, IntToSeconds(value));
    }

    partial void OnRevStrokeChanged(int value)
    {
        UpdateMidValue();
        (RDegree, RMinutes, RSeconds) = OptimizeDegrees(0, 0, IntToSeconds(value == int.MinValue ? 0 : value));
    }

    partial void OnPrevDataRowChanged(LevelDataItem? value)
    {
        FactProfile = PrevDataRow != null ? MidValue * Step / 1000 + PrevDataRow.FactProfile : MidValue * Step / 1000;

        if (PrevDataRow == null)
        {
            Id = 0;
        }
        else
        {
            Id = PrevDataRow.Id + 1;
        }
    }

    partial void OnPositionChanged(int value)
    {
        AdjStraight = ProgrmaFactor * Position;
    }

    partial void OnStepChanged(int value)
    {
        FactProfile = PrevDataRow != null ? MidValue * Step / 1000 + PrevDataRow.FactProfile : MidValue * Step / 1000;
    }

    partial void OnFactProfileChanged(decimal value)
    {
        Deviation = FactProfile - AdjStraight;
    }

    partial void OnAdjStraightChanged(decimal value)
    {
        Deviation = FactProfile - AdjStraight;
    }

    partial void OnMidValueChanged(decimal value)
    {
        FactProfile = PrevDataRow != null ? MidValue * Step / 1000 + PrevDataRow.FactProfile : MidValue * Step / 1000;
    }

    public LevelDataItem(int value, int step, LevelDataItem? prevDataRow, bool revStrokeEnabled, Directions directions)
    {
        Step = step;
        PrevDataRow = prevDataRow;
        RevStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? PrevDataRow.Position + Step : 0;
        FStroke = directions == Directions.Forward ? value : 0;
        RevStroke = directions == Directions.Reverse ? value : int.MinValue;
    }

    public LevelDataItem(int value, int step, LevelDataItem? prevDataRow,
        bool revStrokeEnabled, Directions directions, AngleUnits unit)
    {
        Step = step;
        PrevDataRow = prevDataRow;
        RevStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? PrevDataRow.Position + Step : 0;
        switch (unit)
        {
            case AngleUnits.Degree:
                FDegree = directions == Directions.Forward ? value : 0;
                RDegree = directions == Directions.Reverse ? value : 0;
                break;
            case AngleUnits.Minute:
                FMinutes = directions == Directions.Forward ?  value : 0;
                RMinutes = directions == Directions.Reverse ? value : 0;
                break;
            case AngleUnits.Second:
                FSeconds = directions == Directions.Forward ? value : 0;
                RSeconds = directions == Directions.Reverse ? value : 0;
                break;
        }
    }

    // пересчет свойств
    public void RecalcRow(int step, LevelDataItem? prevDataRow, bool revStrokeEnabled, Units unit)
    {
        Step = step;
        PrevDataRow = prevDataRow;
        RevStrokeEnable = revStrokeEnabled;
        Position = prevDataRow != null ? PrevDataRow.Position + Step : 0;
        if (unit == Units.Micrometer)
        {
            FStroke = FStroke;
            RevStroke = RevStroke;            
        }
        else if (unit == Units.Angle)
        {
            FDegree = FDegree;
            FMinutes = FMinutes;
            FSeconds = FSeconds;
            RDegree = RDegree;
            RMinutes = RMinutes;
            RSeconds = RSeconds;
        }
    }

    //получение сток для печати



    partial void OnFDegreeChanged(int value)
    {
        FDegree = value % 360;
        FStroke = DegreeToMicrometers(degree: value, minutes: FMinutes, seconds: FSeconds);
        UpdateMidValue();
    }


    partial void OnFMinutesChanged(int value)
    {
        (FDegree, FMinutes, FSeconds) = OptimizeDegrees(FDegree, value, FSeconds);
        FStroke = DegreeToMicrometers(degree: FDegree, minutes: value, seconds: FSeconds);
        UpdateMidValue();
    }
    
    partial void OnFSecondsChanged(int value) 
    {
        (FDegree, FMinutes, FSeconds) = OptimizeDegrees(FDegree, FMinutes, value);
        FStroke = DegreeToMicrometers(degree: FDegree, minutes: FMinutes, seconds: value);
        UpdateMidValue();
    }


    partial void OnRDegreeChanged(int value)
    {
        RDegree = value % 360;
        RevStroke = DegreeToMicrometers(degree: value, minutes: RMinutes, seconds: RSeconds);
        UpdateMidValue();
    }

    
    partial void OnRMinutesChanged(int value)
    {
        (RDegree, RMinutes, RSeconds) = OptimizeDegrees(RDegree, value, RSeconds);
        RevStroke = DegreeToMicrometers(degree: RDegree, minutes: value, seconds: RSeconds);
        UpdateMidValue();
    }
    
    partial void OnRSecondsChanged(int value)
    {
        (RDegree, RMinutes, RSeconds) = OptimizeDegrees(RDegree, RMinutes, value);
        RevStroke = DegreeToMicrometers(degree: RDegree, minutes: RMinutes, seconds: value);
        UpdateMidValue();
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
                FStroke == int.MinValue ? "0": FStroke.ToString(),
                RevStroke == int.MinValue ? "0" : RevStroke.ToString(),
                FDegree.ToString(),
                FMinutes.ToString(),
                FSeconds.ToString(),
                RDegree.ToString(),
                RMinutes.ToString(),
                RSeconds.ToString()];
    }
    public void UpdateMidValue()
    {
        MidValue = RevStroke != int.MinValue && RevStrokeEnable
                ? (RevStroke + FStroke) / 2
                : this.FStroke;
    }
}