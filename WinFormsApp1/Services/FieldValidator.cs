using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Services;

public class FieldValidator
{
    public static bool ComboBoxIsFilledCheck(ComboBox comboBox)
    {
        var isValid = !string.IsNullOrWhiteSpace(comboBox.Text);
        comboBox.BackColor = isValid ? SystemColors.Window : Color.LightCoral;
        return isValid;
    }

    public static bool TextBoxIsFilledCheck(TextBox textBox)
    {
        var isValid = !string.IsNullOrWhiteSpace(textBox.Text);
        textBox.BackColor = isValid ? SystemColors.Window : Color.LightCoral;
        return isValid;
    }

    public static bool CheckComboBoxIsInt(ComboBox comboBox)
    {
        int result;
        var isInt = int.TryParse(comboBox.Text, out result);
        if (isInt)
        {
            comboBox.BackColor = SystemColors.Window;
            comboBox.Text = result.ToString();
        }

        comboBox.BackColor = isInt ? SystemColors.Window : Color.LightCoral;
        comboBox.Text = "";
        return isInt;
    }

    public static void InitializeValidation(Form form)
    {
        foreach (Control control in form.Controls)
            if (control is ComboBox comboBox)
            {
                ValidateControl(comboBox); // Первичная проверка
                comboBox.TextChanged += (s, e) => ValidateControl((ComboBox)s);
            }
            else if (control is TextBox textBox)
            {
                ValidateControl(textBox); // Первичная проверка
                textBox.TextChanged += (s, e) => ValidateControl((TextBox)s);
            }
    }

    private static void ValidateControl(ComboBox comboBox)
    {
        ComboBoxIsFilledCheck(comboBox);
    }

    private static void ValidateControl(TextBox textBox)
    {
        TextBoxIsFilledCheck(textBox);
    }
}