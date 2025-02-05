namespace PryamolineynostWF.Services
{
    public static class ExitDialog
    {
        
        public static void ShowDialog(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                NavigationStack.Clear();
            }
        }
        
    }
}
