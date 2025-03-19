namespace PryamolineynostWF.Interfaces;

public interface IUnit
{
    int Value { get; }
    IUnit? LinkedUnit { get; set; }
    void SetValue(int value);
    void UpdateValue(int value);
    void UpdateFieldValue(string field, int value);
}