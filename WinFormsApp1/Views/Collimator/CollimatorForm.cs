using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;


namespace PryamolineynostWF.Views.Collimator;

public partial class CollimatorForm : Form
{
    //private readonly CollimatorController _controller;
    //private CollimatorType _collimatorType;
    //private DateOnly _inspectionDate;
    //private string _actNumber;
    //public EventHandler tpValueChanged;

    public EventHandler btnCollimatorTypeChangeClicked;
    public EventHandler btnShowDataFormClicked;
    public EventHandler btnSaveChangedClicked;
    public EventHandler btnLoadChangedClicked;
    public EventHandler btnGraphicFormClicked;
    public EventHandler btnPdfFormClicked;
    public EventHandler btnExitClicked;

    //public EventHandler tbToolNameChanged;
    //public EventHandler tbDescriptionChanged;
    //public EventHandler tbWorkerNameChanged;
    //public EventHandler tbHLocalAreaSizeChanged;
    //public EventHandler tbHTolerLocalAreaSizeChanged;
    //public EventHandler tbHTolerAllLengthChanged;
    //public EventHandler tbHStepSizeChanged;
    //public EventHandler tbVLocalAreaSizeChanged;
    //public EventHandler tbVTolerLocalAreaSizeChanged;
    //public EventHandler tbVTolerAllLengthChanged;
    //public EventHandler tbVStepSizeChanged;


    public CollimatorForm(CollimatorType collimatorType, DateTime date, string actNumber)
    {
        InitializeComponent();
        lblColimmatorType.Text = collimatorType.ToString();
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