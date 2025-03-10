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
        pnlDate = new Panel();
        lblDate = new Label();
        tpDate = new DateTimePicker();
        pnlNameProject = new Panel();
        lblName = new Label();
        tbToolName = new TextBox();
        pnlDescription = new Panel();
        tbDescription = new TextBox();
        lblDescription = new Label();
        pnlWorkerName = new Panel();
        tbWorkerName = new TextBox();
        lblWorkerName = new Label();
        pnlMaxDeviation = new Panel();
        tbVerticalMaxDeviation = new TextBox();
        tbHorizontalMaxDeviation = new TextBox();
        lblMaxDeviation = new Label();
        pnlMinDeviation = new Panel();
        tbHorizontalMinDeviation = new TextBox();
        lblMinDeviation = new Label();
        pnlVerticalDeviation = new Panel();
        tbHDeviation = new TextBox();
        lblVerticalDeviation = new Label();
        pnlLineDeviation = new Panel();
        tbHLineDeviation = new TextBox();
        lnlLineDeviation = new Label();
        pnlBedLength = new Panel();
        tbVBedLength = new TextBox();
        tbHBedLength = new TextBox();
        lblBedLength = new Label();
        pnlLocalAreaPanel = new Panel();
        tbHLocalAreaSize = new TextBox();
        tbVLocalAreaSize = new TextBox();
        lblLocalArea = new Label();
        pnlTolerPerMeter = new Panel();
        tbHTolerLocalAreaSize = new TextBox();
        lblTolerPerMeter = new Label();
        tbVTolerLocalAreaSize = new TextBox();
        pnlTolerLenght = new Panel();
        tbHTolerAllLength = new TextBox();
        lblTolerLength = new Label();
        pnlStep = new Panel();
        tbVStepSize = new TextBox();
        tbHStepSize = new TextBox();
        lblStep = new Label();
        btnShowDataForm = new Button();
        btnGraphicForm = new Button();
        btnSave = new Button();
        btnLoad = new Button();
        btnPdfForm = new Button();
        btnExit = new Button();
        tbVerticalMinDeviation = new TextBox();
        tbVDeviation = new TextBox();
        tbVLineDeviation = new TextBox();
        tbVTolerAllLength = new TextBox();
        pnlPlate = new Panel();
        lblPlateType = new Label();
        pnlVerticalPlate = new Panel();
        lblVerticalPlate = new Label();
        pnlHorizontalPlate = new Panel();
        lblHorizontalPlate = new Label();
        pnlCollimatorType = new Panel();
        btnCollimatorTypeChange = new Button();
        lblColimmatorType = new Label();
        lblModelCollimator = new Label();
        pnlDate.SuspendLayout();
        pnlNameProject.SuspendLayout();
        pnlDescription.SuspendLayout();
        pnlWorkerName.SuspendLayout();
        pnlMaxDeviation.SuspendLayout();
        pnlMinDeviation.SuspendLayout();
        pnlVerticalDeviation.SuspendLayout();
        pnlLineDeviation.SuspendLayout();
        pnlBedLength.SuspendLayout();
        pnlLocalAreaPanel.SuspendLayout();
        pnlTolerPerMeter.SuspendLayout();
        pnlTolerLenght.SuspendLayout();
        pnlStep.SuspendLayout();
        pnlPlate.SuspendLayout();
        pnlVerticalPlate.SuspendLayout();
        pnlHorizontalPlate.SuspendLayout();
        pnlCollimatorType.SuspendLayout();
        SuspendLayout();
        // 
        // pnlDate
        // 
        pnlDate.BorderStyle = BorderStyle.FixedSingle;
        pnlDate.Controls.Add(lblDate);
        pnlDate.Controls.Add(tpDate);
        pnlDate.Location = new Point(375, 12);
        pnlDate.Name = "pnlDate";
        pnlDate.Size = new Size(312, 31);
        pnlDate.TabIndex = 0;
        // 
        // lblDate
        // 
        lblDate.AutoSize = true;
        lblDate.Location = new Point(10, 7);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(32, 15);
        lblDate.TabIndex = 3;
        lblDate.Text = "Дата";
        // 
        // tpDate
        // 
        tpDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        tpDate.CustomFormat = "dd MMMM yyyy";
        tpDate.Location = new Point(161, 3);
        tpDate.MinDate = new DateTime(2024, 9, 1, 0, 0, 0, 0);
        tpDate.Name = "tpDate";
        tpDate.RightToLeft = RightToLeft.No;
        tpDate.Size = new Size(146, 23);
        tpDate.TabIndex = 1;
        tpDate.ValueChanged += dateTimePicker_ValueChange;
        // 
        // pnlNameProject
        // 
        pnlNameProject.BorderStyle = BorderStyle.FixedSingle;
        pnlNameProject.Controls.Add(lblName);
        pnlNameProject.Controls.Add(tbToolName);
        pnlNameProject.Location = new Point(8, 49);
        pnlNameProject.Name = "pnlNameProject";
        pnlNameProject.Size = new Size(679, 31);
        pnlNameProject.TabIndex = 2;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(10, 7);
        lblName.Name = "lblName";
        lblName.Size = new Size(255, 15);
        lblName.TabIndex = 3;
        lblName.Text = "Наименование проверяемого оборудования";
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
        // pnlDescription
        // 
        pnlDescription.BorderStyle = BorderStyle.FixedSingle;
        pnlDescription.Controls.Add(tbDescription);
        pnlDescription.Controls.Add(lblDescription);
        pnlDescription.Location = new Point(8, 86);
        pnlDescription.Name = "pnlDescription";
        pnlDescription.Size = new Size(679, 31);
        pnlDescription.TabIndex = 5;
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
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(8, 7);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(155, 15);
        lblDescription.TabIndex = 6;
        lblDescription.Text = "Обозначение поверхности";
        // 
        // pnlWorkerName
        // 
        pnlWorkerName.BorderStyle = BorderStyle.FixedSingle;
        pnlWorkerName.Controls.Add(tbWorkerName);
        pnlWorkerName.Controls.Add(lblWorkerName);
        pnlWorkerName.Location = new Point(8, 123);
        pnlWorkerName.Name = "pnlWorkerName";
        pnlWorkerName.Size = new Size(679, 31);
        pnlWorkerName.TabIndex = 8;
        // 
        // tbWorkerName
        // 
        tbWorkerName.Location = new Point(140, 3);
        tbWorkerName.Name = "tbWorkerName";
        tbWorkerName.RightToLeft = RightToLeft.Yes;
        tbWorkerName.Size = new Size(531, 23);
        tbWorkerName.TabIndex = 10;
        tbWorkerName.TextChanged += tbWorkerName_Change;
        // 
        // lblWorkerName
        // 
        lblWorkerName.AutoSize = true;
        lblWorkerName.Location = new Point(10, 7);
        lblWorkerName.Name = "lblWorkerName";
        lblWorkerName.Size = new Size(124, 15);
        lblWorkerName.TabIndex = 9;
        lblWorkerName.Text = "Измерение произвел";
        // 
        // pnlMaxDeviation
        // 
        pnlMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlMaxDeviation.Controls.Add(tbVerticalMaxDeviation);
        pnlMaxDeviation.Controls.Add(tbHorizontalMaxDeviation);
        pnlMaxDeviation.Controls.Add(lblMaxDeviation);
        pnlMaxDeviation.Location = new Point(8, 196);
        pnlMaxDeviation.Name = "pnlMaxDeviation";
        pnlMaxDeviation.Size = new Size(679, 31);
        pnlMaxDeviation.TabIndex = 11;
        // 
        // tbVerticalMaxDeviation
        // 
        tbVerticalMaxDeviation.BackColor = SystemColors.Control;
        tbVerticalMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbVerticalMaxDeviation.Location = new Point(541, 3);
        tbVerticalMaxDeviation.Name = "tbVerticalMaxDeviation";
        tbVerticalMaxDeviation.ReadOnly = true;
        tbVerticalMaxDeviation.Size = new Size(132, 23);
        tbVerticalMaxDeviation.TabIndex = 14;
        tbVerticalMaxDeviation.TabStop = false;
        tbVerticalMaxDeviation.Text = "0";
        tbVerticalMaxDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // tbHorizontalMaxDeviation
        // 
        tbHorizontalMaxDeviation.BackColor = SystemColors.Control;
        tbHorizontalMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbHorizontalMaxDeviation.Location = new Point(404, 3);
        tbHorizontalMaxDeviation.Name = "tbHorizontalMaxDeviation";
        tbHorizontalMaxDeviation.ReadOnly = true;
        tbHorizontalMaxDeviation.Size = new Size(132, 23);
        tbHorizontalMaxDeviation.TabIndex = 13;
        tbHorizontalMaxDeviation.TabStop = false;
        tbHorizontalMaxDeviation.Text = "0";
        tbHorizontalMaxDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // lblMaxDeviation
        // 
        lblMaxDeviation.AutoSize = true;
        lblMaxDeviation.Location = new Point(10, 7);
        lblMaxDeviation.Name = "lblMaxDeviation";
        lblMaxDeviation.Size = new Size(177, 15);
        lblMaxDeviation.TabIndex = 12;
        lblMaxDeviation.Text = "Наибольшее отклонение, мкм";
        // 
        // pnlMinDeviation
        // 
        pnlMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlMinDeviation.Controls.Add(tbHorizontalMinDeviation);
        pnlMinDeviation.Controls.Add(lblMinDeviation);
        pnlMinDeviation.Location = new Point(8, 233);
        pnlMinDeviation.Name = "pnlMinDeviation";
        pnlMinDeviation.Size = new Size(679, 31);
        pnlMinDeviation.TabIndex = 14;
        // 
        // tbHorizontalMinDeviation
        // 
        tbHorizontalMinDeviation.BackColor = SystemColors.Control;
        tbHorizontalMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbHorizontalMinDeviation.Location = new Point(404, 3);
        tbHorizontalMinDeviation.Name = "tbHorizontalMinDeviation";
        tbHorizontalMinDeviation.ReadOnly = true;
        tbHorizontalMinDeviation.Size = new Size(132, 23);
        tbHorizontalMinDeviation.TabIndex = 16;
        tbHorizontalMinDeviation.TabStop = false;
        tbHorizontalMinDeviation.Text = "0";
        tbHorizontalMinDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // lblMinDeviation
        // 
        lblMinDeviation.AutoSize = true;
        lblMinDeviation.Location = new Point(10, 7);
        lblMinDeviation.Name = "lblMinDeviation";
        lblMinDeviation.Size = new Size(178, 15);
        lblMinDeviation.TabIndex = 15;
        lblMinDeviation.Text = "Наименьшее отклонение, мкм";
        // 
        // pnlVerticalDeviation
        // 
        pnlVerticalDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlVerticalDeviation.Controls.Add(tbHDeviation);
        pnlVerticalDeviation.Controls.Add(lblVerticalDeviation);
        pnlVerticalDeviation.Location = new Point(8, 270);
        pnlVerticalDeviation.Name = "pnlVerticalDeviation";
        pnlVerticalDeviation.Size = new Size(679, 31);
        pnlVerticalDeviation.TabIndex = 17;
        // 
        // tbHDeviation
        // 
        tbHDeviation.BackColor = SystemColors.Control;
        tbHDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbHDeviation.Location = new Point(403, 3);
        tbHDeviation.Name = "tbHDeviation";
        tbHDeviation.ReadOnly = true;
        tbHDeviation.Size = new Size(132, 23);
        tbHDeviation.TabIndex = 19;
        tbHDeviation.TabStop = false;
        tbHDeviation.Text = "0";
        tbHDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // lblVerticalDeviation
        // 
        lblVerticalDeviation.AutoSize = true;
        lblVerticalDeviation.Location = new Point(10, 7);
        lblVerticalDeviation.Name = "lblVerticalDeviation";
        lblVerticalDeviation.Size = new Size(224, 15);
        lblVerticalDeviation.TabIndex = 18;
        lblVerticalDeviation.Text = "Отклонение от прямолинейности, мкм";
        // 
        // pnlLineDeviation
        // 
        pnlLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlLineDeviation.Controls.Add(tbHLineDeviation);
        pnlLineDeviation.Controls.Add(lnlLineDeviation);
        pnlLineDeviation.Location = new Point(8, 307);
        pnlLineDeviation.Name = "pnlLineDeviation";
        pnlLineDeviation.Size = new Size(679, 31);
        pnlLineDeviation.TabIndex = 20;
        // 
        // tbHLineDeviation
        // 
        tbHLineDeviation.BackColor = SystemColors.Control;
        tbHLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbHLineDeviation.Location = new Point(403, 3);
        tbHLineDeviation.Name = "tbHLineDeviation";
        tbHLineDeviation.ReadOnly = true;
        tbHLineDeviation.Size = new Size(132, 23);
        tbHLineDeviation.TabIndex = 22;
        tbHLineDeviation.TabStop = false;
        tbHLineDeviation.Text = "0";
        tbHLineDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // lnlLineDeviation
        // 
        lnlLineDeviation.AutoSize = true;
        lnlLineDeviation.Location = new Point(10, 7);
        lnlLineDeviation.Name = "lnlLineDeviation";
        lnlLineDeviation.Size = new Size(350, 15);
        lnlLineDeviation.TabIndex = 21;
        lnlLineDeviation.Text = "Отклонение от прямолинейности на локальном участке, мкм";
        // 
        // pnlBedLength
        // 
        pnlBedLength.BorderStyle = BorderStyle.FixedSingle;
        pnlBedLength.Controls.Add(tbVBedLength);
        pnlBedLength.Controls.Add(tbHBedLength);
        pnlBedLength.Controls.Add(lblBedLength);
        pnlBedLength.Location = new Point(8, 344);
        pnlBedLength.Name = "pnlBedLength";
        pnlBedLength.Size = new Size(679, 31);
        pnlBedLength.TabIndex = 23;
        // 
        // tbVBedLength
        // 
        tbVBedLength.BorderStyle = BorderStyle.FixedSingle;
        tbVBedLength.Location = new Point(541, 3);
        tbVBedLength.Name = "tbVBedLength";
        tbVBedLength.ReadOnly = true;
        tbVBedLength.Size = new Size(132, 23);
        tbVBedLength.TabIndex = 26;
        tbVBedLength.TabStop = false;
        tbVBedLength.Text = "0";
        tbVBedLength.TextAlign = HorizontalAlignment.Right;
        // 
        // tbHBedLength
        // 
        tbHBedLength.BorderStyle = BorderStyle.FixedSingle;
        tbHBedLength.Location = new Point(403, 3);
        tbHBedLength.Name = "tbHBedLength";
        tbHBedLength.ReadOnly = true;
        tbHBedLength.Size = new Size(132, 23);
        tbHBedLength.TabIndex = 25;
        tbHBedLength.TabStop = false;
        tbHBedLength.Text = "0";
        tbHBedLength.TextAlign = HorizontalAlignment.Right;
        // 
        // lblBedLength
        // 
        lblBedLength.AutoSize = true;
        lblBedLength.Location = new Point(8, 7);
        lblBedLength.Name = "lblBedLength";
        lblBedLength.Size = new Size(129, 15);
        lblBedLength.TabIndex = 24;
        lblBedLength.Text = "Длина измерения, мм";
        // 
        // pnlLocalAreaPanel
        // 
        pnlLocalAreaPanel.BorderStyle = BorderStyle.FixedSingle;
        pnlLocalAreaPanel.Controls.Add(tbHLocalAreaSize);
        pnlLocalAreaPanel.Controls.Add(tbVLocalAreaSize);
        pnlLocalAreaPanel.Controls.Add(lblLocalArea);
        pnlLocalAreaPanel.Location = new Point(8, 381);
        pnlLocalAreaPanel.Name = "pnlLocalAreaPanel";
        pnlLocalAreaPanel.Size = new Size(679, 31);
        pnlLocalAreaPanel.TabIndex = 26;
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
        // lblLocalArea
        // 
        lblLocalArea.AutoSize = true;
        lblLocalArea.Location = new Point(10, 7);
        lblLocalArea.Name = "lblLocalArea";
        lblLocalArea.Size = new Size(140, 15);
        lblLocalArea.TabIndex = 27;
        lblLocalArea.Text = "Локальный участок, мм";
        // 
        // pnlTolerPerMeter
        // 
        pnlTolerPerMeter.BorderStyle = BorderStyle.FixedSingle;
        pnlTolerPerMeter.Controls.Add(tbHTolerLocalAreaSize);
        pnlTolerPerMeter.Controls.Add(lblTolerPerMeter);
        pnlTolerPerMeter.Controls.Add(tbVTolerLocalAreaSize);
        pnlTolerPerMeter.Location = new Point(8, 418);
        pnlTolerPerMeter.Name = "pnlTolerPerMeter";
        pnlTolerPerMeter.Size = new Size(679, 31);
        pnlTolerPerMeter.TabIndex = 29;
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
        // lblTolerPerMeter
        // 
        lblTolerPerMeter.AutoSize = true;
        lblTolerPerMeter.Location = new Point(10, 7);
        lblTolerPerMeter.Name = "lblTolerPerMeter";
        lblTolerPerMeter.Size = new Size(203, 15);
        lblTolerPerMeter.TabIndex = 30;
        lblTolerPerMeter.Text = "Допуск на локальном участке, мкм";
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
        // pnlTolerLenght
        // 
        pnlTolerLenght.BorderStyle = BorderStyle.FixedSingle;
        pnlTolerLenght.Controls.Add(tbHTolerAllLength);
        pnlTolerLenght.Controls.Add(lblTolerLength);
        pnlTolerLenght.Location = new Point(8, 455);
        pnlTolerLenght.Name = "pnlTolerLenght";
        pnlTolerLenght.Size = new Size(679, 31);
        pnlTolerLenght.TabIndex = 32;
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
        // lblTolerLength
        // 
        lblTolerLength.AutoSize = true;
        lblTolerLength.Location = new Point(10, 7);
        lblTolerLength.Name = "lblTolerLength";
        lblTolerLength.Size = new Size(154, 15);
        lblTolerLength.TabIndex = 33;
        lblTolerLength.Text = "Допуск на всю длину, мкм";
        // 
        // pnlStep
        // 
        pnlStep.BorderStyle = BorderStyle.FixedSingle;
        pnlStep.Controls.Add(tbVStepSize);
        pnlStep.Controls.Add(tbHStepSize);
        pnlStep.Controls.Add(lblStep);
        pnlStep.Location = new Point(8, 492);
        pnlStep.Name = "pnlStep";
        pnlStep.Size = new Size(679, 31);
        pnlStep.TabIndex = 35;
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
        // lblStep
        // 
        lblStep.AutoSize = true;
        lblStep.Location = new Point(10, 7);
        lblStep.Name = "lblStep";
        lblStep.Size = new Size(331, 15);
        lblStep.TabIndex = 36;
        lblStep.Text = "Шаг измерения (расстояние между опорами мостика), мм";
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
        btnShowDataForm.Click += btnShowDataForm_Click;
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
        // tbVerticalMinDeviation
        // 
        tbVerticalMinDeviation.BackColor = SystemColors.Control;
        tbVerticalMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbVerticalMinDeviation.Location = new Point(550, 237);
        tbVerticalMinDeviation.Name = "tbVerticalMinDeviation";
        tbVerticalMinDeviation.ReadOnly = true;
        tbVerticalMinDeviation.Size = new Size(132, 23);
        tbVerticalMinDeviation.TabIndex = 17;
        tbVerticalMinDeviation.TabStop = false;
        tbVerticalMinDeviation.Text = "0";
        tbVerticalMinDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // tbVDeviation
        // 
        tbVDeviation.BackColor = SystemColors.Control;
        tbVDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbVDeviation.Location = new Point(550, 274);
        tbVDeviation.Name = "tbVDeviation";
        tbVDeviation.ReadOnly = true;
        tbVDeviation.Size = new Size(132, 23);
        tbVDeviation.TabIndex = 20;
        tbVDeviation.TabStop = false;
        tbVDeviation.Text = "0";
        tbVDeviation.TextAlign = HorizontalAlignment.Right;
        // 
        // tbVLineDeviation
        // 
        tbVLineDeviation.BackColor = SystemColors.Control;
        tbVLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        tbVLineDeviation.Location = new Point(550, 310);
        tbVLineDeviation.Name = "tbVLineDeviation";
        tbVLineDeviation.ReadOnly = true;
        tbVLineDeviation.Size = new Size(132, 23);
        tbVLineDeviation.TabIndex = 23;
        tbVLineDeviation.TabStop = false;
        tbVLineDeviation.Text = "0";
        tbVLineDeviation.TextAlign = HorizontalAlignment.Right;
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
        // pnlPlate
        // 
        pnlPlate.BorderStyle = BorderStyle.FixedSingle;
        pnlPlate.Controls.Add(lblPlateType);
        pnlPlate.Controls.Add(pnlVerticalPlate);
        pnlPlate.Controls.Add(pnlHorizontalPlate);
        pnlPlate.Location = new Point(8, 160);
        pnlPlate.Name = "pnlPlate";
        pnlPlate.Size = new Size(683, 31);
        pnlPlate.TabIndex = 44;
        // 
        // lblPlateType
        // 
        lblPlateType.AutoSize = true;
        lblPlateType.Location = new Point(10, 7);
        lblPlateType.Name = "lblPlateType";
        lblPlateType.Size = new Size(69, 15);
        lblPlateType.TabIndex = 46;
        lblPlateType.Text = "Плоскость:";
        // 
        // pnlVerticalPlate
        // 
        pnlVerticalPlate.BackColor = SystemColors.ActiveCaption;
        pnlVerticalPlate.BorderStyle = BorderStyle.FixedSingle;
        pnlVerticalPlate.Controls.Add(lblVerticalPlate);
        pnlVerticalPlate.Location = new Point(400, -1);
        pnlVerticalPlate.Name = "pnlVerticalPlate";
        pnlVerticalPlate.Size = new Size(140, 384);
        pnlVerticalPlate.TabIndex = 45;
        // 
        // lblVerticalPlate
        // 
        lblVerticalPlate.AutoSize = true;
        lblVerticalPlate.Location = new Point(30, 7);
        lblVerticalPlate.Name = "lblVerticalPlate";
        lblVerticalPlate.Size = new Size(83, 15);
        lblVerticalPlate.TabIndex = 46;
        lblVerticalPlate.Text = "Вертикальная";
        // 
        // pnlHorizontalPlate
        // 
        pnlHorizontalPlate.BackColor = SystemColors.Info;
        pnlHorizontalPlate.BorderStyle = BorderStyle.FixedSingle;
        pnlHorizontalPlate.Controls.Add(lblHorizontalPlate);
        pnlHorizontalPlate.Location = new Point(539, -1);
        pnlHorizontalPlate.Name = "pnlHorizontalPlate";
        pnlHorizontalPlate.Size = new Size(143, 384);
        pnlHorizontalPlate.TabIndex = 45;
        // 
        // lblHorizontalPlate
        // 
        lblHorizontalPlate.AutoSize = true;
        lblHorizontalPlate.Location = new Point(24, 7);
        lblHorizontalPlate.Name = "lblHorizontalPlate";
        lblHorizontalPlate.Size = new Size(96, 15);
        lblHorizontalPlate.TabIndex = 45;
        lblHorizontalPlate.Text = "Горизонтальная";
        // 
        // pnlCollimatorType
        // 
        pnlCollimatorType.BorderStyle = BorderStyle.FixedSingle;
        pnlCollimatorType.Controls.Add(btnCollimatorTypeChange);
        pnlCollimatorType.Controls.Add(lblColimmatorType);
        pnlCollimatorType.Controls.Add(lblModelCollimator);
        pnlCollimatorType.Location = new Point(8, 12);
        pnlCollimatorType.Name = "pnlCollimatorType";
        pnlCollimatorType.Size = new Size(361, 31);
        pnlCollimatorType.TabIndex = 45;
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
        // lblColimmatorType
        // 
        lblColimmatorType.AutoSize = true;
        lblColimmatorType.Location = new Point(164, 8);
        lblColimmatorType.Name = "lblColimmatorType";
        lblColimmatorType.Size = new Size(126, 15);
        lblColimmatorType.TabIndex = 1;
        lblColimmatorType.Text = "Тут отображается тип";
        // 
        // lblModelCollimator
        // 
        lblModelCollimator.AutoSize = true;
        lblModelCollimator.Location = new Point(9, 8);
        lblModelCollimator.Name = "lblModelCollimator";
        lblModelCollimator.Size = new Size(154, 15);
        lblModelCollimator.TabIndex = 0;
        lblModelCollimator.Text = "Модель автоколлиматора:";
        // 
        // CollimatorMainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(692, 564);
        Controls.Add(pnlCollimatorType);
        Controls.Add(pnlPlate);
        Controls.Add(tbVTolerAllLength);
        Controls.Add(tbVLineDeviation);
        Controls.Add(tbVDeviation);
        Controls.Add(tbVerticalMinDeviation);
        Controls.Add(pnlBedLength);
        Controls.Add(pnlLocalAreaPanel);
        Controls.Add(pnlDescription);
        Controls.Add(btnLoad);
        Controls.Add(btnSave);
        Controls.Add(btnExit);
        Controls.Add(btnPdfForm);
        Controls.Add(btnGraphicForm);
        Controls.Add(btnShowDataForm);
        Controls.Add(pnlStep);
        Controls.Add(pnlTolerPerMeter);
        Controls.Add(pnlTolerLenght);
        Controls.Add(pnlLineDeviation);
        Controls.Add(pnlVerticalDeviation);
        Controls.Add(pnlMinDeviation);
        Controls.Add(pnlMaxDeviation);
        Controls.Add(pnlWorkerName);
        Controls.Add(pnlNameProject);
        Controls.Add(pnlDate);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "CollimatorMainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Прямолинейность";
        pnlDate.ResumeLayout(false);
        pnlDate.PerformLayout();
        pnlNameProject.ResumeLayout(false);
        pnlNameProject.PerformLayout();
        pnlDescription.ResumeLayout(false);
        pnlDescription.PerformLayout();
        pnlWorkerName.ResumeLayout(false);
        pnlWorkerName.PerformLayout();
        pnlMaxDeviation.ResumeLayout(false);
        pnlMaxDeviation.PerformLayout();
        pnlMinDeviation.ResumeLayout(false);
        pnlMinDeviation.PerformLayout();
        pnlVerticalDeviation.ResumeLayout(false);
        pnlVerticalDeviation.PerformLayout();
        pnlLineDeviation.ResumeLayout(false);
        pnlLineDeviation.PerformLayout();
        pnlBedLength.ResumeLayout(false);
        pnlBedLength.PerformLayout();
        pnlLocalAreaPanel.ResumeLayout(false);
        pnlLocalAreaPanel.PerformLayout();
        pnlTolerPerMeter.ResumeLayout(false);
        pnlTolerPerMeter.PerformLayout();
        pnlTolerLenght.ResumeLayout(false);
        pnlTolerLenght.PerformLayout();
        pnlStep.ResumeLayout(false);
        pnlStep.PerformLayout();
        pnlPlate.ResumeLayout(false);
        pnlPlate.PerformLayout();
        pnlVerticalPlate.ResumeLayout(false);
        pnlVerticalPlate.PerformLayout();
        pnlHorizontalPlate.ResumeLayout(false);
        pnlHorizontalPlate.PerformLayout();
        pnlCollimatorType.ResumeLayout(false);
        pnlCollimatorType.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }


    #endregion

    private DateTimePicker tpDate;
    private TextBox tbWorkerName;
    private TextBox tbToolName;
    private Label lblDate;
    private Label lblName;
    private Label lblWorkerName;
    private Label lblMaxDeviation;
    private Label lblMinDeviation;
    private Label lblVerticalDeviation;
    private Label lnlLineDeviation;
    private Label lblTolerLength;
    private Label lblTolerPerMeter;
    private Label lblStep;
    private Panel pnlDate;
    private Panel pnlNameProject;
    private Panel pnlWorkerName;
    private Panel pnlMaxDeviation;
    private Panel pnlMinDeviation;
    private Panel pnlVerticalDeviation;
    private Panel pnlLineDeviation;
    private Panel pnlTolerLenght;
    private Panel pnlTolerPerMeter;
    private Panel pnlStep;
    private Button btnGraphicForm;
    private Button btnPdfForm;
    private Button btnExit;
    private TextBox tbHorizontalMaxDeviation;
    private TextBox tbHorizontalMinDeviation;
    private TextBox tbHDeviation;
    private TextBox tbHTolerAllLength;
    private TextBox tbHTolerLocalAreaSize;
    private TextBox tbHStepSize;
    private Button btnLoad;
    private Button btnSave;
    private Button btnShowDataForm;
    private Panel pnlDescription;
    private TextBox tbDescription;
    private Label lblDescription;
    private Panel pnlLocalAreaPanel;
    private Panel pnlBedLength;
    private Label lblLocalArea;
    private Label lblBedLength;
    private TextBox tbHLocalAreaSize;
    private TextBox tbHBedLength;
    internal TextBox tbHLineDeviation;
    private TextBox tbVerticalMaxDeviation;
    private TextBox tbVTolerLocalAreaSize;
    private TextBox tbVerticalMinDeviation;
    private TextBox tbVDeviation;
    internal TextBox tbVLineDeviation;
    private TextBox tbVTolerAllLength;
    private TextBox tbVLocalAreaSize;
    private Panel pnlPlate;
    private Panel pnlVerticalPlate;
    private Panel pnlHorizontalPlate;
    private Label lblHorizontalPlate;
    private Label lblVerticalPlate;
    private Panel pnlCollimatorType;
    public Label lblColimmatorType;
    private Label lblModelCollimator;
    private Button btnCollimatorTypeChange;
    private Label lblPlateType;
    private TextBox tbVBedLength;
    private TextBox tbVStepSize;
}

