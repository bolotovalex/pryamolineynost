namespace PryamolineynostWF.Controllers.Collimator
{
    partial class MeasurementTableForm
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            таблицаToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            label1 = new Label();
            cbPlaneUse = new ComboBox();
            cbAdditionsFileldsEnable = new CheckBox();
            cbRevStrokeEnable = new CheckBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            collimatorControllerBindingSource = new BindingSource(components);
            deviceChooseFormBindingSource = new BindingSource(components);
            collimatorCalibrationDateControllerBindingSource = new BindingSource(components);
            dBBindingSource = new BindingSource(components);
            panel2 = new Panel();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)collimatorControllerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deviceChooseFormBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)collimatorCalibrationDateControllerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dBBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, таблицаToolStripMenuItem, справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // таблицаToolStripMenuItem
            // 
            таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            таблицаToolStripMenuItem.Size = new Size(82, 24);
            таблицаToolStripMenuItem.Text = "Таблица";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbPlaneUse);
            panel1.Controls.Add(cbAdditionsFileldsEnable);
            panel1.Controls.Add(cbRevStrokeEnable);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 30);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 44);
            panel1.TabIndex = 1;
            panel1.AutoSizeChanged += Panel1_AutoSizeChanged;
            // 
            // label1
            // 
            label1.Location = new Point(147, 13);
            label1.Name = "label1";
            label1.Size = new Size(81, 24);
            label1.TabIndex = 6;
            label1.Text = "Плоскость:";
            label1.Click += Label1_Click;
            // 
            // cbPlaneUse
            // 
            cbPlaneUse.FormattingEnabled = true;
            cbPlaneUse.Location = new Point(235, 9);
            cbPlaneUse.Margin = new Padding(3, 4, 3, 4);
            cbPlaneUse.Name = "cbPlaneUse";
            cbPlaneUse.Size = new Size(180, 28);
            cbPlaneUse.TabIndex = 5;
            // 
            // cbAdditionsFilelds
            // 
            cbAdditionsFileldsEnable.AutoSize = true;
            cbAdditionsFileldsEnable.Location = new Point(560, 12);
            cbAdditionsFileldsEnable.Margin = new Padding(3, 4, 3, 4);
            cbAdditionsFileldsEnable.Name = "cbAdditionsFilelds";
            cbAdditionsFileldsEnable.Size = new Size(256, 24);
            cbAdditionsFileldsEnable.TabIndex = 4;
            cbAdditionsFileldsEnable.Text = "Показать дополнительные поля";
            cbAdditionsFileldsEnable.TextAlign = ContentAlignment.MiddleCenter;
            cbAdditionsFileldsEnable.UseVisualStyleBackColor = true;
            // 
            // cbRevStrokeEnable
            // 
            cbRevStrokeEnable.AutoSize = true;
            cbRevStrokeEnable.Location = new Point(433, 12);
            cbRevStrokeEnable.Margin = new Padding(3, 4, 3, 4);
            cbRevStrokeEnable.Name = "cbRevStrokeEnable";
            cbRevStrokeEnable.Size = new Size(131, 24);
            cbRevStrokeEnable.TabIndex = 3;
            cbRevStrokeEnable.Text = "Обратный ход";
            cbRevStrokeEnable.TextAlign = ContentAlignment.MiddleCenter;
            cbRevStrokeEnable.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(80, 7);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(61, 33);
            button3.TabIndex = 2;
            button3.Text = "Copy";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(45, 7);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(29, 33);
            button2.TabIndex = 1;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(9, 7);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(29, 33);
            button1.TabIndex = 0;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = collimatorControllerBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 74);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView1.Size = new Size(914, 526);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.CellContentDoubleClick += DataGridView1_CellContentDoubleClick;
            dataGridView1.CellEnter += dataGridView1_CellEnter;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            dataGridView1.CellValidating += DataGridView1_CellValidated;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            // 
            // collimatorControllerBindingSource
            // 
            collimatorControllerBindingSource.DataSource = typeof(CollimatorController);
            // 
            // deviceChooseFormBindingSource
            // 
            deviceChooseFormBindingSource.DataSource = typeof(Views.DeviceChooseForm);
            // 
            // collimatorCalibrationDateControllerBindingSource
            // 
            collimatorCalibrationDateControllerBindingSource.DataSource = typeof(CollimatorCalibrationDateController);
            // 
            // dBBindingSource
            // 
            dBBindingSource.DataSource = typeof(LogicLibrary.DB);
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 566);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(914, 34);
            panel2.TabIndex = 3;
            // 
            // viewDataGridViewTextBoxColumn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel2);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MeasurementForm";
            Text = "0";
            SizeChanged += Panel1_AutoSizeChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)collimatorControllerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)deviceChooseFormBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)collimatorCalibrationDateControllerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dBBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbPlaneUse;

        private System.Windows.Forms.Panel panel2;

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem таблицаToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private Button button2;
        private Button button1;
        public System.Windows.Forms.CheckBox cbAdditionsFileldsEnable;
        public System.Windows.Forms.CheckBox cbRevStrokeEnable;
        private Button button3;
        public System.Windows.Forms.DataGridView dataGridView1;
        private BindingSource collimatorCalibrationDateControllerBindingSource;
        private BindingSource deviceChooseFormBindingSource;
        private BindingSource collimatorControllerBindingSource;
        private BindingSource dBBindingSource;
    }
}