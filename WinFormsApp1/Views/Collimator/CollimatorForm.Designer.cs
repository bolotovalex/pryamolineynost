using System.ComponentModel;

namespace PryamolineynostWF.Views.Collimator;

partial class CollimatorForm
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
        tbObjectName = new TextBox();
        pnlDescription = new Panel();
        tbDescription = new TextBox();
        lblDescription = new Label();
        pnlWorkerName = new Panel();
        tbWorkerName = new TextBox();
        lblWorkerName = new Label();
        pnlMaxDeviation = new Panel();
        lblVerticalMaxDeviation = new Label();
        lblHorizontalMaxDeviation = new Label();
        lblMaxDeviation = new Label();
        pnlMinDeviation = new Panel();
        lblVericalMinDeviation = new Label();
        lblHorizontalMinDeviation = new Label();
        lblMinDeviation = new Label();
        pnlMeanDeviation = new Panel();
        lblVerticalMeanDeviation = new Label();
        lblHorizontalMeanDeviation = new Label();
        lblMeanDeviation = new Label();
        pnlLineDeviation = new Panel();
        lblVerticalLineDeviation = new Label();
        lblHorizontalLineDeviation = new Label();
        lnlLineDeviation = new Label();
        pnlBedLength = new Panel();
        lblBedLengthValue = new Label();
        lblBedLength = new Label();
        pnlLocalArea = new Panel();
        tbLocalAreaSize = new TextBox();
        lblLocalArea = new Label();
        pnlTolerPerMeter = new Panel();
        tbHorizontalTolerLocalAreaSize = new TextBox();
        lblTolerPerMeter = new Label();
        tbVerticalTolerLocalAreaSize = new TextBox();
        pnlTolerLenght = new Panel();
        tbHorizontalTolerAllLength = new TextBox();
        lblTolerLength = new Label();
        pnlStep = new Panel();
        tbStepSize = new TextBox();
        lblStep = new Label();
        btnShowDataForm = new Button();
        btnGraphicForm = new Button();
        btnSave = new Button();
        btnLoad = new Button();
        btnPdfForm = new Button();
        btnExit = new Button();
        tbVerticalTolerAllLength = new TextBox();
        pnlPlate = new Panel();
        lblPlateType = new Label();
        pnlVerticalPlate = new Panel();
        lblHorizontalPlate = new Label();
        pnlHorizontalPlate = new Panel();
        lblVerticalPlate = new Label();
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
        pnlMeanDeviation.SuspendLayout();
        pnlLineDeviation.SuspendLayout();
        pnlBedLength.SuspendLayout();
        pnlLocalArea.SuspendLayout();
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
        pnlDate.Location = new Point(429, 16);
        pnlDate.Margin = new Padding(3, 4, 3, 4);
        pnlDate.Name = "pnlDate";
        pnlDate.Size = new Size(356, 41);
        pnlDate.TabIndex = 0;
        // 
        // lblDate
        // 
        lblDate.AutoSize = true;
        lblDate.Location = new Point(11, 9);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(41, 20);
        lblDate.TabIndex = 3;
        lblDate.Text = "Дата";
        // 
        // tpDate
        // 
        tpDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        tpDate.CustomFormat = "dd MMMM yyyy";
        tpDate.Location = new Point(184, 4);
        tpDate.Margin = new Padding(3, 4, 3, 4);
        tpDate.MinDate = new DateTime(2024, 9, 1, 0, 0, 0, 0);
        tpDate.Name = "tpDate";
        tpDate.RightToLeft = RightToLeft.No;
        tpDate.Size = new Size(166, 27);
        tpDate.TabIndex = 1;
        // 
        // pnlNameProject
        // 
        pnlNameProject.BorderStyle = BorderStyle.FixedSingle;
        pnlNameProject.Controls.Add(lblName);
        pnlNameProject.Controls.Add(tbObjectName);
        pnlNameProject.Location = new Point(9, 65);
        pnlNameProject.Margin = new Padding(3, 4, 3, 4);
        pnlNameProject.Name = "pnlNameProject";
        pnlNameProject.Size = new Size(776, 41);
        pnlNameProject.TabIndex = 2;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(11, 9);
        lblName.Name = "lblName";
        lblName.Size = new Size(329, 20);
        lblName.TabIndex = 3;
        lblName.Text = "Наименование проверяемого оборудования";
        // 
        // tbObjectName
        // 
        tbObjectName.Location = new Point(341, 4);
        tbObjectName.Margin = new Padding(3, 4, 3, 4);
        tbObjectName.Name = "tbObjectName";
        tbObjectName.RightToLeft = RightToLeft.Yes;
        tbObjectName.Size = new Size(426, 27);
        tbObjectName.TabIndex = 4;
        // 
        // pnlDescription
        // 
        pnlDescription.BorderStyle = BorderStyle.FixedSingle;
        pnlDescription.Controls.Add(tbDescription);
        pnlDescription.Controls.Add(lblDescription);
        pnlDescription.Location = new Point(9, 115);
        pnlDescription.Margin = new Padding(3, 4, 3, 4);
        pnlDescription.Name = "pnlDescription";
        pnlDescription.Size = new Size(776, 41);
        pnlDescription.TabIndex = 5;
        // 
        // tbDescription
        // 
        tbDescription.Location = new Point(208, 4);
        tbDescription.Margin = new Padding(3, 4, 3, 4);
        tbDescription.Name = "tbDescription";
        tbDescription.RightToLeft = RightToLeft.Yes;
        tbDescription.Size = new Size(558, 27);
        tbDescription.TabIndex = 7;
        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(9, 9);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(198, 20);
        lblDescription.TabIndex = 6;
        lblDescription.Text = "Обозначение поверхности";
        // 
        // pnlWorkerName
        // 
        pnlWorkerName.BorderStyle = BorderStyle.FixedSingle;
        pnlWorkerName.Controls.Add(tbWorkerName);
        pnlWorkerName.Controls.Add(lblWorkerName);
        pnlWorkerName.Location = new Point(9, 164);
        pnlWorkerName.Margin = new Padding(3, 4, 3, 4);
        pnlWorkerName.Name = "pnlWorkerName";
        pnlWorkerName.Size = new Size(776, 41);
        pnlWorkerName.TabIndex = 8;
        // 
        // tbWorkerName
        // 
        tbWorkerName.Location = new Point(177, 4);
        tbWorkerName.Margin = new Padding(3, 4, 3, 4);
        tbWorkerName.Name = "tbWorkerName";
        tbWorkerName.RightToLeft = RightToLeft.Yes;
        tbWorkerName.Size = new Size(589, 27);
        tbWorkerName.TabIndex = 10;
        // 
        // lblWorkerName
        // 
        lblWorkerName.AutoSize = true;
        lblWorkerName.Location = new Point(11, 9);
        lblWorkerName.Name = "lblWorkerName";
        lblWorkerName.Size = new Size(160, 20);
        lblWorkerName.TabIndex = 9;
        lblWorkerName.Text = "Измерение произвел";
        // 
        // pnlMaxDeviation
        // 
        pnlMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlMaxDeviation.Controls.Add(lblVerticalMaxDeviation);
        pnlMaxDeviation.Controls.Add(lblHorizontalMaxDeviation);
        pnlMaxDeviation.Controls.Add(lblMaxDeviation);
        pnlMaxDeviation.Location = new Point(9, 261);
        pnlMaxDeviation.Margin = new Padding(3, 4, 3, 4);
        pnlMaxDeviation.Name = "pnlMaxDeviation";
        pnlMaxDeviation.Size = new Size(776, 41);
        pnlMaxDeviation.TabIndex = 11;
        // 
        // lblVerticalMaxDeviation
        // 
        lblVerticalMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblVerticalMaxDeviation.Location = new Point(616, 4);
        lblVerticalMaxDeviation.Name = "lblVerticalMaxDeviation";
        lblVerticalMaxDeviation.Size = new Size(153, 30);
        lblVerticalMaxDeviation.TabIndex = 28;
        lblVerticalMaxDeviation.Text = "lblVerticalMaxDeviation";
        lblVerticalMaxDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblHorizontalMaxDeviation
        // 
        lblHorizontalMaxDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblHorizontalMaxDeviation.Location = new Point(461, 4);
        lblHorizontalMaxDeviation.Name = "lblHorizontalMaxDeviation";
        lblHorizontalMaxDeviation.Size = new Size(151, 30);
        lblHorizontalMaxDeviation.TabIndex = 15;
        lblHorizontalMaxDeviation.Text = "lblHorizontalMaxDeviation";
        lblHorizontalMaxDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblMaxDeviation
        // 
        lblMaxDeviation.AutoSize = true;
        lblMaxDeviation.Location = new Point(11, 9);
        lblMaxDeviation.Name = "lblMaxDeviation";
        lblMaxDeviation.Size = new Size(221, 20);
        lblMaxDeviation.TabIndex = 12;
        lblMaxDeviation.Text = "Наибольшее отклонение, мкм";
        // 
        // pnlMinDeviation
        // 
        pnlMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlMinDeviation.Controls.Add(lblVericalMinDeviation);
        pnlMinDeviation.Controls.Add(lblHorizontalMinDeviation);
        pnlMinDeviation.Controls.Add(lblMinDeviation);
        pnlMinDeviation.Location = new Point(9, 311);
        pnlMinDeviation.Margin = new Padding(3, 4, 3, 4);
        pnlMinDeviation.Name = "pnlMinDeviation";
        pnlMinDeviation.Size = new Size(776, 41);
        pnlMinDeviation.TabIndex = 14;
        // 
        // lblVericalMinDeviation
        // 
        lblVericalMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblVericalMinDeviation.Location = new Point(616, 4);
        lblVericalMinDeviation.Name = "lblVericalMinDeviation";
        lblVericalMinDeviation.Size = new Size(153, 30);
        lblVericalMinDeviation.TabIndex = 29;
        lblVericalMinDeviation.Text = "lblVericalMinDeviation";
        lblVericalMinDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblHorizontalMinDeviation
        // 
        lblHorizontalMinDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblHorizontalMinDeviation.Location = new Point(461, 4);
        lblHorizontalMinDeviation.Name = "lblHorizontalMinDeviation";
        lblHorizontalMinDeviation.Size = new Size(151, 30);
        lblHorizontalMinDeviation.TabIndex = 16;
        lblHorizontalMinDeviation.Text = "lblHorizontalMinDeviation";
        lblHorizontalMinDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblMinDeviation
        // 
        lblMinDeviation.AutoSize = true;
        lblMinDeviation.Location = new Point(11, 9);
        lblMinDeviation.Name = "lblMinDeviation";
        lblMinDeviation.Size = new Size(223, 20);
        lblMinDeviation.TabIndex = 15;
        lblMinDeviation.Text = "Наименьшее отклонение, мкм";
        // 
        // pnlMeanDeviation
        // 
        pnlMeanDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlMeanDeviation.Controls.Add(lblVerticalMeanDeviation);
        pnlMeanDeviation.Controls.Add(lblHorizontalMeanDeviation);
        pnlMeanDeviation.Controls.Add(lblMeanDeviation);
        pnlMeanDeviation.Location = new Point(9, 360);
        pnlMeanDeviation.Margin = new Padding(3, 4, 3, 4);
        pnlMeanDeviation.Name = "pnlMeanDeviation";
        pnlMeanDeviation.Size = new Size(776, 41);
        pnlMeanDeviation.TabIndex = 17;
        // 
        // lblVerticalMeanDeviation
        // 
        lblVerticalMeanDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblVerticalMeanDeviation.Location = new Point(616, 4);
        lblVerticalMeanDeviation.Name = "lblVerticalMeanDeviation";
        lblVerticalMeanDeviation.Size = new Size(153, 30);
        lblVerticalMeanDeviation.TabIndex = 29;
        lblVerticalMeanDeviation.Text = "lblVerticalMeanDeviation";
        lblVerticalMeanDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblHorizontalMeanDeviation
        // 
        lblHorizontalMeanDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblHorizontalMeanDeviation.Location = new Point(461, 4);
        lblHorizontalMeanDeviation.Name = "lblHorizontalMeanDeviation";
        lblHorizontalMeanDeviation.Size = new Size(151, 30);
        lblHorizontalMeanDeviation.TabIndex = 19;
        lblHorizontalMeanDeviation.Text = "lblHorizontalMeanDeviation";
        lblHorizontalMeanDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblMeanDeviation
        // 
        lblMeanDeviation.AutoSize = true;
        lblMeanDeviation.Location = new Point(11, 9);
        lblMeanDeviation.Name = "lblMeanDeviation";
        lblMeanDeviation.Size = new Size(281, 20);
        lblMeanDeviation.TabIndex = 18;
        lblMeanDeviation.Text = "Отклонение от прямолинейности, мкм";
        // 
        // pnlLineDeviation
        // 
        pnlLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        pnlLineDeviation.Controls.Add(lblVerticalLineDeviation);
        pnlLineDeviation.Controls.Add(lblHorizontalLineDeviation);
        pnlLineDeviation.Controls.Add(lnlLineDeviation);
        pnlLineDeviation.Location = new Point(9, 409);
        pnlLineDeviation.Margin = new Padding(3, 4, 3, 4);
        pnlLineDeviation.Name = "pnlLineDeviation";
        pnlLineDeviation.Size = new Size(776, 41);
        pnlLineDeviation.TabIndex = 20;
        // 
        // lblVerticalLineDeviation
        // 
        lblVerticalLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblVerticalLineDeviation.Location = new Point(616, 4);
        lblVerticalLineDeviation.Name = "lblVerticalLineDeviation";
        lblVerticalLineDeviation.Size = new Size(153, 30);
        lblVerticalLineDeviation.TabIndex = 29;
        lblVerticalLineDeviation.Text = "lblVerticalLineDeviation";
        lblVerticalLineDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblHorizontalLineDeviation
        // 
        lblHorizontalLineDeviation.BorderStyle = BorderStyle.FixedSingle;
        lblHorizontalLineDeviation.Location = new Point(461, 4);
        lblHorizontalLineDeviation.Name = "lblHorizontalLineDeviation";
        lblHorizontalLineDeviation.Size = new Size(151, 30);
        lblHorizontalLineDeviation.TabIndex = 22;
        lblHorizontalLineDeviation.Text = "lblHorizontalLineDeviation";
        lblHorizontalLineDeviation.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lnlLineDeviation
        // 
        lnlLineDeviation.AutoSize = true;
        lnlLineDeviation.Location = new Point(11, 9);
        lnlLineDeviation.Name = "lnlLineDeviation";
        lnlLineDeviation.Size = new Size(438, 20);
        lnlLineDeviation.TabIndex = 21;
        lnlLineDeviation.Text = "Отклонение от прямолинейности на локальном участке, мкм";
        // 
        // pnlBedLength
        // 
        pnlBedLength.BorderStyle = BorderStyle.FixedSingle;
        pnlBedLength.Controls.Add(lblBedLengthValue);
        pnlBedLength.Controls.Add(lblBedLength);
        pnlBedLength.Location = new Point(9, 459);
        pnlBedLength.Margin = new Padding(3, 4, 3, 4);
        pnlBedLength.Name = "pnlBedLength";
        pnlBedLength.Size = new Size(776, 41);
        pnlBedLength.TabIndex = 23;
        // 
        // lblBedLengthValue
        // 
        lblBedLengthValue.BorderStyle = BorderStyle.FixedSingle;
        lblBedLengthValue.Location = new Point(461, 4);
        lblBedLengthValue.Name = "lblBedLengthValue";
        lblBedLengthValue.Size = new Size(308, 30);
        lblBedLengthValue.TabIndex = 25;
        lblBedLengthValue.Text = "lblBedLengthValue";
        lblBedLengthValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblBedLength
        // 
        lblBedLength.AutoSize = true;
        lblBedLength.Location = new Point(9, 9);
        lblBedLength.Name = "lblBedLength";
        lblBedLength.Size = new Size(164, 20);
        lblBedLength.TabIndex = 24;
        lblBedLength.Text = "Длина измерения, мм";
        // 
        // pnlLocalArea
        // 
        pnlLocalArea.BorderStyle = BorderStyle.FixedSingle;
        pnlLocalArea.Controls.Add(tbLocalAreaSize);
        pnlLocalArea.Controls.Add(lblLocalArea);
        pnlLocalArea.Location = new Point(9, 508);
        pnlLocalArea.Margin = new Padding(3, 4, 3, 4);
        pnlLocalArea.Name = "pnlLocalArea";
        pnlLocalArea.Size = new Size(776, 41);
        pnlLocalArea.TabIndex = 26;
        // 
        // tbLocalAreaSize
        // 
        tbLocalAreaSize.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        tbLocalAreaSize.BorderStyle = BorderStyle.FixedSingle;
        tbLocalAreaSize.Location = new Point(461, 4);
        tbLocalAreaSize.Margin = new Padding(3, 4, 3, 4);
        tbLocalAreaSize.Name = "tbLocalAreaSize";
        tbLocalAreaSize.Size = new Size(309, 27);
        tbLocalAreaSize.TabIndex = 28;
        tbLocalAreaSize.Text = "0";
        tbLocalAreaSize.TextAlign = HorizontalAlignment.Center;
        // 
        // lblLocalArea
        // 
        lblLocalArea.AutoSize = true;
        lblLocalArea.Location = new Point(11, 9);
        lblLocalArea.Name = "lblLocalArea";
        lblLocalArea.Size = new Size(173, 20);
        lblLocalArea.TabIndex = 27;
        lblLocalArea.Text = "Локальный участок, мм";
        // 
        // pnlTolerPerMeter
        // 
        pnlTolerPerMeter.BorderStyle = BorderStyle.FixedSingle;
        pnlTolerPerMeter.Controls.Add(tbHorizontalTolerLocalAreaSize);
        pnlTolerPerMeter.Controls.Add(lblTolerPerMeter);
        pnlTolerPerMeter.Controls.Add(tbVerticalTolerLocalAreaSize);
        pnlTolerPerMeter.Location = new Point(9, 557);
        pnlTolerPerMeter.Margin = new Padding(3, 4, 3, 4);
        pnlTolerPerMeter.Name = "pnlTolerPerMeter";
        pnlTolerPerMeter.Size = new Size(776, 41);
        pnlTolerPerMeter.TabIndex = 29;
        // 
        // tbHorizontalTolerLocalAreaSize
        // 
        tbHorizontalTolerLocalAreaSize.BorderStyle = BorderStyle.FixedSingle;
        tbHorizontalTolerLocalAreaSize.Location = new Point(461, 4);
        tbHorizontalTolerLocalAreaSize.Margin = new Padding(3, 4, 3, 4);
        tbHorizontalTolerLocalAreaSize.Name = "tbHorizontalTolerLocalAreaSize";
        tbHorizontalTolerLocalAreaSize.Size = new Size(151, 27);
        tbHorizontalTolerLocalAreaSize.TabIndex = 31;
        tbHorizontalTolerLocalAreaSize.Text = "0";
        tbHorizontalTolerLocalAreaSize.TextAlign = HorizontalAlignment.Right;
        // 
        // lblTolerPerMeter
        // 
        lblTolerPerMeter.AutoSize = true;
        lblTolerPerMeter.Location = new Point(11, 9);
        lblTolerPerMeter.Name = "lblTolerPerMeter";
        lblTolerPerMeter.Size = new Size(251, 20);
        lblTolerPerMeter.TabIndex = 30;
        lblTolerPerMeter.Text = "Допуск на локальном участке, мкм";
        // 
        // tbVerticalTolerLocalAreaSize
        // 
        tbVerticalTolerLocalAreaSize.BorderStyle = BorderStyle.FixedSingle;
        tbVerticalTolerLocalAreaSize.Location = new Point(618, 4);
        tbVerticalTolerLocalAreaSize.Margin = new Padding(3, 4, 3, 4);
        tbVerticalTolerLocalAreaSize.Name = "tbVerticalTolerLocalAreaSize";
        tbVerticalTolerLocalAreaSize.Size = new Size(151, 27);
        tbVerticalTolerLocalAreaSize.TabIndex = 32;
        tbVerticalTolerLocalAreaSize.Text = "0";
        tbVerticalTolerLocalAreaSize.TextAlign = HorizontalAlignment.Right;
        // 
        // pnlTolerLenght
        // 
        pnlTolerLenght.BorderStyle = BorderStyle.FixedSingle;
        pnlTolerLenght.Controls.Add(tbHorizontalTolerAllLength);
        pnlTolerLenght.Controls.Add(lblTolerLength);
        pnlTolerLenght.Location = new Point(9, 607);
        pnlTolerLenght.Margin = new Padding(3, 4, 3, 4);
        pnlTolerLenght.Name = "pnlTolerLenght";
        pnlTolerLenght.Size = new Size(776, 41);
        pnlTolerLenght.TabIndex = 32;
        // 
        // tbHorizontalTolerAllLength
        // 
        tbHorizontalTolerAllLength.BorderStyle = BorderStyle.FixedSingle;
        tbHorizontalTolerAllLength.Location = new Point(461, 4);
        tbHorizontalTolerAllLength.Margin = new Padding(3, 4, 3, 4);
        tbHorizontalTolerAllLength.Name = "tbHorizontalTolerAllLength";
        tbHorizontalTolerAllLength.Size = new Size(151, 27);
        tbHorizontalTolerAllLength.TabIndex = 34;
        tbHorizontalTolerAllLength.Text = "0";
        tbHorizontalTolerAllLength.TextAlign = HorizontalAlignment.Right;
        // 
        // lblTolerLength
        // 
        lblTolerLength.AutoSize = true;
        lblTolerLength.Location = new Point(11, 9);
        lblTolerLength.Name = "lblTolerLength";
        lblTolerLength.Size = new Size(191, 20);
        lblTolerLength.TabIndex = 33;
        lblTolerLength.Text = "Допуск на всю длину, мкм";
        // 
        // pnlStep
        // 
        pnlStep.BorderStyle = BorderStyle.FixedSingle;
        pnlStep.Controls.Add(tbStepSize);
        pnlStep.Controls.Add(lblStep);
        pnlStep.Location = new Point(9, 656);
        pnlStep.Margin = new Padding(3, 4, 3, 4);
        pnlStep.Name = "pnlStep";
        pnlStep.Size = new Size(776, 41);
        pnlStep.TabIndex = 35;
        // 
        // tbStepSize
        // 
        tbStepSize.BorderStyle = BorderStyle.FixedSingle;
        tbStepSize.Location = new Point(461, 4);
        tbStepSize.Margin = new Padding(3, 4, 3, 4);
        tbStepSize.Name = "tbStepSize";
        tbStepSize.Size = new Size(308, 27);
        tbStepSize.TabIndex = 37;
        tbStepSize.Text = "0";
        tbStepSize.TextAlign = HorizontalAlignment.Center;
        // 
        // lblStep
        // 
        lblStep.AutoSize = true;
        lblStep.Location = new Point(11, 9);
        lblStep.Name = "lblStep";
        lblStep.Size = new Size(420, 20);
        lblStep.TabIndex = 36;
        lblStep.Text = "Шаг измерения (расстояние между опорами мостика), мм";
        // 
        // btnShowDataForm
        // 
        btnShowDataForm.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
        btnShowDataForm.Location = new Point(9, 703);
        btnShowDataForm.Margin = new Padding(3, 4, 3, 4);
        btnShowDataForm.Name = "btnShowDataForm";
        btnShowDataForm.Size = new Size(173, 41);
        btnShowDataForm.TabIndex = 38;
        btnShowDataForm.Text = "Заполнить измерения";
        btnShowDataForm.UseVisualStyleBackColor = true;
        btnShowDataForm.Click += btnShowDataForm_Click;
        // 
        // btnGraphicForm
        // 
        btnGraphicForm.Location = new Point(417, 703);
        btnGraphicForm.Margin = new Padding(3, 4, 3, 4);
        btnGraphicForm.Name = "btnGraphicForm";
        btnGraphicForm.Size = new Size(114, 41);
        btnGraphicForm.TabIndex = 39;
        btnGraphicForm.Text = "График";
        btnGraphicForm.UseVisualStyleBackColor = true;
        btnGraphicForm.Click += btnGraphicForm_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(184, 703);
        btnSave.Margin = new Padding(3, 4, 3, 4);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(114, 41);
        btnSave.TabIndex = 40;
        btnSave.Text = "Сохранить";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSaveChanged_Click;
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(301, 703);
        btnLoad.Margin = new Padding(3, 4, 3, 4);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(114, 41);
        btnLoad.TabIndex = 41;
        btnLoad.Text = "Загрузить";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoadChanged_Click;
        // 
        // btnPdfForm
        // 
        btnPdfForm.Location = new Point(534, 703);
        btnPdfForm.Margin = new Padding(3, 4, 3, 4);
        btnPdfForm.Name = "btnPdfForm";
        btnPdfForm.Size = new Size(114, 41);
        btnPdfForm.TabIndex = 42;
        btnPdfForm.Text = "PDF";
        btnPdfForm.UseVisualStyleBackColor = true;
        btnPdfForm.Click += btnPdfForm_Click;
        // 
        // btnExit
        // 
        btnExit.BackColor = Color.FromArgb(255, 192, 192);
        btnExit.Location = new Point(671, 703);
        btnExit.Margin = new Padding(3, 4, 3, 4);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(114, 41);
        btnExit.TabIndex = 43;
        btnExit.Text = "Выход";
        btnExit.UseVisualStyleBackColor = false;
        btnExit.Click += btnExit_Click;
        // 
        // tbVerticalTolerAllLength
        // 
        tbVerticalTolerAllLength.BorderStyle = BorderStyle.FixedSingle;
        tbVerticalTolerAllLength.Location = new Point(629, 612);
        tbVerticalTolerAllLength.Margin = new Padding(3, 4, 3, 4);
        tbVerticalTolerAllLength.Name = "tbVerticalTolerAllLength";
        tbVerticalTolerAllLength.Size = new Size(151, 27);
        tbVerticalTolerAllLength.TabIndex = 35;
        tbVerticalTolerAllLength.Text = "0";
        tbVerticalTolerAllLength.TextAlign = HorizontalAlignment.Right;
        // 
        // pnlPlate
        // 
        pnlPlate.BorderStyle = BorderStyle.FixedSingle;
        pnlPlate.Controls.Add(lblPlateType);
        pnlPlate.Controls.Add(pnlVerticalPlate);
        pnlPlate.Controls.Add(pnlHorizontalPlate);
        pnlPlate.Location = new Point(9, 213);
        pnlPlate.Margin = new Padding(3, 4, 3, 4);
        pnlPlate.Name = "pnlPlate";
        pnlPlate.Size = new Size(780, 41);
        pnlPlate.TabIndex = 44;
        // 
        // lblPlateType
        // 
        lblPlateType.AutoSize = true;
        lblPlateType.Location = new Point(11, 9);
        lblPlateType.Name = "lblPlateType";
        lblPlateType.Size = new Size(84, 20);
        lblPlateType.TabIndex = 46;
        lblPlateType.Text = "Плоскость:";
        // 
        // pnlVerticalPlate
        // 
        pnlVerticalPlate.BackColor = SystemColors.ActiveCaption;
        pnlVerticalPlate.BorderStyle = BorderStyle.FixedSingle;
        pnlVerticalPlate.Controls.Add(lblHorizontalPlate);
        pnlVerticalPlate.Location = new Point(457, -1);
        pnlVerticalPlate.Margin = new Padding(3, 4, 3, 4);
        pnlVerticalPlate.Name = "pnlVerticalPlate";
        pnlVerticalPlate.Size = new Size(160, 511);
        pnlVerticalPlate.TabIndex = 45;
        // 
        // lblHorizontalPlate
        // 
        lblHorizontalPlate.AutoSize = true;
        lblHorizontalPlate.Location = new Point(24, 9);
        lblHorizontalPlate.Name = "lblHorizontalPlate";
        lblHorizontalPlate.Size = new Size(123, 20);
        lblHorizontalPlate.TabIndex = 45;
        lblHorizontalPlate.Text = "Горизонтальная";
        // 
        // pnlHorizontalPlate
        // 
        pnlHorizontalPlate.BackColor = SystemColors.Info;
        pnlHorizontalPlate.BorderStyle = BorderStyle.FixedSingle;
        pnlHorizontalPlate.Controls.Add(lblVerticalPlate);
        pnlHorizontalPlate.Location = new Point(616, -1);
        pnlHorizontalPlate.Margin = new Padding(3, 4, 3, 4);
        pnlHorizontalPlate.Name = "pnlHorizontalPlate";
        pnlHorizontalPlate.Size = new Size(163, 511);
        pnlHorizontalPlate.TabIndex = 45;
        // 
        // lblVerticalPlate
        // 
        lblVerticalPlate.AutoSize = true;
        lblVerticalPlate.Location = new Point(32, 9);
        lblVerticalPlate.Name = "lblVerticalPlate";
        lblVerticalPlate.Size = new Size(106, 20);
        lblVerticalPlate.TabIndex = 46;
        lblVerticalPlate.Text = "Вертикальная";
        // 
        // pnlCollimatorType
        // 
        pnlCollimatorType.BorderStyle = BorderStyle.FixedSingle;
        pnlCollimatorType.Controls.Add(btnCollimatorTypeChange);
        pnlCollimatorType.Controls.Add(lblColimmatorType);
        pnlCollimatorType.Controls.Add(lblModelCollimator);
        pnlCollimatorType.Location = new Point(9, 16);
        pnlCollimatorType.Margin = new Padding(3, 4, 3, 4);
        pnlCollimatorType.Name = "pnlCollimatorType";
        pnlCollimatorType.Size = new Size(412, 41);
        pnlCollimatorType.TabIndex = 45;
        // 
        // btnCollimatorTypeChange
        // 
        btnCollimatorTypeChange.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        btnCollimatorTypeChange.Location = new Point(330, 5);
        btnCollimatorTypeChange.Margin = new Padding(3, 4, 3, 4);
        btnCollimatorTypeChange.Name = "btnCollimatorTypeChange";
        btnCollimatorTypeChange.Size = new Size(77, 31);
        btnCollimatorTypeChange.TabIndex = 2;
        btnCollimatorTypeChange.Text = "Изменить";
        btnCollimatorTypeChange.UseVisualStyleBackColor = true;
        btnCollimatorTypeChange.Click += btnCollimatorTypeChange_Click;
        // 
        // lblColimmatorType
        // 
        lblColimmatorType.AutoSize = true;
        lblColimmatorType.Location = new Point(187, 11);
        lblColimmatorType.Name = "lblColimmatorType";
        lblColimmatorType.Size = new Size(34, 20);
        lblColimmatorType.TabIndex = 1;
        lblColimmatorType.Text = "Тут ";
        // 
        // lblModelCollimator
        // 
        lblModelCollimator.AutoSize = true;
        lblModelCollimator.Location = new Point(10, 11);
        lblModelCollimator.Name = "lblModelCollimator";
        lblModelCollimator.Size = new Size(193, 20);
        lblModelCollimator.TabIndex = 0;
        lblModelCollimator.Text = "Модель автоколлиматора:";
        // 
        // CollimatorForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(791, 752);
        Controls.Add(pnlCollimatorType);
        Controls.Add(pnlPlate);
        Controls.Add(tbVerticalTolerAllLength);
        Controls.Add(pnlBedLength);
        Controls.Add(pnlLocalArea);
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
        Controls.Add(pnlMeanDeviation);
        Controls.Add(pnlMinDeviation);
        Controls.Add(pnlMaxDeviation);
        Controls.Add(pnlWorkerName);
        Controls.Add(pnlNameProject);
        Controls.Add(pnlDate);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Name = "CollimatorForm";
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
        pnlMeanDeviation.ResumeLayout(false);
        pnlMeanDeviation.PerformLayout();
        pnlLineDeviation.ResumeLayout(false);
        pnlLineDeviation.PerformLayout();
        pnlBedLength.ResumeLayout(false);
        pnlBedLength.PerformLayout();
        pnlLocalArea.ResumeLayout(false);
        pnlLocalArea.PerformLayout();
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

    private Button btnGraphicForm;
    private Button btnPdfForm;
    private Button btnExit;
    private Button btnLoad;
    private Button btnSave;
    private Button btnShowDataForm;
    private Button btnCollimatorTypeChange;

    private Panel pnlDate;
    private Panel pnlNameProject;
    private Panel pnlWorkerName;
    private Panel pnlMaxDeviation;
    private Panel pnlMinDeviation;
    private Panel pnlMeanDeviation;
    private Panel pnlLineDeviation;
    private Panel pnlTolerLenght;
    private Panel pnlTolerPerMeter;
    private Panel pnlStep;
    private Panel pnlDescription;
    private Panel pnlLocalArea;
    private Panel pnlBedLength;
    private Panel pnlPlate;
    private Panel pnlVerticalPlate;
    private Panel pnlHorizontalPlate;
    private Panel pnlCollimatorType;

    private Label lblDate;
    private Label lblName;
    private Label lblWorkerName;
    private Label lblMaxDeviation;
    private Label lblMinDeviation;
    private Label lblMeanDeviation;
    private Label lnlLineDeviation;
    private Label lblTolerLength;
    private Label lblTolerPerMeter;
    private Label lblStep;
    private Label lblHorizontalPlate;
    private Label lblVerticalPlate;
    private Label lblColimmatorType;
    private Label lblModelCollimator;
    private Label lblPlateType;
    private Label lblDescription;
    private Label lblLocalArea;
    private Label lblBedLength;
    private Label lblHorizontalMaxDeviation;
    private Label lblVerticalMaxDeviation;
    private Label lblHorizontalMinDeviation;
    private Label lblHorizontalMeanDeviation;
    private Label lblHorizontalLineDeviation;
    private Label lblVericalMinDeviation;
    private Label lblVerticalMeanDeviation;
    private Label lblVerticalLineDeviation;
    private Label lblVerticalBedLength;
    private TextBox tbLocalAreaSize;
    private TextBox tbVerticalTolerLocalAreaSize;
    private TextBox tbVerticalTolerAllLength;
    private TextBox tbWorkerName;
    private TextBox tbObjectName;
    private TextBox tbHorizontalTolerAllLength;
    private TextBox tbHorizontalTolerLocalAreaSize;
    private TextBox tbStepSize;
    private TextBox tbDescription;
    private Label lblBedLengthValue;
}

