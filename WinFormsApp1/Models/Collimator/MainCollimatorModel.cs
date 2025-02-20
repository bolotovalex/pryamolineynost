using System.ComponentModel;
using PryamolineynostWF.Enums;


namespace PryamolineynostWF.Models.Collimator;

public class MainCollimatorModel : INotifyPropertyChanged
{
    private DateTime autocollimatorCheckDate; //Дата проверки автоколлиматора
    private string autocollimatorCheckAct; //Дата проверки автоколлиматора
    private DateTime measurementDate; //Дата проведения измерений
    private CollimatorType collimatorType; //Тип автоколлиматора
    private string toolName; //Название оборудования на котором производится измерение
    private string description; //Описание оборудования
    private string workerName; //ФИО того, кто производит измерения
    
    //Горизонтальная плоскость
    private decimal hMaxDeviation; //Наибольшее отклонение в плоскости
    private decimal hMinDeviation; //Наименьшее отклонение в плоскости
    private decimal hDeviation; //Отклонение от прямолинейности
    private decimal hLineDeviation; //Максимальное отклонение на локальном участке
    private int hBedLength; //Длина измерения
    private int hLocalAreaSize; //Длина локального участка
    private int hTolerLocalAreaSize; //Допуск на локальном участке
    private int hTolerAllLength; //Допуск на всей длине
    private int hStepSize; //Шаг
    
    //Вертикальная плоскость
    private decimal vMaxDeviation; //Наибольшее отклонение в плоскости
    private decimal vMinDeviation; //Наименьшее отклонение в плоскости
    private decimal vDeviation;  //Отклонение от прямолинейности
    private decimal vLineDeviation;  //Максимальное отклонение на локальном участке
    private int vBedLength;  //Длина измерения
    private int vLocalAreaSize;  //Длина локального участка
    private int vTolerLocalAreaSize; //Допуск на локальном участке
    private int vTolerAllLength; //Допуск на всей длине
    private int vStepSize; //Шаг

    public DateTime AutocollimatorCheckDate
    {
        get => autocollimatorCheckDate;
        set => autocollimatorCheckDate = value;
    }

    public string AutocollimatorCheckAct
    {
        get => autocollimatorCheckAct;
        set => autocollimatorCheckAct = value;
    }

    public DateTime MeasurementDate
    {
        get => measurementDate;
        set => measurementDate = value;
    }

    public CollimatorType CollimatorType
    {
        get => collimatorType;
        set => collimatorType = value;
    }
    
    public string ToolName
    {
        get => toolName;
        set => toolName = value;
    }
    
    public string Description; 
    public string WorkerName;
    
    //Горизонтальная плоскость
    public decimal HMaxDeviation
    {
        get => hMaxDeviation;
        set => hMaxDeviation = value;
    }

    public decimal HMinDeviation
    {
        get => hMinDeviation;
        set => hMinDeviation = value;
    }

    public decimal HDeviation
    {
        get => hDeviation;
        set => hDeviation = value;
    }

    public decimal HLineDeviation
    {
        get => hLineDeviation;
        set => hLineDeviation = value;
    }

    public int HBedLength
    {
        get => hBedLength;
        set => hBedLength = value;
    }

    public int HLocalAreaSize
    {
        get => hLocalAreaSize;
        set => hLocalAreaSize = value;
    }

    public int HTolerLocalAreaSize
    {
        get => hTolerLocalAreaSize;
        set => hTolerLocalAreaSize = value;
    }

    public int HTolerAllLength
    {
        get => hTolerAllLength;
        set => hTolerAllLength = value;
    }

    public int HStepSize
    {
        get => hStepSize;
        set => hStepSize = value;
    }
    
    //Вертикальная плоскость
    public decimal VMaxDeviation
    {
        get => vMaxDeviation;
        set => vMaxDeviation = value;
    }

    public decimal VMinDeviation
    {
        get => vMinDeviation;
        set => vMinDeviation = value;
    }

    public decimal VDeviation
    {
        get => vDeviation;
        set => vDeviation = value;
    }

    public decimal VLineDeviation
    {
        get => vLineDeviation;
        set => vLineDeviation = value;
    }

    public int VBedLength
    {
        get => vBedLength;
        set => vBedLength = value;
    }

    public int VLocalAreaSize
    {
        get => vLocalAreaSize;
        set => vLocalAreaSize = value;
    }

    public int VTolerLocalAreaSize
    {
        get => vTolerLocalAreaSize;
        set => vTolerLocalAreaSize = value;
    }

    public int VTolerAllLength
    {
        get => vTolerAllLength;
        set => vTolerAllLength = value;
    }

    public int VStepSize
    {
        get => vStepSize;
        set => vStepSize = value;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}