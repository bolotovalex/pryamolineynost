using System.ComponentModel;
using System.Reflection;

namespace PryamolineynostWF.Services;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }

    public static void ConnectEnumToComboBox<TEnum>(ComboBox comboBox, TEnum? selValue = null, EventHandler? selValueChanged = null) where TEnum : struct, Enum
    {
        comboBox.DataSource = Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(e => new { Value = e, Name = e.GetDescription() })
            .ToList();

        comboBox.DisplayMember = "Name";
        comboBox.ValueMember = "Value";
        comboBox.SelectedValue = selValue;
        if (selValueChanged != null)
            comboBox.SelectedValueChanged += selValueChanged;
    }
}