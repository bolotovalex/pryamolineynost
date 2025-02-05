namespace PryamolineynostWF.Views
{
    partial class StubDialog
    {
        private Label messageLabel;
        private Button okButton;

        private void InitializeComponent()
        {
            this.messageLabel = new Label();
            this.okButton = new Button();
            this.SuspendLayout();

            // messageLabel
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new Point(20, 20);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new Size(200, 15);
            this.messageLabel.Text = "Заглушка. Пока не реализовано.";

            // okButton
            this.okButton.Location = new Point(80, 60);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(100, 30);
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new EventHandler(this.okButton_Click);

            // StubDialog
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(260, 120);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Заглушка";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
