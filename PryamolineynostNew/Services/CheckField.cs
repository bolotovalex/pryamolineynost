using System;
using Avalonia.Controls;

namespace PryamolineynostNew.Services;

public static class CheckField
{
    public static (bool, int) IsInt(TextBox textBox)
    {
        int result;
        return int.TryParse(textBox.Text, out result) ? (true, result) : (false, 0);
    }

    public static (bool, decimal) IsDecimal(TextBox textBox)
    {
        decimal result;
        return decimal.TryParse(textBox.Text, out result) ? (true, result) : (false, 0);
    }

    public static bool IsEmpty(TextBox textBox)
    {
        return string.IsNullOrEmpty(textBox.Text);
    }
}