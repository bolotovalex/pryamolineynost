namespace PryamolineynostWF.Services
{
    public static class NavigationStack
    {
        private static Stack<Form> _formStack = new Stack<Form>();
        public static bool HasPreviousForm => _formStack.Count > 0;

        public static void Navigate(Form currentForm, Form nextForm)
        {
            _formStack.Push(currentForm);
            currentForm.Hide();
            nextForm.FormClosed += (sender, events) =>
            {
                if (_formStack.Count > 0)
                {
                    var previousForm = _formStack.Pop();
                    previousForm.Show();
                }
            };
            nextForm.Show();
        }

        public static void NavigateWithData(Form currentForm, Form nextForm, Action<Form> onReturn)
        {
            _formStack.Push(currentForm);
            currentForm.Hide();
            nextForm.FormClosed += (sender, events) =>
            {
                if (_formStack.Count > 0)
                {
                    var previousForm = _formStack.Pop();
                    onReturn(previousForm);
                    previousForm.Show();
                }
            };
            nextForm.Show();
        }

        public static void Clear()
        {
            _formStack.Clear();
            Application.Exit();
        }

    }
}
