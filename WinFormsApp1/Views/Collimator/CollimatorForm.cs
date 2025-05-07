using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;


namespace PryamolineynostWF.Views.Collimator;

public partial class CollimatorForm : Form
{
    public EventHandler btnCollimatorTypeChangeClicked;
    public EventHandler btnShowDataFormClicked;
    public EventHandler btnSaveChangedClicked;
    public EventHandler btnLoadChangedClicked;
    public EventHandler btnGraphicFormClicked;
    public EventHandler btnPdfFormClicked;
    public EventHandler btnExitClicked;

    public CollimatorForm(CollimatorType collimatorType, DateTime date, string actNumber)
    {
        InitializeComponent();
        lblColimmatorType.Text = collimatorType.ToString();
        FormClosing += (s, e) =>
        {
                Application.Exit();
        };
    }

    private void btnCollimatorTypeChange_Click(object sender, EventArgs e)
    {
        btnCollimatorTypeChangeClicked?.Invoke(this, e);
    }

    private void btnShowDataForm_Click(object sender, EventArgs e)
    {
        btnShowDataFormClicked?.Invoke(this, e);
    }

    private void btnSaveChanged_Click(object sender, EventArgs e)
    {
        btnSaveChangedClicked?.Invoke(this, e);
    }

    private void btnLoadChanged_Click(object sender, EventArgs e)
    {
        btnLoadChangedClicked?.Invoke(this, e);
    }

    private void btnGraphicForm_Click(object sender, EventArgs e)
    {
        btnGraphicFormClicked?.Invoke(this, e);
    }

    private void btnPdfForm_Click(object sender, EventArgs e)
    {
        btnPdfFormClicked?.Invoke(this, e);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        btnExitClicked?.Invoke(this, e);
    }

    public void SwitchPlane(Plane plane)
    {
        switch (plane)
        {
            case (Plane.Horizontal):
                lblHorizontalPlate.Enabled = true;
                lblHorizontalMaxDeviation.Enabled = true;
                lblHorizontalMinDeviation.Enabled = true;
                lblHorizontalMeanDeviation.Enabled = true;
                GetLblHorizontalLineDeviation.Enabled = true;
                tbHorizontalTolerLocalAreaSize.Enabled = true;
                tbHorizontalTolerAllLength.Enabled = true;

                lblVerticalPlate.Enabled = false;
                lblVerticalMaxDeviation.Enabled = false;
                lblVericalMinDeviation.Enabled = false;
                lblVerticalMeanDeviation.Enabled = false;
                GetLblVerticalLineDeviation.Enabled = false;
                tbVerticalTolerLocalAreaSize.Enabled = false;
                tbVerticalTolerAllLength.Enabled = false;

                break;
            case (Plane.Vertical):
                lblHorizontalPlate.Enabled = false;
                lblHorizontalMaxDeviation.Enabled = false;
                lblHorizontalMinDeviation.Enabled = false;
                lblHorizontalMeanDeviation.Enabled = false;
                GetLblHorizontalLineDeviation.Enabled = false;
                tbHorizontalTolerLocalAreaSize.Enabled = false;
                tbHorizontalTolerAllLength.Enabled = false;

                lblVerticalPlate.Enabled = true;
                lblVerticalMaxDeviation.Enabled = true;
                lblVericalMinDeviation.Enabled = true;
                lblVerticalMeanDeviation.Enabled = true;
                GetLblVerticalLineDeviation.Enabled = true;
                tbVerticalTolerLocalAreaSize.Enabled = true;
                tbVerticalTolerAllLength.Enabled = true;
                break;

            case (Plane.Both):
                lblHorizontalPlate.Enabled = true;
                lblHorizontalMaxDeviation.Enabled = true;
                lblHorizontalMinDeviation.Enabled = true;
                lblHorizontalMeanDeviation.Enabled = true;
                GetLblHorizontalLineDeviation.Enabled = true;
                tbHorizontalTolerLocalAreaSize.Enabled = true;
                tbHorizontalTolerAllLength.Enabled = true;

                lblVerticalPlate.Enabled = true;
                lblVerticalMaxDeviation.Enabled = true;
                lblVericalMinDeviation.Enabled = true;
                lblVerticalMeanDeviation.Enabled = true;
                GetLblVerticalLineDeviation.Enabled = true;
                tbVerticalTolerLocalAreaSize.Enabled = true;
                tbVerticalTolerAllLength.Enabled = true;
                break;

        }
    }

    public DateTimePicker GetDateTimeControl => tpDate;
    public Label GetLblColimmatorType => lblColimmatorType;
    public TextBox GetTbObjectName => tbObjectName;
    public TextBox GetTbDescription => tbDescription;
    public TextBox GetTbWorkerName => tbWorkerName;
    public TextBox GetTbLocalAreaSize => tbLocalAreaSize;
    public TextBox GetTbHorizontalTolerLocalAreaSize => tbHorizontalTolerLocalAreaSize;
    public TextBox GetTbHorizontalTolerAllLength => tbHorizontalTolerAllLength;
    public TextBox GetTbVerticalTolerLocalAreaSize => tbVerticalTolerLocalAreaSize;
    public TextBox GetTbVerticalTolerAllLength => tbVerticalTolerAllLength;
    public TextBox GetTbStepSize => tbStepSize;
    public Label GetLblBedLength => lblBedLengthValue;
    public Label GetLblHorizontalMaxDeviation => lblHorizontalMaxDeviation;
    public Label GetLblVerticalMaxDeviation => lblVerticalMaxDeviation;
    public Label GetLblHorizontalMinDeviation => lblHorizontalMinDeviation;
    public Label GetLblVericalMinDeviation => lblVericalMinDeviation;
    public Label GetLblHorizontalMeanDeviation => lblHorizontalMeanDeviation;
    public Label GetLblVerticalMeanDeviation => lblVerticalMeanDeviation;
    public Label GetLblHorizontalLineDeviation => lblHorizontalLineDeviation;
    public Label GetLblVerticalLineDeviation => lblVerticalLineDeviation;
}