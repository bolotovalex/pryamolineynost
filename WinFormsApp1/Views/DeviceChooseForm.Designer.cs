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
        // btnOk
        // 
        btnOk.Location = new Point(48, 93);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(128, 37);
        btnOk.TabIndex = 7;
        btnOk.Text = "ОК";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(379, 93);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(128, 37);
        btnCancel.TabIndex = 8;
        btnCancel.Text = "Отмена";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(214, 93);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(128, 37);
        btnLoad.TabIndex = 9;
        btnLoad.Text = "Загрузить";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // DeviceChooseForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(556, 139);
        Controls.Add(btnLoad);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
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
    private Button btnOk;
    private Button btnCancel;
    private Button btnLoad;
}