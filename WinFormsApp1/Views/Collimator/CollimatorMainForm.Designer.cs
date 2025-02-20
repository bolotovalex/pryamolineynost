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
        _lblDate = new Label();
        dateTimePicker = new DateTimePicker();
        namePanel = new Panel();
        nameLabel = new Label();
        tbToolName = new TextBox();
        descriptionPanel = new Panel();
        tbDescription = new TextBox();
        descriptionLabel = new Label();
        fioPanel = new Panel();
        tbWorkerName = new TextBox();
        fioLabel = new Label();
        maxDeviationPanel = new Panel();
        _tbVMaxDeviation = new TextBox();
        _tbHMaxDeviation = new TextBox();
        maxDeviationLabel = new Label();
        minDeviationPanel = new Panel();
        _tbHMinDeviation = new TextBox();
        minDeviationLabel = new Label();
        verticalDeviationPanel = new Panel();
        _tbHDeviation = new TextBox();
        verticalDeviationLabel = new Label();
        lineDeviationPanel = new Panel();
        _tbHLineDeviation = new TextBox();
        lineDeviationLabel = new Label();
        bedPanelLength = new Panel();
        _tbVBedLength = new TextBox();
        _tbHBedLength = new TextBox();
        bedLengthLabel = new Label();
        localAreaPanel = new Panel();
        tbHLocalAreaSize = new TextBox();
        tbVLocalAreaSize = new TextBox();
        localAreaLabel = new Label();
        tolerPerMeterPanel = new Panel();
        tbHTolerLocalAreaSize = new TextBox();
        tolerPerMeterLabel = new Label();
        tbVTolerLocalAreaSize = new TextBox();
        tolerLenghtPanel = new Panel();
        tbHTolerAllLength = new TextBox();
        tolerLengthLabel = new Label();
        stepPanel = new Panel();
        tbVStepSize = new TextBox();
        tbHStepSize = new TextBox();
        stepLabel = new Label();
        btnShowDataForm = new Button();
        btnGraphicForm = new Button();
        btnSave = new Button();
        btnLoad = new Button();
        btnPdfForm = new Button();
        btnExit = new Button();
        _tbVMinDeviation = new TextBox();
        _tbVDeviation = new TextBox();
        _tbVLineDeviation = new TextBox();
        tbVTolerAllLength = new TextBox();
        panel1 = new Panel();
        label4 = new Label();
        panel3 = new Panel();
        label2 = new Label();
        panel2 = new Panel();
        label1 = new Label();
        panel4 = new Panel();
        btnCollimatorTypeChange = new Button();
        _lblColimmatorType = new Label();
        _lblModelCollimator = new Label();
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
        datePanel.Controls.Add(_lblDate);
        datePanel.Controls.Add(dateTimePicker);
        datePanel.Location = new Point(375, 12);
        datePanel.Name = "datePanel";
        datePanel.Size = new Size(312, 31);
        datePanel.TabIndex = 0;
        // 
        // _lblDate
        // 
        _lblDate.AutoSize = true;
        _lblDate.Location = new Point(10, 7);
        _lblDate.Name = "_lblDate";
        _lblDate.Size = new Size(32, 15);
        _lblDate.TabIndex = 3;
        _lblDate.Text = "Дата";
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
        dateTimePicker.ValueChanged += dateTimePicker_ValueChange;
        
        // 
        // namePanel
        // 
        namePanel.BorderStyle = BorderStyle.FixedSingle;
        namePanel.Controls.Add(nameLabel);
        namePanel.Controls.Add(tbToolName);
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
        // tbToolName
        // 
        tbToolName.Location = new Point(271, 3);
        tbToolName.Name = "tbToolName";
        tbToolName.RightToLeft = RightToLeft.Yes;
        tbToolName.Size = new Size(400, 23);
        tbToolName.TabIndex = 4;
        tbToolName.TextChanged += tbToolName_Change;
        // 
        // descriptionPanel
        // 
        descriptionPanel.BorderStyle = BorderStyle.FixedSingle;
        descriptionPanel.Controls.Add(tbDescription);
        descriptionPanel.Controls.Add(descriptionLabel);
        descriptionPanel.Location = new Point(8, 86);
        descriptionPanel.Name = "descriptionPanel";
        descriptionPanel.Size = new Size(679, 31);
        descriptionPanel.TabIndex = 5;
        // 
        // tbDescription
        // 
        tbDescription.Location = new Point(169, 3);
        tbDescription.Name = "tbDescription";
        tbDescription.RightToLeft = RightToLeft.Yes;
        tbDescription.Size = new Size(502, 23);
        tbDescription.TabIndex = 7;
        tbDescription.TextChanged += tbDescription_Change;
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
        fioPanel.Controls.Add(tbWorkerName);
        fioPanel.Controls.Add(fioLabel);
        fioPanel.Location = new Point(8, 123);
        fioPanel.Name = "fioPanel";
        fioPanel.Size = new Size(679, 31);
        fioPanel.TabIndex = 8;
        tbWorkerName.TextChanged += tbWorkerName_Change;
        // 
        // tbWorkerName
        // 
        tbWorkerName.Location = new Point(140, 3);
        tbWorkerName.Name = "tbWorkerName";
        tbWorkerName.RightToLeft = RightToLeft.Yes;
        tbWorkerName.Size = new Size(531, 23);
        tbWorkerName.TabIndex = 10;
        tbWorkerName.TextChanged += tbWorkerNameChanged;
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
        maxDeviationPanel.Controls.Add(_tbVMaxDeviation);
        maxDeviationPanel.Controls.Add(_tbHMaxDeviation);
        maxDeviationPanel.Controls.Add(maxDeviationLabel);
        maxDeviationPanel.Location = new Point(8, 196);
        maxDeviationPanel.Name = "maxDeviationPanel";
        maxDeviationPanel.Size = new Size(679, 31);
        maxDeviationPanel.TabIndex = 11;
        // 
        // _tbVMaxDeviation
        // 
        _tbVMaxDeviation.BackColor = SystemColors.Control;
        _tbVMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbVMaxDeviation.Location = new Point(541, 3);
        _tbVMaxDeviation.Name = "_tbVMaxDeviation";
        _tbVMaxDeviation.ReadOnly = true;
        _tbVMaxDeviation.Size = new Size(132, 23);
        _tbVMaxDeviation.TabIndex = 14;
        _tbVMaxDeviation.TabStop = false;
        _tbVMaxDeviation.Text = "0";
        _tbVMaxDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // _tbHMaxDeviation
        // 
        _tbHMaxDeviation.BackColor = SystemColors.Control;
        _tbHMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbHMaxDeviation.Location = new Point(404, 3);
        _tbHMaxDeviation.Name = "_tbHMaxDeviation";
        _tbHMaxDeviation.ReadOnly = true;
        _tbHMaxDeviation.Size = new Size(132, 23);
        _tbHMaxDeviation.TabIndex = 13;
        _tbHMaxDeviation.TabStop = false;
        _tbHMaxDeviation.Text = "0";
        _tbHMaxDeviation.TextAlign = HorizontalAlignment.Right;
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
        minDeviationPanel.Controls.Add(_tbHMinDeviation);
        minDeviationPanel.Controls.Add(minDeviationLabel);
        minDeviationPanel.Location = new Point(8, 233);
        minDeviationPanel.Name = "minDeviationPanel";
        minDeviationPanel.Size = new Size(679, 31);
        minDeviationPanel.TabIndex = 14;
        // 
        // tbHMinDeviation
        // 
        _tbHMinDeviation.BackColor = SystemColors.Control;
        _tbHMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbHMinDeviation.Location = new Point(404, 3);
        _tbHMinDeviation.Name = "_tbHMinDeviation";
        _tbHMinDeviation.ReadOnly = true;
        _tbHMinDeviation.Size = new Size(132, 23);
        _tbHMinDeviation.TabIndex = 16;
        _tbHMinDeviation.TabStop = false;
        _tbHMinDeviation.Text = "0";
        _tbHMinDeviation.TextAlign = HorizontalAlignment.Right;
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
        verticalDeviationPanel.Controls.Add(_tbHDeviation);
        verticalDeviationPanel.Controls.Add(verticalDeviationLabel);
        verticalDeviationPanel.Location = new Point(8, 270);
        verticalDeviationPanel.Name = "verticalDeviationPanel";
        verticalDeviationPanel.Size = new Size(679, 31);
        verticalDeviationPanel.TabIndex = 17;
        // 
        // tbHDeviation
        // 
        _tbHDeviation.BackColor = SystemColors.Control;
        _tbHDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbHDeviation.Location = new Point(403, 3);
        _tbHDeviation.Name = "_tbHDeviation";
        _tbHDeviation.ReadOnly = true;
        _tbHDeviation.Size = new Size(132, 23);
        _tbHDeviation.TabIndex = 19;
        _tbHDeviation.TabStop = false;
        _tbHDeviation.Text = "0";
        _tbHDeviation.TextAlign = HorizontalAlignment.Right;
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
        lineDeviationPanel.Controls.Add(_tbHLineDeviation);
        lineDeviationPanel.Controls.Add(lineDeviationLabel);
        lineDeviationPanel.Location = new Point(8, 307);
        lineDeviationPanel.Name = "lineDeviationPanel";
        lineDeviationPanel.Size = new Size(679, 31);
        lineDeviationPanel.TabIndex = 20;
        // 
        // tbHLineDeviation
        // 
        _tbHLineDeviation.BackColor = SystemColors.Control;
        _tbHLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbHLineDeviation.Location = new Point(403, 3);
        _tbHLineDeviation.Name = "_tbHLineDeviation";
        _tbHLineDeviation.ReadOnly = true;
        _tbHLineDeviation.Size = new Size(132, 23);
        _tbHLineDeviation.TabIndex = 22;
        _tbHLineDeviation.TabStop = false;
        _tbHLineDeviation.Text = "0";
        _tbHLineDeviation.TextAlign = HorizontalAlignment.Right;
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
        bedPanelLength.Controls.Add(_tbVBedLength);
        bedPanelLength.Controls.Add(_tbHBedLength);
        bedPanelLength.Controls.Add(bedLengthLabel);
        bedPanelLength.Location = new Point(8, 344);
        bedPanelLength.Name = "bedPanelLength";
        bedPanelLength.Size = new Size(679, 31);
        bedPanelLength.TabIndex = 23;
        // 
        // _tbVBedLength
        // 
        _tbVBedLength.BorderStyle = BorderStyle.FixedSingle;
        _tbVBedLength.Location = new Point(541, 3);
        _tbVBedLength.Name = "_tbVBedLength";
        _tbVBedLength.ReadOnly = true;
        _tbVBedLength.Size = new Size(132, 23);
        _tbVBedLength.TabIndex = 26;
        _tbVBedLength.TabStop = false;
        _tbVBedLength.Text = "0";
        _tbVBedLength.TextAlign = HorizontalAlignment.Right;
        // 
        // tbHBedLength
        // 
        _tbHBedLength.BorderStyle = BorderStyle.FixedSingle;
        _tbHBedLength.Location = new Point(403, 3);
        _tbHBedLength.Name = "_tbHBedLength";
        _tbHBedLength.ReadOnly = true;
        _tbHBedLength.Size = new Size(132, 23);
        _tbHBedLength.TabIndex = 25;
        _tbHBedLength.TabStop = false;
        _tbHBedLength.Text = "0";
        _tbHBedLength.TextAlign = HorizontalAlignment.Right;
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
        localAreaPanel.Controls.Add(tbHLocalAreaSize);
        localAreaPanel.Controls.Add(tbVLocalAreaSize);
        localAreaPanel.Controls.Add(localAreaLabel);
        localAreaPanel.Location = new Point(8, 381);
        localAreaPanel.Name = "localAreaPanel";
        localAreaPanel.Size = new Size(679, 31);
        localAreaPanel.TabIndex = 26;
        // 
        // tbHLocalAreaSize
        // 
        tbHLocalAreaSize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        tbHLocalAreaSize.BorderStyle = BorderStyle.FixedSingle;
        tbHLocalAreaSize.Location = new Point(403, 3);
        tbHLocalAreaSize.Name = "tbHLocalAreaSize";
        tbHLocalAreaSize.Size = new Size(132, 23);
        tbHLocalAreaSize.TabIndex = 28;
        tbHLocalAreaSize.Text = "0";
        tbHLocalAreaSize.TextAlign = HorizontalAlignment.Right;
        tbHLocalAreaSize.TextChanged += tbHLocalAreaSize_Change;
        // 
        // tbVLocalAreaSize
        // 
        tbVLocalAreaSize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        tbVLocalAreaSize.BorderStyle = BorderStyle.FixedSingle;
        tbVLocalAreaSize.Location = new Point(540, 3);
        tbVLocalAreaSize.Name = "tbVLocalAreaSize";
        tbVLocalAreaSize.Size = new Size(132, 23);
        tbVLocalAreaSize.TabIndex = 29;
        tbVLocalAreaSize.Text = "0";
        tbVLocalAreaSize.TextAlign = HorizontalAlignment.Right;
        tbVLocalAreaSize.TextChanged += tbVLocalAreaSize_Change;
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
        tolerPerMeterPanel.Controls.Add(tbHTolerLocalAreaSize);
        tolerPerMeterPanel.Controls.Add(tolerPerMeterLabel);
        tolerPerMeterPanel.Controls.Add(tbVTolerLocalAreaSize);
        tolerPerMeterPanel.Location = new Point(8, 418);
        tolerPerMeterPanel.Name = "tolerPerMeterPanel";
        tolerPerMeterPanel.Size = new Size(679, 31);
        tolerPerMeterPanel.TabIndex = 29;
        // 
        // tbHTolerLocalAreaSize
        // 
        tbHTolerLocalAreaSize.BorderStyle = BorderStyle.FixedSingle;
        tbHTolerLocalAreaSize.Location = new Point(403, 3);
        tbHTolerLocalAreaSize.Name = "tbHTolerLocalAreaSize";
        tbHTolerLocalAreaSize.Size = new Size(132, 23);
        tbHTolerLocalAreaSize.TabIndex = 31;
        tbHTolerLocalAreaSize.Text = "0";
        tbHTolerLocalAreaSize.TextAlign = HorizontalAlignment.Right;
        tbHTolerLocalAreaSize.TextChanged += tbHTolerLocalAreaSize_Change;
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
        // tbVTolerLocalAreaSize
        // 
        tbVTolerLocalAreaSize.BorderStyle = BorderStyle.FixedSingle;
        tbVTolerLocalAreaSize.Location = new Point(541, 3);
        tbVTolerLocalAreaSize.Name = "tbVTolerLocalAreaSize";
        tbVTolerLocalAreaSize.Size = new Size(132, 23);
        tbVTolerLocalAreaSize.TabIndex = 32;
        tbVTolerLocalAreaSize.Text = "0";
        tbVTolerLocalAreaSize.TextAlign = HorizontalAlignment.Right;
        tbVTolerLocalAreaSize.TextChanged += tbVTolerLocalAreaSize_Change;
        // 
        // tolerLenghtPanel
        // 
        tolerLenghtPanel.BorderStyle = BorderStyle.FixedSingle;
        tolerLenghtPanel.Controls.Add(tbHTolerAllLength);
        tolerLenghtPanel.Controls.Add(tolerLengthLabel);
        tolerLenghtPanel.Location = new Point(8, 455);
        tolerLenghtPanel.Name = "tolerLenghtPanel";
        tolerLenghtPanel.Size = new Size(679, 31);
        tolerLenghtPanel.TabIndex = 32;
        // 
        // tbHTolerAllLength
        // 
        tbHTolerAllLength.BorderStyle = BorderStyle.FixedSingle;
        tbHTolerAllLength.Location = new Point(403, 3);
        tbHTolerAllLength.Name = "tbHTolerAllLength";
        tbHTolerAllLength.Size = new Size(132, 23);
        tbHTolerAllLength.TabIndex = 34;
        tbHTolerAllLength.Text = "0";
        tbHTolerAllLength.TextAlign = HorizontalAlignment.Right;
        tbHTolerAllLength.TextChanged += tbHTolerAllLength_Change;
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
        stepPanel.Controls.Add(tbVStepSize);
        stepPanel.Controls.Add(tbHStepSize);
        stepPanel.Controls.Add(stepLabel);
        stepPanel.Location = new Point(8, 492);
        stepPanel.Name = "stepPanel";
        stepPanel.Size = new Size(679, 31);
        stepPanel.TabIndex = 35;
        // 
        // tbVStepSize
        // 
        tbVStepSize.BorderStyle = BorderStyle.FixedSingle;
        tbVStepSize.Location = new Point(541, 3);
        tbVStepSize.Name = "tbVStepSize";
        tbVStepSize.Size = new Size(132, 23);
        tbVStepSize.TabIndex = 38;
        tbVStepSize.Text = "0";
        tbVStepSize.TextAlign = HorizontalAlignment.Right;
        tbVStepSize.TextChanged += tbVStepSize_Change;
        // 
        // tbHStepSize
        // 
        tbHStepSize.BorderStyle = BorderStyle.FixedSingle;
        tbHStepSize.Location = new Point(403, 3);
        tbHStepSize.Name = "tbHStepSize";
        tbHStepSize.Size = new Size(132, 23);
        tbHStepSize.TabIndex = 37;
        tbHStepSize.Text = "0";
        tbHStepSize.TextAlign = HorizontalAlignment.Right;
        tbHStepSize.TextChanged += tbHStepSize_Change;
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
        // btnShowDataForm
        // 
        btnShowDataForm.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
        btnShowDataForm.Location = new Point(8, 527);
        btnShowDataForm.Name = "btnShowDataForm";
        btnShowDataForm.Size = new Size(151, 31);
        btnShowDataForm.TabIndex = 38;
        btnShowDataForm.Text = "Заполнить измерения";
        btnShowDataForm.UseVisualStyleBackColor = true;
        btnShowDataForm.Click += btnSaveChanged_Click;
        // 
        // btnGraphicForm
        // 
        btnGraphicForm.Location = new Point(365, 527);
        btnGraphicForm.Name = "btnGraphicForm";
        btnGraphicForm.Size = new Size(100, 31);
        btnGraphicForm.TabIndex = 39;
        btnGraphicForm.Text = "График";
        btnGraphicForm.UseVisualStyleBackColor = true;
        btnGraphicForm.Click += btnGraphicForm_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(161, 527);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(100, 31);
        btnSave.TabIndex = 40;
        btnSave.Text = "Сохранить";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSaveChanged_Click;
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(263, 527);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(100, 31);
        btnLoad.TabIndex = 41;
        btnLoad.Text = "Загрузить";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoadChanged_Click;
        // 
        // btnPdfForm
        // 
        btnPdfForm.Location = new Point(467, 527);
        btnPdfForm.Name = "btnPdfForm";
        btnPdfForm.Size = new Size(100, 31);
        btnPdfForm.TabIndex = 42;
        btnPdfForm.Text = "Выгрузить PDF";
        btnPdfForm.UseVisualStyleBackColor = true;
        btnPdfForm.Click += btnPdfForm_Click;
        // 
        // btnExit
        // 
        btnExit.BackColor = Color.FromArgb(255, 192, 192);
        btnExit.Location = new Point(587, 527);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(100, 31);
        btnExit.TabIndex = 43;
        btnExit.Text = "Выход";
        btnExit.UseVisualStyleBackColor = false;
        btnExit.Click += btnExit_Click;
        // 
        // _tbVMinDeviation
        // 
        _tbVMinDeviation.BackColor = SystemColors.Control;
        _tbVMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbVMinDeviation.Location = new Point(550, 237);
        _tbVMinDeviation.Name = "_tbVMinDeviation";
        _tbVMinDeviation.ReadOnly = true;
        _tbVMinDeviation.Size = new Size(132, 23);
        _tbVMinDeviation.TabIndex = 17;
        _tbVMinDeviation.TabStop = false;
        _tbVMinDeviation.Text = "0";
        _tbVMinDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // _tbVDeviation
        // 
        _tbVDeviation.BackColor = SystemColors.Control;
        _tbVDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbVDeviation.Location = new Point(550, 274);
        _tbVDeviation.Name = "_tbVDeviation";
        _tbVDeviation.ReadOnly = true;
        _tbVDeviation.Size = new Size(132, 23);
        _tbVDeviation.TabIndex = 20;
        _tbVDeviation.TabStop = false;
        _tbVDeviation.Text = "0";
        _tbVDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // _tbVLineDeviation
        // 
        _tbVLineDeviation.BackColor = SystemColors.Control;
        _tbVLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        _tbVLineDeviation.Location = new Point(550, 310);
        _tbVLineDeviation.Name = "_tbVLineDeviation";
        _tbVLineDeviation.ReadOnly = true;
        _tbVLineDeviation.Size = new Size(132, 23);
        _tbVLineDeviation.TabIndex = 23;
        _tbVLineDeviation.TabStop = false;
        _tbVLineDeviation.Text = "0";
        _tbVLineDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // tbVTolerAllLength
        // 
        tbVTolerAllLength.BorderStyle = BorderStyle.FixedSingle;
        tbVTolerAllLength.Location = new Point(550, 459);
        tbVTolerAllLength.Name = "tbVTolerAllLength";
        tbVTolerAllLength.Size = new Size(132, 23);
        tbVTolerAllLength.TabIndex = 35;
        tbVTolerAllLength.Text = "0";
        tbVTolerAllLength.TextAlign = HorizontalAlignment.Right;
        tbVTolerAllLength.TextChanged += tbVTolerAllLength_Change;
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
        panel3.Controls.Add(label2);
        panel3.Location = new Point(400, -1);
        panel3.Name = "panel3";
        panel3.Size = new Size(140, 384);
        panel3.TabIndex = 45;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(30, 7);
        label2.Name = "label2";
        label2.Size = new Size(83, 15);
        label2.TabIndex = 46;
        label2.Text = "Вертикальная";
        // 
        // panel2
        // 
        panel2.BackColor = SystemColors.Info;
        panel2.BorderStyle = BorderStyle.FixedSingle;
        panel2.Controls.Add(label1);
        panel2.Location = new Point(539, -1);
        panel2.Name = "panel2";
        panel2.Size = new Size(143, 384);
        panel2.TabIndex = 45;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(24, 7);
        label1.Name = "label1";
        label1.Size = new Size(96, 15);
        label1.TabIndex = 45;
        label1.Text = "Горизонтальная";
        // 
        // panel4
        // 
        panel4.BorderStyle = BorderStyle.FixedSingle;
        panel4.Controls.Add(btnCollimatorTypeChange);
        panel4.Controls.Add(_lblColimmatorType);
        panel4.Controls.Add(_lblModelCollimator);
        panel4.Location = new Point(8, 12);
        panel4.Name = "panel4";
        panel4.Size = new Size(361, 31);
        panel4.TabIndex = 45;
        // 
        // btnCollimatorTypeChange
        // 
        btnCollimatorTypeChange.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        btnCollimatorTypeChange.Location = new Point(298, 4);
        btnCollimatorTypeChange.Name = "btnCollimatorTypeChange";
        btnCollimatorTypeChange.Size = new Size(58, 23);
        btnCollimatorTypeChange.TabIndex = 2;
        btnCollimatorTypeChange.Text = "Изменить";
        btnCollimatorTypeChange.UseVisualStyleBackColor = true;
        btnCollimatorTypeChange.Click += btnCollimatorTypeChange_Click;
        // 
        // _lblColimmatorType
        // 
        _lblColimmatorType.AutoSize = true;
        _lblColimmatorType.Location = new Point(164, 8);
        _lblColimmatorType.Name = "_lblColimmatorType";
        _lblColimmatorType.Size = new Size(126, 15);
        _lblColimmatorType.TabIndex = 1;
        _lblColimmatorType.Text = "Тут отображается тип";
        // 
        // _lblModelCollimator
        // 
        _lblModelCollimator.AutoSize = true;
        _lblModelCollimator.Location = new Point(9, 8);
        _lblModelCollimator.Name = "_lblModelCollimator";
        _lblModelCollimator.Size = new Size(154, 15);
        _lblModelCollimator.TabIndex = 0;
        _lblModelCollimator.Text = "Модель автоколлиматора:";
        // 
        // CollimatorMainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(692, 564);
        Controls.Add(panel4);
        Controls.Add(panel1);
        Controls.Add(tbVTolerAllLength);
        Controls.Add(_tbVLineDeviation);
        Controls.Add(_tbVDeviation);
        Controls.Add(_tbVMinDeviation);
        Controls.Add(bedPanelLength);
        Controls.Add(localAreaPanel);
        Controls.Add(descriptionPanel);
        Controls.Add(btnLoad);
        Controls.Add(btnSave);
        Controls.Add(btnExit);
        Controls.Add(btnPdfForm);
        Controls.Add(btnGraphicForm);
        Controls.Add(btnShowDataForm);
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
    private TextBox tbWorkerName;
    private TextBox tbToolName;
    private Label _lblDate;
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
    private Button btnGraphicForm;
    private Button btnPdfForm;
    private Button btnExit;
    private TextBox _tbHMaxDeviation;
    private TextBox _tbHMinDeviation;
    private TextBox _tbHDeviation;
    private TextBox tbHTolerAllLength;
    private TextBox tbHTolerLocalAreaSize;
    private TextBox tbHStepSize;
    private Button btnLoad;
    private Button btnSave;
    private Button btnShowDataForm;
    private Panel descriptionPanel;
    private TextBox tbDescription;
    private Label descriptionLabel;
    private Panel localAreaPanel;
    private Panel bedPanelLength;
    private Label localAreaLabel;
    private Label bedLengthLabel;
    private TextBox tbHLocalAreaSize;
    private TextBox _tbHBedLength;
    internal TextBox _tbHLineDeviation;
    private TextBox _tbVMaxDeviation;
    private TextBox tbVTolerLocalAreaSize;
    private TextBox _tbVMinDeviation;
    private TextBox _tbVDeviation;
    internal TextBox _tbVLineDeviation;
    private TextBox tbVTolerAllLength;
    private TextBox tbVLocalAreaSize;
    private Panel panel1;
    private Panel panel3;
    private Panel panel2;
    private Label label1;
    private Label label2;
    private Panel panel4;
    public Label _lblColimmatorType;
    private Label _lblModelCollimator;
    private Button btnCollimatorTypeChange;
    private Label label4;
    private TextBox _tbVBedLength;
    private TextBox tbVStepSize;
}

