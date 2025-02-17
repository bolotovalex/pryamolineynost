using System.ComponentModel;

namespace PryamolineynostWF.Views.Collimator;

partial class CollimatorMainForm
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
        datePanel = new Panel();
        dateLabel = new Label();
        dateTimePicker = new DateTimePicker();
        namePanel = new Panel();
        nameLabel = new Label();
        nameComboBox = new ComboBox();
        descriptionPanel = new Panel();
        descriptionComboBox = new ComboBox();
        descriptionLabel = new Label();
        fioPanel = new Panel();
        fioComboBox = new ComboBox();
        fioLabel = new Label();
        maxDeviationPanel = new Panel();
        textBox1 = new TextBox();
        maxDeviationTextBox = new TextBox();
        maxDeviationLabel = new Label();
        minDeviationPanel = new Panel();
        minDeviationTextBox = new TextBox();
        minDeviationLabel = new Label();
        verticalDeviationPanel = new Panel();
        verticalDeviationTextBox = new TextBox();
        verticalDeviationLabel = new Label();
        lineDeviationPanel = new Panel();
        lineDeviationTextBox = new TextBox();
        lineDeviationLabel = new Label();
        bedPanelLength = new Panel();
        bedLengthTextBox = new TextBox();
        bedLengthLabel = new Label();
        localAreaPanel = new Panel();
        localAreaTextBox = new TextBox();
        textBox9 = new TextBox();
        localAreaLabel = new Label();
        tolerPerMeterPanel = new Panel();
        tolerPerMeterTextBox = new TextBox();
        tolerPerMeterLabel = new Label();
        textBox5 = new TextBox();
        tolerLenghtPanel = new Panel();
        tolerLenghtTextBox = new TextBox();
        tolerLengthLabel = new Label();
        stepPanel = new Panel();
        stepTextBox = new TextBox();
        stepLabel = new Label();
        fillDataFormButton = new Button();
        graphicButton = new Button();
        saveButton = new Button();
        loadFileButton = new Button();
        savePdfButton = new Button();
        exitButton = new Button();
        textBox2 = new TextBox();
        textBox3 = new TextBox();
        textBox4 = new TextBox();
        textBox6 = new TextBox();
        panel1 = new Panel();
        label4 = new Label();
        panel3 = new Panel();
        label1 = new Label();
        panel2 = new Panel();
        label2 = new Label();
        panel4 = new Panel();
        button1 = new Button();
        labelCollimatorType = new Label();
        label3 = new Label();
        textBox7 = new TextBox();
        textBox8 = new TextBox();
        datePanel.SuspendLayout();
        namePanel.SuspendLayout();
        descriptionPanel.SuspendLayout();
        fioPanel.SuspendLayout();
        maxDeviationPanel.SuspendLayout();
        minDeviationPanel.SuspendLayout();
        verticalDeviationPanel.SuspendLayout();
        lineDeviationPanel.SuspendLayout();
        bedPanelLength.SuspendLayout();
        localAreaPanel.SuspendLayout();
        tolerPerMeterPanel.SuspendLayout();
        tolerLenghtPanel.SuspendLayout();
        stepPanel.SuspendLayout();
        panel1.SuspendLayout();
        panel3.SuspendLayout();
        panel2.SuspendLayout();
        panel4.SuspendLayout();
        SuspendLayout();
        // 
        // datePanel
        // 
        datePanel.BorderStyle = BorderStyle.FixedSingle;
        datePanel.Controls.Add(dateLabel);
        datePanel.Controls.Add(dateTimePicker);
        datePanel.Location = new Point(375, 12);
        datePanel.Name = "datePanel";
        datePanel.Size = new Size(312, 31);
        datePanel.TabIndex = 0;
        // 
        // dateLabel
        // 
        dateLabel.AutoSize = true;
        dateLabel.Location = new Point(10, 7);
        dateLabel.Name = "dateLabel";
        dateLabel.Size = new Size(32, 15);
        dateLabel.TabIndex = 3;
        dateLabel.Text = "Дата";
        // 
        // dateTimePicker
        // 
        dateTimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        dateTimePicker.CustomFormat = "dd MMMM yyyy";
        dateTimePicker.Location = new Point(161, 3);
        dateTimePicker.MinDate = new DateTime(2024, 9, 1, 0, 0, 0, 0);
        dateTimePicker.Name = "dateTimePicker";
        dateTimePicker.RightToLeft = RightToLeft.No;
        dateTimePicker.Size = new Size(146, 23);
        dateTimePicker.TabIndex = 1;
        // 
        // namePanel
        // 
        namePanel.BorderStyle = BorderStyle.FixedSingle;
        namePanel.Controls.Add(nameLabel);
        namePanel.Controls.Add(nameComboBox);
        namePanel.Location = new Point(8, 49);
        namePanel.Name = "namePanel";
        namePanel.Size = new Size(679, 31);
        namePanel.TabIndex = 2;
        // 
        // nameLabel
        // 
        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(10, 7);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new Size(255, 15);
        nameLabel.TabIndex = 3;
        nameLabel.Text = "Наименование проверяемого оборудования";
        // 
        // nameComboBox
        // 
        nameComboBox.FlatStyle = FlatStyle.System;
        nameComboBox.FormattingEnabled = true;
        nameComboBox.Location = new Point(271, 3);
        nameComboBox.Name = "nameComboBox";
        nameComboBox.RightToLeft = RightToLeft.Yes;
        nameComboBox.Size = new Size(400, 23);
        nameComboBox.TabIndex = 4;
        // 
        // descriptionPanel
        // 
        descriptionPanel.BorderStyle = BorderStyle.FixedSingle;
        descriptionPanel.Controls.Add(descriptionComboBox);
        descriptionPanel.Controls.Add(descriptionLabel);
        descriptionPanel.Location = new Point(8, 86);
        descriptionPanel.Name = "descriptionPanel";
        descriptionPanel.Size = new Size(679, 31);
        descriptionPanel.TabIndex = 5;
        // 
        // descriptionComboBox
        // 
        descriptionComboBox.FlatStyle = FlatStyle.System;
        descriptionComboBox.FormattingEnabled = true;
        descriptionComboBox.Location = new Point(169, 3);
        descriptionComboBox.Name = "descriptionComboBox";
        descriptionComboBox.RightToLeft = RightToLeft.Yes;
        descriptionComboBox.Size = new Size(502, 23);
        descriptionComboBox.TabIndex = 7;
        // 
        // descriptionLabel
        // 
        descriptionLabel.AutoSize = true;
        descriptionLabel.Location = new Point(8, 7);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new Size(155, 15);
        descriptionLabel.TabIndex = 6;
        descriptionLabel.Text = "Обозначение поверхности";
        // 
        // fioPanel
        // 
        fioPanel.BorderStyle = BorderStyle.FixedSingle;
        fioPanel.Controls.Add(fioComboBox);
        fioPanel.Controls.Add(fioLabel);
        fioPanel.Location = new Point(8, 123);
        fioPanel.Name = "fioPanel";
        fioPanel.Size = new Size(679, 31);
        fioPanel.TabIndex = 8;
        // 
        // fioComboBox
        // 
        fioComboBox.FormattingEnabled = true;
        fioComboBox.Location = new Point(140, 3);
        fioComboBox.Name = "fioComboBox";
        fioComboBox.RightToLeft = RightToLeft.Yes;
        fioComboBox.Size = new Size(531, 23);
        fioComboBox.TabIndex = 10;
        // 
        // fioLabel
        // 
        fioLabel.AutoSize = true;
        fioLabel.Location = new Point(10, 7);
        fioLabel.Name = "fioLabel";
        fioLabel.Size = new Size(124, 15);
        fioLabel.TabIndex = 9;
        fioLabel.Text = "Измерение произвел";
        // 
        // maxDeviationPanel
        // 
        maxDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
        maxDeviationPanel.Controls.Add(textBox1);
        maxDeviationPanel.Controls.Add(maxDeviationTextBox);
        maxDeviationPanel.Controls.Add(maxDeviationLabel);
        maxDeviationPanel.Location = new Point(8, 196);
        maxDeviationPanel.Name = "maxDeviationPanel";
        maxDeviationPanel.Size = new Size(679, 31);
        maxDeviationPanel.TabIndex = 11;
        // 
        // textBox1
        // 
        textBox1.BackColor = SystemColors.Control;
        textBox1.BorderStyle = BorderStyle.FixedSingle;
        textBox1.Location = new Point(541, 3);
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new Size(132, 23);
        textBox1.TabIndex = 14;
        textBox1.TabStop = false;
        textBox1.Text = "0";
        textBox1.TextAlign = HorizontalAlignment.Right;
        // 
        // maxDeviationTextBox
        // 
        maxDeviationTextBox.BackColor = SystemColors.Control;
        maxDeviationTextBox.BorderStyle = BorderStyle.FixedSingle;
        maxDeviationTextBox.Location = new Point(404, 3);
        maxDeviationTextBox.Name = "maxDeviationTextBox";
        maxDeviationTextBox.ReadOnly = true;
        maxDeviationTextBox.Size = new Size(132, 23);
        maxDeviationTextBox.TabIndex = 13;
        maxDeviationTextBox.TabStop = false;
        maxDeviationTextBox.Text = "0";
        maxDeviationTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // maxDeviationLabel
        // 
        maxDeviationLabel.AutoSize = true;
        maxDeviationLabel.Location = new Point(10, 7);
        maxDeviationLabel.Name = "maxDeviationLabel";
        maxDeviationLabel.Size = new Size(177, 15);
        maxDeviationLabel.TabIndex = 12;
        maxDeviationLabel.Text = "Наибольшее отклонение, мкм";
        // 
        // minDeviationPanel
        // 
        minDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
        minDeviationPanel.Controls.Add(minDeviationTextBox);
        minDeviationPanel.Controls.Add(minDeviationLabel);
        minDeviationPanel.Location = new Point(8, 233);
        minDeviationPanel.Name = "minDeviationPanel";
        minDeviationPanel.Size = new Size(679, 31);
        minDeviationPanel.TabIndex = 14;
        // 
        // minDeviationTextBox
        // 
        minDeviationTextBox.BackColor = SystemColors.Control;
        minDeviationTextBox.BorderStyle = BorderStyle.FixedSingle;
        minDeviationTextBox.Location = new Point(404, 3);
        minDeviationTextBox.Name = "minDeviationTextBox";
        minDeviationTextBox.ReadOnly = true;
        minDeviationTextBox.Size = new Size(132, 23);
        minDeviationTextBox.TabIndex = 16;
        minDeviationTextBox.TabStop = false;
        minDeviationTextBox.Text = "0";
        minDeviationTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // minDeviationLabel
        // 
        minDeviationLabel.AutoSize = true;
        minDeviationLabel.Location = new Point(10, 7);
        minDeviationLabel.Name = "minDeviationLabel";
        minDeviationLabel.Size = new Size(178, 15);
        minDeviationLabel.TabIndex = 15;
        minDeviationLabel.Text = "Наименьшее отклонение, мкм";
        // 
        // verticalDeviationPanel
        // 
        verticalDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
        verticalDeviationPanel.Controls.Add(verticalDeviationTextBox);
        verticalDeviationPanel.Controls.Add(verticalDeviationLabel);
        verticalDeviationPanel.Location = new Point(8, 270);
        verticalDeviationPanel.Name = "verticalDeviationPanel";
        verticalDeviationPanel.Size = new Size(679, 31);
        verticalDeviationPanel.TabIndex = 17;
        // 
        // verticalDeviationTextBox
        // 
        verticalDeviationTextBox.BackColor = SystemColors.Control;
        verticalDeviationTextBox.BorderStyle = BorderStyle.FixedSingle;
        verticalDeviationTextBox.Location = new Point(403, 3);
        verticalDeviationTextBox.Name = "verticalDeviationTextBox";
        verticalDeviationTextBox.ReadOnly = true;
        verticalDeviationTextBox.Size = new Size(132, 23);
        verticalDeviationTextBox.TabIndex = 19;
        verticalDeviationTextBox.TabStop = false;
        verticalDeviationTextBox.Text = "0";
        verticalDeviationTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // verticalDeviationLabel
        // 
        verticalDeviationLabel.AutoSize = true;
        verticalDeviationLabel.Location = new Point(10, 7);
        verticalDeviationLabel.Name = "verticalDeviationLabel";
        verticalDeviationLabel.Size = new Size(224, 15);
        verticalDeviationLabel.TabIndex = 18;
        verticalDeviationLabel.Text = "Отклонение от прямолинейности, мкм";
        // 
        // lineDeviationPanel
        // 
        lineDeviationPanel.BorderStyle = BorderStyle.FixedSingle;
        lineDeviationPanel.Controls.Add(lineDeviationTextBox);
        lineDeviationPanel.Controls.Add(lineDeviationLabel);
        lineDeviationPanel.Location = new Point(8, 307);
        lineDeviationPanel.Name = "lineDeviationPanel";
        lineDeviationPanel.Size = new Size(679, 31);
        lineDeviationPanel.TabIndex = 20;
        // 
        // lineDeviationTextBox
        // 
        lineDeviationTextBox.BackColor = SystemColors.Control;
        lineDeviationTextBox.BorderStyle = BorderStyle.FixedSingle;
        lineDeviationTextBox.Location = new Point(403, 3);
        lineDeviationTextBox.Name = "lineDeviationTextBox";
        lineDeviationTextBox.ReadOnly = true;
        lineDeviationTextBox.Size = new Size(132, 23);
        lineDeviationTextBox.TabIndex = 22;
        lineDeviationTextBox.TabStop = false;
        lineDeviationTextBox.Text = "0";
        lineDeviationTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // lineDeviationLabel
        // 
        lineDeviationLabel.AutoSize = true;
        lineDeviationLabel.Location = new Point(10, 7);
        lineDeviationLabel.Name = "lineDeviationLabel";
        lineDeviationLabel.Size = new Size(350, 15);
        lineDeviationLabel.TabIndex = 21;
        lineDeviationLabel.Text = "Отклонение от прямолинейности на локальном участке, мкм";
        // 
        // bedPanelLength
        // 
        bedPanelLength.BorderStyle = BorderStyle.FixedSingle;
        bedPanelLength.Controls.Add(textBox8);
        bedPanelLength.Controls.Add(bedLengthTextBox);
        bedPanelLength.Controls.Add(bedLengthLabel);
        bedPanelLength.Location = new Point(8, 344);
        bedPanelLength.Name = "bedPanelLength";
        bedPanelLength.Size = new Size(679, 31);
        bedPanelLength.TabIndex = 23;
        // 
        // bedLengthTextBox
        // 
        bedLengthTextBox.BorderStyle = BorderStyle.FixedSingle;
        bedLengthTextBox.Location = new Point(403, 3);
        bedLengthTextBox.Name = "bedLengthTextBox";
        bedLengthTextBox.ReadOnly = true;
        bedLengthTextBox.Size = new Size(132, 23);
        bedLengthTextBox.TabIndex = 25;
        bedLengthTextBox.TabStop = false;
        bedLengthTextBox.Text = "0";
        bedLengthTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // bedLengthLabel
        // 
        bedLengthLabel.AutoSize = true;
        bedLengthLabel.Location = new Point(8, 7);
        bedLengthLabel.Name = "bedLengthLabel";
        bedLengthLabel.Size = new Size(129, 15);
        bedLengthLabel.TabIndex = 24;
        bedLengthLabel.Text = "Длина измерения, мм";
        // 
        // localAreaPanel
        // 
        localAreaPanel.BorderStyle = BorderStyle.FixedSingle;
        localAreaPanel.Controls.Add(localAreaTextBox);
        localAreaPanel.Controls.Add(textBox9);
        localAreaPanel.Controls.Add(localAreaLabel);
        localAreaPanel.Location = new Point(8, 381);
        localAreaPanel.Name = "localAreaPanel";
        localAreaPanel.Size = new Size(679, 31);
        localAreaPanel.TabIndex = 26;
        // 
        // localAreaTextBox
        // 
        localAreaTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        localAreaTextBox.BorderStyle = BorderStyle.FixedSingle;
        localAreaTextBox.Location = new Point(403, 3);
        localAreaTextBox.Name = "localAreaTextBox";
        localAreaTextBox.Size = new Size(132, 23);
        localAreaTextBox.TabIndex = 28;
        localAreaTextBox.Text = "0";
        localAreaTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox9
        // 
        textBox9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        textBox9.BorderStyle = BorderStyle.FixedSingle;
        textBox9.Location = new Point(540, 3);
        textBox9.Name = "textBox9";
        textBox9.Size = new Size(132, 23);
        textBox9.TabIndex = 29;
        textBox9.Text = "0";
        textBox9.TextAlign = HorizontalAlignment.Right;
        // 
        // localAreaLabel
        // 
        localAreaLabel.AutoSize = true;
        localAreaLabel.Location = new Point(10, 7);
        localAreaLabel.Name = "localAreaLabel";
        localAreaLabel.Size = new Size(140, 15);
        localAreaLabel.TabIndex = 27;
        localAreaLabel.Text = "Локальный участок, мм";
        // 
        // tolerPerMeterPanel
        // 
        tolerPerMeterPanel.BorderStyle = BorderStyle.FixedSingle;
        tolerPerMeterPanel.Controls.Add(tolerPerMeterTextBox);
        tolerPerMeterPanel.Controls.Add(tolerPerMeterLabel);
        tolerPerMeterPanel.Controls.Add(textBox5);
        tolerPerMeterPanel.Location = new Point(8, 418);
        tolerPerMeterPanel.Name = "tolerPerMeterPanel";
        tolerPerMeterPanel.Size = new Size(679, 31);
        tolerPerMeterPanel.TabIndex = 29;
        // 
        // tolerPerMeterTextBox
        // 
        tolerPerMeterTextBox.BorderStyle = BorderStyle.FixedSingle;
        tolerPerMeterTextBox.Location = new Point(403, 3);
        tolerPerMeterTextBox.Name = "tolerPerMeterTextBox";
        tolerPerMeterTextBox.Size = new Size(132, 23);
        tolerPerMeterTextBox.TabIndex = 31;
        tolerPerMeterTextBox.Text = "0";
        tolerPerMeterTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // tolerPerMeterLabel
        // 
        tolerPerMeterLabel.AutoSize = true;
        tolerPerMeterLabel.Location = new Point(10, 7);
        tolerPerMeterLabel.Name = "tolerPerMeterLabel";
        tolerPerMeterLabel.Size = new Size(203, 15);
        tolerPerMeterLabel.TabIndex = 30;
        tolerPerMeterLabel.Text = "Допуск на локальном участке, мкм";
        // 
        // textBox5
        // 
        textBox5.BorderStyle = BorderStyle.FixedSingle;
        textBox5.Location = new Point(541, 3);
        textBox5.Name = "textBox5";
        textBox5.Size = new Size(132, 23);
        textBox5.TabIndex = 32;
        textBox5.Text = "0";
        textBox5.TextAlign = HorizontalAlignment.Right;
        // 
        // tolerLenghtPanel
        // 
        tolerLenghtPanel.BorderStyle = BorderStyle.FixedSingle;
        tolerLenghtPanel.Controls.Add(tolerLenghtTextBox);
        tolerLenghtPanel.Controls.Add(tolerLengthLabel);
        tolerLenghtPanel.Location = new Point(8, 455);
        tolerLenghtPanel.Name = "tolerLenghtPanel";
        tolerLenghtPanel.Size = new Size(679, 31);
        tolerLenghtPanel.TabIndex = 32;
        // 
        // tolerLenghtTextBox
        // 
        tolerLenghtTextBox.BorderStyle = BorderStyle.FixedSingle;
        tolerLenghtTextBox.Location = new Point(403, 3);
        tolerLenghtTextBox.Name = "tolerLenghtTextBox";
        tolerLenghtTextBox.Size = new Size(132, 23);
        tolerLenghtTextBox.TabIndex = 34;
        tolerLenghtTextBox.Text = "0";
        tolerLenghtTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // tolerLengthLabel
        // 
        tolerLengthLabel.AutoSize = true;
        tolerLengthLabel.Location = new Point(10, 7);
        tolerLengthLabel.Name = "tolerLengthLabel";
        tolerLengthLabel.Size = new Size(154, 15);
        tolerLengthLabel.TabIndex = 33;
        tolerLengthLabel.Text = "Допуск на всю длину, мкм";
        // 
        // stepPanel
        // 
        stepPanel.BorderStyle = BorderStyle.FixedSingle;
        stepPanel.Controls.Add(textBox7);
        stepPanel.Controls.Add(stepTextBox);
        stepPanel.Controls.Add(stepLabel);
        stepPanel.Location = new Point(8, 492);
        stepPanel.Name = "stepPanel";
        stepPanel.Size = new Size(679, 31);
        stepPanel.TabIndex = 35;
        // 
        // stepTextBox
        // 
        stepTextBox.BorderStyle = BorderStyle.FixedSingle;
        stepTextBox.Location = new Point(403, 3);
        stepTextBox.Name = "stepTextBox";
        stepTextBox.Size = new Size(132, 23);
        stepTextBox.TabIndex = 37;
        stepTextBox.Text = "0";
        stepTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // stepLabel
        // 
        stepLabel.AutoSize = true;
        stepLabel.Location = new Point(10, 7);
        stepLabel.Name = "stepLabel";
        stepLabel.Size = new Size(331, 15);
        stepLabel.TabIndex = 36;
        stepLabel.Text = "Шаг измерения (расстояние между опорами мостика), мм";
        // 
        // fillDataFormButton
        // 
        fillDataFormButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
        fillDataFormButton.Location = new Point(8, 527);
        fillDataFormButton.Name = "fillDataFormButton";
        fillDataFormButton.Size = new Size(151, 31);
        fillDataFormButton.TabIndex = 38;
        fillDataFormButton.Text = "Заполнить измерения";
        fillDataFormButton.UseVisualStyleBackColor = true;
        fillDataFormButton.Click += fillDataFormButton_Click;
        // 
        // graphicButton
        // 
        graphicButton.Location = new Point(365, 527);
        graphicButton.Name = "graphicButton";
        graphicButton.Size = new Size(100, 31);
        graphicButton.TabIndex = 39;
        graphicButton.Text = "График";
        graphicButton.UseVisualStyleBackColor = true;
        // 
        // saveButton
        // 
        saveButton.Location = new Point(161, 527);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(100, 31);
        saveButton.TabIndex = 40;
        saveButton.Text = "Сохранить";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += saveButton_Click;
        // 
        // loadFileButton
        // 
        loadFileButton.Location = new Point(263, 527);
        loadFileButton.Name = "loadFileButton";
        loadFileButton.Size = new Size(100, 31);
        loadFileButton.TabIndex = 41;
        loadFileButton.Text = "Загрузить";
        loadFileButton.UseVisualStyleBackColor = true;
        // 
        // savePdfButton
        // 
        savePdfButton.Location = new Point(467, 527);
        savePdfButton.Name = "savePdfButton";
        savePdfButton.Size = new Size(100, 31);
        savePdfButton.TabIndex = 42;
        savePdfButton.Text = "Выгрузить PDF";
        savePdfButton.UseVisualStyleBackColor = true;
        // 
        // exitButton
        // 
        exitButton.BackColor = Color.FromArgb(255, 192, 192);
        exitButton.Location = new Point(587, 527);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(100, 31);
        exitButton.TabIndex = 43;
        exitButton.Text = "Выход";
        exitButton.UseVisualStyleBackColor = false;
        // 
        // textBox2
        // 
        textBox2.BackColor = SystemColors.Control;
        textBox2.BorderStyle = BorderStyle.FixedSingle;
        textBox2.Location = new Point(550, 237);
        textBox2.Name = "textBox2";
        textBox2.ReadOnly = true;
        textBox2.Size = new Size(132, 23);
        textBox2.TabIndex = 17;
        textBox2.TabStop = false;
        textBox2.Text = "0";
        textBox2.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox3
        // 
        textBox3.BackColor = SystemColors.Control;
        textBox3.BorderStyle = BorderStyle.FixedSingle;
        textBox3.Location = new Point(550, 274);
        textBox3.Name = "textBox3";
        textBox3.ReadOnly = true;
        textBox3.Size = new Size(132, 23);
        textBox3.TabIndex = 20;
        textBox3.TabStop = false;
        textBox3.Text = "0";
        textBox3.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox4
        // 
        textBox4.BackColor = SystemColors.Control;
        textBox4.BorderStyle = BorderStyle.FixedSingle;
        textBox4.Location = new Point(550, 310);
        textBox4.Name = "textBox4";
        textBox4.ReadOnly = true;
        textBox4.Size = new Size(132, 23);
        textBox4.TabIndex = 23;
        textBox4.TabStop = false;
        textBox4.Text = "0";
        textBox4.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox6
        // 
        textBox6.BorderStyle = BorderStyle.FixedSingle;
        textBox6.Location = new Point(550, 459);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(132, 23);
        textBox6.TabIndex = 35;
        textBox6.Text = "0";
        textBox6.TextAlign = HorizontalAlignment.Right;
        // 
        // panel1
        // 
        panel1.BorderStyle = BorderStyle.FixedSingle;
        panel1.Controls.Add(label4);
        panel1.Controls.Add(panel3);
        panel1.Controls.Add(panel2);
        panel1.Location = new Point(8, 160);
        panel1.Name = "panel1";
        panel1.Size = new Size(683, 31);
        panel1.TabIndex = 44;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(10, 7);
        label4.Name = "label4";
        label4.Size = new Size(69, 15);
        label4.TabIndex = 46;
        label4.Text = "Плоскость:";
        // 
        // panel3
        // 
        panel3.BackColor = SystemColors.ActiveCaption;
        panel3.BorderStyle = BorderStyle.FixedSingle;
        panel3.Controls.Add(label1);
        panel3.Location = new Point(400, -1);
        panel3.Name = "panel3";
        panel3.Size = new Size(140, 384);
        panel3.TabIndex = 45;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(28, 7);
        label1.Name = "label1";
        label1.Size = new Size(96, 15);
        label1.TabIndex = 45;
        label1.Text = "Горизонтальная";
        // 
        // panel2
        // 
        panel2.BackColor = SystemColors.Info;
        panel2.BorderStyle = BorderStyle.FixedSingle;
        panel2.Controls.Add(label2);
        panel2.Location = new Point(539, -1);
        panel2.Name = "panel2";
        panel2.Size = new Size(143, 384);
        panel2.TabIndex = 45;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(32, 7);
        label2.Name = "label2";
        label2.Size = new Size(83, 15);
        label2.TabIndex = 46;
        label2.Text = "Вертикальная";
        // 
        // panel4
        // 
        panel4.BorderStyle = BorderStyle.FixedSingle;
        panel4.Controls.Add(button1);
        panel4.Controls.Add(labelCollimatorType);
        panel4.Controls.Add(label3);
        panel4.Location = new Point(8, 12);
        panel4.Name = "panel4";
        panel4.Size = new Size(361, 31);
        panel4.TabIndex = 45;
        // 
        // button1
        // 
        button1.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        button1.Location = new Point(298, 4);
        button1.Name = "button1";
        button1.Size = new Size(58, 23);
        button1.TabIndex = 2;
        button1.Text = "Изменить";
        button1.UseVisualStyleBackColor = true;
        // 
        // labelCollimatorType
        // 
        labelCollimatorType.AutoSize = true;
        labelCollimatorType.Location = new Point(164, 8);
        labelCollimatorType.Name = "labelCollimatorType";
        labelCollimatorType.Size = new Size(126, 15);
        labelCollimatorType.TabIndex = 1;
        labelCollimatorType.Text = "Тут отображается тип";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(9, 8);
        label3.Name = "label3";
        label3.Size = new Size(154, 15);
        label3.TabIndex = 0;
        label3.Text = "Модель автоколлиматора:";
        // 
        // textBox7
        // 
        textBox7.BorderStyle = BorderStyle.FixedSingle;
        textBox7.Location = new Point(541, 3);
        textBox7.Name = "textBox7";
        textBox7.Size = new Size(132, 23);
        textBox7.TabIndex = 38;
        textBox7.Text = "0";
        textBox7.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox8
        // 
        textBox8.BorderStyle = BorderStyle.FixedSingle;
        textBox8.Location = new Point(541, 3);
        textBox8.Name = "textBox8";
        textBox8.ReadOnly = true;
        textBox8.Size = new Size(132, 23);
        textBox8.TabIndex = 26;
        textBox8.TabStop = false;
        textBox8.Text = "0";
        textBox8.TextAlign = HorizontalAlignment.Right;
        // 
        // CollimatorMainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(692, 564);
        Controls.Add(panel4);
        Controls.Add(panel1);
        Controls.Add(textBox6);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(bedPanelLength);
        Controls.Add(localAreaPanel);
        Controls.Add(descriptionPanel);
        Controls.Add(loadFileButton);
        Controls.Add(saveButton);
        Controls.Add(exitButton);
        Controls.Add(savePdfButton);
        Controls.Add(graphicButton);
        Controls.Add(fillDataFormButton);
        Controls.Add(stepPanel);
        Controls.Add(tolerPerMeterPanel);
        Controls.Add(tolerLenghtPanel);
        Controls.Add(lineDeviationPanel);
        Controls.Add(verticalDeviationPanel);
        Controls.Add(minDeviationPanel);
        Controls.Add(maxDeviationPanel);
        Controls.Add(fioPanel);
        Controls.Add(namePanel);
        Controls.Add(datePanel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "CollimatorMainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Прямолинейность";
        datePanel.ResumeLayout(false);
        datePanel.PerformLayout();
        namePanel.ResumeLayout(false);
        namePanel.PerformLayout();
        descriptionPanel.ResumeLayout(false);
        descriptionPanel.PerformLayout();
        fioPanel.ResumeLayout(false);
        fioPanel.PerformLayout();
        maxDeviationPanel.ResumeLayout(false);
        maxDeviationPanel.PerformLayout();
        minDeviationPanel.ResumeLayout(false);
        minDeviationPanel.PerformLayout();
        verticalDeviationPanel.ResumeLayout(false);
        verticalDeviationPanel.PerformLayout();
        lineDeviationPanel.ResumeLayout(false);
        lineDeviationPanel.PerformLayout();
        bedPanelLength.ResumeLayout(false);
        bedPanelLength.PerformLayout();
        localAreaPanel.ResumeLayout(false);
        localAreaPanel.PerformLayout();
        tolerPerMeterPanel.ResumeLayout(false);
        tolerPerMeterPanel.PerformLayout();
        tolerLenghtPanel.ResumeLayout(false);
        tolerLenghtPanel.PerformLayout();
        stepPanel.ResumeLayout(false);
        stepPanel.PerformLayout();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel3.ResumeLayout(false);
        panel3.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        panel4.ResumeLayout(false);
        panel4.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }


    #endregion

    private DateTimePicker dateTimePicker;
    private ComboBox fioComboBox;
    private ComboBox nameComboBox;
    private Label dateLabel;
    private Label nameLabel;
    private Label fioLabel;
    private Label maxDeviationLabel;
    private Label minDeviationLabel;
    private Label verticalDeviationLabel;
    private Label lineDeviationLabel;
    private Label tolerLengthLabel;
    private Label tolerPerMeterLabel;
    private Label stepLabel;
    private Panel datePanel;
    private Panel namePanel;
    private Panel fioPanel;
    private Panel maxDeviationPanel;
    private Panel minDeviationPanel;
    private Panel verticalDeviationPanel;
    private Panel lineDeviationPanel;
    private Panel tolerLenghtPanel;
    private Panel tolerPerMeterPanel;
    private Panel stepPanel;
    private Button graphicButton;
    private Button savePdfButton;
    private Button exitButton;
    private TextBox maxDeviationTextBox;
    private TextBox minDeviationTextBox;
    private TextBox verticalDeviationTextBox;
    private TextBox tolerLenghtTextBox;
    private TextBox tolerPerMeterTextBox;
    private TextBox stepTextBox;
    private Button loadFileButton;
    private Button saveButton;
    private Button fillDataFormButton;
    private Panel descriptionPanel;
    private ComboBox descriptionComboBox;
    private Label descriptionLabel;
    private Panel localAreaPanel;
    private Panel bedPanelLength;
    private Label localAreaLabel;
    private Label bedLengthLabel;
    private TextBox localAreaTextBox;
    private TextBox bedLengthTextBox;
    internal TextBox lineDeviationTextBox;
    private TextBox textBox1;
    private TextBox textBox5;
    private TextBox textBox2;
    private TextBox textBox3;
    internal TextBox textBox4;
    private TextBox textBox6;
    private TextBox textBox9;
    private Panel panel1;
    private Panel panel3;
    private Panel panel2;
    private Label label1;
    private Label label2;
    private Panel panel4;
    public Label labelCollimatorType;
    private Label label3;
    private Button button1;
    private Label label4;
    private TextBox textBox8;
    private TextBox textBox7;
}

