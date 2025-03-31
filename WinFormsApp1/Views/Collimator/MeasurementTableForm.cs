using System.Data;
using PryamolineynostWF.Services;
using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Controllers.Collimator;

public partial class MeasurementTableForm : Form
{
    public EventHandler cbSelectedPlaneChanged;
    public DataGridViewCellValidatingEventHandler dataGridViewCellValidating;
    public DataGridViewCellCancelEventHandler dataGridViewCellBeginEdit;
    public DataGridViewCellEventHandler dataGridViewCellEditEnd;
    public EventHandler RevStrokeChanged;
    public EventHandler AdditionFieldsChanged;


    public MeasurementTableForm(BindingSource horizontalBindingSource, Plane? selectedPlane)
    {
        InitializeComponent();
        dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.DataSource = horizontalBindingSource;

        cbPlaneUse.DataSource = Enum.GetValues(typeof(Plane))
            .Cast<Plane>()
            .Select(e => new { Value = e, Name = e.GetDescription() })
            .ToList();

        cbPlaneUse.DisplayMember = "Name";
        cbPlaneUse.ValueMember = "Value";
        cbPlaneUse.SelectedValue = selectedPlane;
        cbPlaneUse.SelectedValueChanged += cbPlaneUse_Change;
    }

    private void DataGridView1_CellValidated(object sender, DataGridViewCellValidatingEventArgs e)
    {
        dataGridViewCellValidating?.Invoke(this, e);
    }

    private void Panel1_AutoSizeChanged(object sender, EventArgs e)
    {
        panel1.Width = Width;
    }

    private void cbPlaneUse_Change(object sender, EventArgs e)
    {
        cbSelectedPlaneChanged?.Invoke(this, e);
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void RevStrokeCheckBox_Changed(object sender, EventArgs e)
    {
        RevStrokeChanged?.Invoke(this, e);
    }

    private void DataGridViewCell_EditEnd(object sender, DataGridViewCellEventArgs e)
    {
        dataGridViewCellEditEnd?.Invoke(this, e);
    }

    private void DataGridViewCell_BeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        dataGridViewCellBeginEdit?.Invoke(this, e);
    }

    private void AdditionFields_Changed(object sender, EventArgs e)
    {
        AdditionFieldsChanged?.Invoke(this, e);
    }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Первая строка с данными (индекс 0)
        if (e.RowIndex == 0)
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
        }
    }
}