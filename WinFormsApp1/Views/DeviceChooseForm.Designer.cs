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
        btnOk = new Button();
        btnCancel = new Button();
        btnLoad = new Button();
        SuspendLayout();
        // 
        // DeviceLabel
        // 
        DeviceLabel.BorderStyle = BorderStyle.FixedSingle;
        DeviceLabel.Location = new Point(8, 12);
        DeviceLabel.Name = "DeviceLabel";
        DeviceLabel.Size = new Size(619, 46);
        DeviceLabel.TabIndex = 0;
        // 
        // DeviceText
        // 
        DeviceText.AutoSize = true;
        DeviceText.Location = new Point(16, 23);
        DeviceText.Name = "DeviceText";
        DeviceText.Size = new Size(248, 20);
        DeviceText.TabIndex = 2;
        DeviceText.Text = "Выберите инструмент измерения:";
        // 
        // ModelLabel
        // 
        ModelLabel.BorderStyle = BorderStyle.FixedSingle;
        ModelLabel.Location = new Point(8, 64);
        ModelLabel.Name = "ModelLabel";
        ModelLabel.Size = new Size(619, 46);
        ModelLabel.TabIndex = 3;
        // 
        // collimatorModelText
        // 
        collimatorModelText.AutoSize = true;
        collimatorModelText.Location = new Point(16, 76);
        collimatorModelText.Name = "collimatorModelText";
        collimatorModelText.Size = new Size(137, 20);
        collimatorModelText.TabIndex = 4;
        collimatorModelText.Text = "Выберите модель:";
        // 
        // deviceComboBox
        // 
        deviceComboBox.FormattingEnabled = true;
        deviceComboBox.Location = new Point(270, 20);
        deviceComboBox.Margin = new Padding(3, 4, 3, 4);
        deviceComboBox.Name = "deviceComboBox";
        deviceComboBox.Size = new Size(352, 28);
        deviceComboBox.TabIndex = 5;
        deviceComboBox.SelectedIndexChanged += deviceComboBox_SelectedIndexChanged;
        // 
        // collimatorModelComboBox
        // 
        collimatorModelComboBox.FormattingEnabled = true;
        collimatorModelComboBox.Location = new Point(159, 71);
        collimatorModelComboBox.Margin = new Padding(3, 4, 3, 4);
        collimatorModelComboBox.Name = "collimatorModelComboBox";
        collimatorModelComboBox.Size = new Size(463, 28);
        collimatorModelComboBox.TabIndex = 6;
        collimatorModelComboBox.SelectedIndexChanged += collimatorModelComboBox_SelectedIndexChanged;
        // 
        // btnOk
        // 
        btnOk.Location = new Point(55, 124);
        btnOk.Margin = new Padding(3, 4, 3, 4);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(146, 49);
        btnOk.TabIndex = 7;
        btnOk.Text = "ОК";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(433, 124);
        btnCancel.Margin = new Padding(3, 4, 3, 4);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(146, 49);
        btnCancel.TabIndex = 8;
        btnCancel.Text = "Выход";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(245, 124);
        btnLoad.Margin = new Padding(3, 4, 3, 4);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(146, 49);
        btnLoad.TabIndex = 9;
        btnLoad.Text = "Загрузить";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // DeviceChooseForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(635, 185);
        Controls.Add(btnLoad);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(collimatorModelComboBox);
        Controls.Add(deviceComboBox);
        Controls.Add(collimatorModelText);
        Controls.Add(ModelLabel);
        Controls.Add(DeviceText);
        Controls.Add(DeviceLabel);
        Margin = new Padding(3, 4, 3, 4);
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
    private Button btnOk;
    private Button btnCancel;
    private Button btnLoad;
}