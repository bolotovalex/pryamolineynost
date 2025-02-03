using Avalonia.Controls;
using Avalonia.Media;

namespace PryamolineynostNew.Services;

public class ObjectColor
{
    public static IImmutableSolidColorBrush WrongColor = Brushes.Red;
    public static IImmutableSolidColorBrush RightColor = Brushes.White;
    
    public void TextBoxChangeColor(TextBox textBox, bool isValid)
    {
        textBox.Foreground = isValid ? RightColor : WrongColor;
    }


}