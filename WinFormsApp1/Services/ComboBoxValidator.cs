using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Services
{
    public class ComboBoxValidator
    {
        public static bool CheckComboBoxIsFilled(ComboBox comboBox)
        {
            bool isValid = !string.IsNullOrWhiteSpace(comboBox.Text);
            comboBox.BackColor = isValid ? SystemColors.Window : Color.LightCoral;
            return isValid;
        }

        public static bool CheckComboBoxIsInt(ComboBox comboBox)
        {
            int result;
            bool isInt = int.TryParse(comboBox.Text, out result);
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
            {
                if (control is ComboBox comboBox)
                {
                    ValidateComboBox(comboBox);  // Первичная проверка
                    comboBox.TextChanged += (s, e) => ValidateComboBox((ComboBox)s);
                }
            }
        }

        private static void ValidateComboBox(ComboBox comboBox)
        {
            ComboBoxValidator.CheckComboBoxIsFilled(comboBox);
        }


        }
}
