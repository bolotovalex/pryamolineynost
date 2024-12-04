namespace Pryamolineynost
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            dataGrid = new DataGridView();
            closeButton = new Button();
            clearDBButton = new Button();
            revStrokeCheckBox = new CheckBox();
            unitComboBox = new ComboBox();
            UnitLabel = new Label();
            id = new DataGridViewTextBoxColumn();
            length = new DataGridViewTextBoxColumn();
            factProfile = new DataGridViewTextBoxColumn();
            straight = new DataGridViewTextBoxColumn();
            deviation = new DataGridViewTextBoxColumn();
            deviationPerMeter = new DataGridViewTextBoxColumn();
            advValue = new DataGridViewTextBoxColumn();
            fStroke = new DataGridViewTextBoxColumn();
            rStroke = new DataGridViewTextBoxColumn();
            fAngel = new DataGridViewTextBoxColumn();
            fMinutes = new DataGridViewTextBoxColumn();
            fSec = new DataGridViewTextBoxColumn();
            revAngel = new DataGridViewTextBoxColumn();
            revMinutes = new DataGridViewTextBoxColumn();
            revSeconds = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { id, length, factProfile, straight, deviation, deviationPerMeter, advValue, fStroke, rStroke, fAngel, fMinutes, fSec, revAngel, revMinutes, revSeconds });
            dataGrid.Location = new Point(3, 2);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new Size(915, 580);
            dataGrid.TabIndex = 3;
            dataGrid.CellEndEdit += DataGrid_CellEndEdit;
            dataGrid.DataContextChanged += DataForm_SizeChanged;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(843, 588);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 4;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // clearDBButton
            // 
            clearDBButton.Location = new Point(3, 588);
            clearDBButton.Name = "clearDBButton";
            clearDBButton.Size = new Size(75, 23);
            clearDBButton.TabIndex = 5;
            clearDBButton.Text = "Очистить";
            clearDBButton.UseVisualStyleBackColor = true;
            clearDBButton.Click += ClearDBButton_Click;
            // 
            // revStrokeCheckBox
            // 
            revStrokeCheckBox.AutoSize = true;
            revStrokeCheckBox.Location = new Point(733, 591);
            revStrokeCheckBox.Name = "revStrokeCheckBox";
            revStrokeCheckBox.Size = new Size(105, 19);
            revStrokeCheckBox.TabIndex = 6;
            revStrokeCheckBox.Text = "Обратный ход";
            revStrokeCheckBox.UseVisualStyleBackColor = true;
            revStrokeCheckBox.CheckedChanged += revStrokeCheckBox_CheckedChanged;
            // 
            // unitComboBox
            // 
            unitComboBox.FormattingEnabled = true;
            unitComboBox.Location = new Point(534, 588);
            unitComboBox.Name = "unitComboBox";
            unitComboBox.Size = new Size(180, 23);
            unitComboBox.TabIndex = 7;
            unitComboBox.SelectedIndexChanged += unitComboBox_SelectedIndexChanged;
            // 
            // UnitLabel
            // 
            UnitLabel.AutoSize = true;
            UnitLabel.Location = new Point(410, 592);
            UnitLabel.Name = "UnitLabel";
            UnitLabel.Size = new Size(122, 15);
            UnitLabel.TabIndex = 8;
            UnitLabel.Text = "Единицы измерения:";
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            id.FillWeight = 87.49394F;
            id.HeaderText = "№ изм (точка)";
            id.MinimumWidth = 50;
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.False;
            id.Width = 50;
            // 
            // length
            // 
            length.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            length.FillWeight = 87.49394F;
            length.HeaderText = "Длина измерения, мм";
            length.Name = "length";
            length.ReadOnly = true;
            // 
            // factProfile
            // 
            factProfile.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            factProfile.FillWeight = 87.49394F;
            factProfile.HeaderText = "Фактический профиль поверхности, мкм";
            factProfile.Name = "factProfile";
            factProfile.ReadOnly = true;
            // 
            // straight
            // 
            straight.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            straight.FillWeight = 87.49394F;
            straight.HeaderText = "Прилегающая прямая, мкм";
            straight.Name = "straight";
            straight.ReadOnly = true;
            // 
            // deviation
            // 
            deviation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deviation.FillWeight = 87.49394F;
            deviation.HeaderText = "Отклонение, мкм";
            deviation.Name = "deviation";
            deviation.ReadOnly = true;
            // 
            // deviationPerMeter
            // 
            deviationPerMeter.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deviationPerMeter.FillWeight = 87.49394F;
            deviationPerMeter.HeaderText = "Отклонение на метре, мкм";
            deviationPerMeter.Name = "deviationPerMeter";
            deviationPerMeter.ReadOnly = true;
            // 
            // advValue
            // 
            advValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            advValue.HeaderText = "Среднее значение, мкм";
            advValue.Name = "advValue";
            advValue.ReadOnly = true;
            advValue.Visible = false;
            // 
            // fStroke
            // 
            fStroke.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fStroke.FillWeight = 87.49394F;
            fStroke.HeaderText = "Прямой ход, мкм";
            fStroke.Name = "fStroke";
            // 
            // rStroke
            // 
            rStroke.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            rStroke.HeaderText = "Обратный ход, мкм";
            rStroke.Name = "rStroke";
            rStroke.Visible = false;
            // 
            // fAngel
            // 
            fAngel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fAngel.FillWeight = 45.5837631F;
            fAngel.HeaderText = "°, ПрХод";
            fAngel.MinimumWidth = 9;
            fAngel.Name = "fAngel";
            // 
            // fMinutes
            // 
            fMinutes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fMinutes.FillWeight = 44.73549F;
            fMinutes.HeaderText = "' ПрХод";
            fMinutes.MinimumWidth = 12;
            fMinutes.Name = "fMinutes";
            // 
            // fSec
            // 
            fSec.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fSec.FillWeight = 43.9302979F;
            fSec.HeaderText = "\" ПрХод";
            fSec.MinimumWidth = 15;
            fSec.Name = "fSec";
            // 
            // revAngel
            // 
            revAngel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            revAngel.FillWeight = 51.7991562F;
            revAngel.HeaderText = "° ОбрХод";
            revAngel.MinimumWidth = 14;
            revAngel.Name = "revAngel";
            // 
            // revMinutes
            // 
            revMinutes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            revMinutes.FillWeight = 50.4026375F;
            revMinutes.HeaderText = "', ОбрХод";
            revMinutes.MinimumWidth = 14;
            revMinutes.Name = "revMinutes";
            // 
            // revSeconds
            // 
            revSeconds.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            revSeconds.FillWeight = 49.0911865F;
            revSeconds.HeaderText = "\", ОбрХод";
            revSeconds.MinimumWidth = 14;
            revSeconds.Name = "revSeconds";
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 616);
            Controls.Add(UnitLabel);
            Controls.Add(unitComboBox);
            Controls.Add(revStrokeCheckBox);
            Controls.Add(clearDBButton);
            Controls.Add(closeButton);
            Controls.Add(dataGrid);
            MinimumSize = new Size(640, 480);
            Name = "DataForm";
            Text = "Измерения";
            Load += DataForm_Load;
            Resize += DataForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGrid;
        private Button closeButton;
        private Button clearDBButton;
        private CheckBox revStrokeCheckBox;
        private ComboBox unitComboBox;
        private Label UnitLabel;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn length;
        private DataGridViewTextBoxColumn factProfile;
        private DataGridViewTextBoxColumn straight;
        private DataGridViewTextBoxColumn deviation;
        private DataGridViewTextBoxColumn deviationPerMeter;
        private DataGridViewTextBoxColumn advValue;
        private DataGridViewTextBoxColumn fStroke;
        private DataGridViewTextBoxColumn rStroke;
        private DataGridViewTextBoxColumn fAngel;
        private DataGridViewTextBoxColumn fMinutes;
        private DataGridViewTextBoxColumn fSec;
        private DataGridViewTextBoxColumn revAngel;
        private DataGridViewTextBoxColumn revMinutes;
        private DataGridViewTextBoxColumn revSeconds;
    }
}