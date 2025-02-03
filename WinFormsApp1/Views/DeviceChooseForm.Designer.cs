using System.ComponentModel;

namespace PryamolineynostWF.Views;

partial class DeviceChooseForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        DeviceLabel = new Label();
        DeviceText = new Label();
        ModelLabel = new Label();
        collimatorModelText = new Label();
        deviceComboBox = new ComboBox();
        collimatorModelComboBox = new ComboBox();
        okButton = new Button();
        cancelButton = new Button();
        SuspendLayout();
        // 
        // DeviceLabel
        // 
        DeviceLabel.BorderStyle = BorderStyle.FixedSingle;
        DeviceLabel.Location = new Point(7, 9);
        DeviceLabel.Name = "DeviceLabel";
        DeviceLabel.Size = new Size(542, 35);
        DeviceLabel.TabIndex = 0;
        // 
        // DeviceText
        // 
        DeviceText.AutoSize = true;
        DeviceText.Location = new Point(13, 18);
        DeviceText.Name = "DeviceText";
        DeviceText.Size = new Size(195, 15);
        DeviceText.TabIndex = 2;
        DeviceText.Text = "Выберите инструмент измерения:";
        // 
        // ModelLabel
        // 
        ModelLabel.BorderStyle = BorderStyle.FixedSingle;
        ModelLabel.Location = new Point(7, 48);
        ModelLabel.Name = "ModelLabel";
        ModelLabel.Size = new Size(542, 35);
        ModelLabel.TabIndex = 3;
        // 
        // collimatorModelText
        // 
        collimatorModelText.AutoSize = true;
        collimatorModelText.Location = new Point(14, 57);
        collimatorModelText.Name = "collimatorModelText";
        collimatorModelText.Size = new Size(108, 15);
        collimatorModelText.TabIndex = 4;
        collimatorModelText.Text = "Выберите модель:";
        // 
        // deviceComboBox
        // 
        deviceComboBox.FormattingEnabled = true;
        deviceComboBox.Location = new Point(214, 15);
        deviceComboBox.Name = "deviceComboBox";
        deviceComboBox.Size = new Size(330, 23);
        deviceComboBox.TabIndex = 5;
        deviceComboBox.SelectedIndexChanged += deviceComboBox_SelectedIndexChanged;
        // 
        // collimatorModelComboBox
        // 
        collimatorModelComboBox.FormattingEnabled = true;
        collimatorModelComboBox.Location = new Point(214, 53);
        collimatorModelComboBox.Name = "collimatorModelComboBox";
        collimatorModelComboBox.Size = new Size(330, 23);
        collimatorModelComboBox.TabIndex = 6;
        collimatorModelComboBox.SelectedIndexChanged += collimatorModelComboBox_SelectedIndexChanged;
        // 
        // okButton
        // 
        okButton.Location = new Point(72, 93);
        okButton.Name = "okButton";
        okButton.Size = new Size(128, 37);
        okButton.TabIndex = 7;
        okButton.Text = "ОК";
        okButton.UseVisualStyleBackColor = true;
        okButton.Click += okButton_Click;
        // 
        // cancelButton
        // 
        cancelButton.Location = new Point(351, 93);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(128, 37);
        cancelButton.TabIndex = 8;
        cancelButton.Text = "Отмена";
        cancelButton.UseVisualStyleBackColor = true;
        //cancelButton.Click += cancelButton_Click;
        // 
        // DeviceChooseForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(556, 139);
        Controls.Add(cancelButton);
        Controls.Add(okButton);
        Controls.Add(collimatorModelComboBox);
        Controls.Add(deviceComboBox);
        Controls.Add(collimatorModelText);
        Controls.Add(ModelLabel);
        Controls.Add(DeviceText);
        Controls.Add(DeviceLabel);
        Name = "DeviceChooseForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Измерительный инструмент";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label DeviceLabel;
    private Label DeviceText;
    private Label ModelLabel;
    public Label collimatorModelText;
    public ComboBox deviceComboBox;
    public ComboBox collimatorModelComboBox;
    private Button okButton;
    private Button cancelButton;
}