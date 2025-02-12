using System.ComponentModel;

namespace PryamolineynostWF.Views;

partial class CollimatorCalibrationDateForm
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
        tbActNumber = new TextBox();
        OkButton = new Button();
        dateTimePicker1 = new DateTimePicker();
        BackButton = new Button();
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
        DeviceText.Size = new Size(146, 15);
        DeviceText.TabIndex = 2;
        DeviceText.Text = "Выберите дату проверки:";
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
        collimatorModelText.Size = new Size(118, 15);
        collimatorModelText.TabIndex = 4;
        collimatorModelText.Text = "Введите номер акта:";
        // 
        // tbActNumber
        // 
        //tbActNumber.FormattingEnabled = true;
        tbActNumber.Location = new Point(164, 53);
        tbActNumber.Name = "tbActNumber";
        tbActNumber.Size = new Size(380, 23);
        tbActNumber.TabIndex = 6;
        tbActNumber.TextChanged += TbActNumber_TextChanged;
        // 
        // OkButton
        // 
        OkButton.Location = new Point(77, 93);
        OkButton.Name = "OkButton";
        OkButton.Size = new Size(128, 37);
        OkButton.TabIndex = 7;
        OkButton.Text = "ОК";
        OkButton.UseVisualStyleBackColor = true;
        OkButton.Click += BtnOk_Click;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new Point(165, 15);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new Size(377, 23);
        dateTimePicker1.TabIndex = 9;
        // 
        // BackButton
        // 
        BackButton.Location = new Point(343, 94);
        BackButton.Name = "BackButton";
        BackButton.Size = new Size(128, 37);
        BackButton.TabIndex = 10;
        BackButton.Text = "Назад";
        BackButton.UseVisualStyleBackColor = true;
        BackButton.Click += BtnPrev_Click;
        // 
        // CollimatorCalibrationDateForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(556, 139);
        Controls.Add(BackButton);
        Controls.Add(dateTimePicker1);
        Controls.Add(OkButton);
        Controls.Add(tbActNumber);
        Controls.Add(collimatorModelText);
        Controls.Add(ModelLabel);
        Controls.Add(DeviceText);
        Controls.Add(DeviceLabel);
        Name = "CollimatorCalibrationDateForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Дата и номер проверки инструмента";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label DeviceLabel;
    private Label DeviceText;
    private Label ModelLabel;
    private Label collimatorModelText;
    public TextBox tbActNumber;
    public Button OkButton;
    public DateTimePicker dateTimePicker1;
    private Button BackButton;
}