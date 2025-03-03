using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Enums;


namespace PryamolineynostWF.Views.Collimator;

public partial class CollimatorMainForm : Form
{
    private readonly CollimatorController _controller;
    private CollimatorType _collimatorType;
    private DateOnly _inspectionDate;
    private string _actNumber;
    public EventHandler btnCollimatorTypeChangeClicked;
    public EventHandler dateTimePickerValueChanged;
    public EventHandler tbToolNameChanged;
    public EventHandler tbDescriptionChanged;
    public EventHandler tbWorkerNameChanged;
    public EventHandler tbHLocalAreaSizeChanged;
    public EventHandler tbHTolerLocalAreaSizeChanged;
    public EventHandler tbHTolerAllLengthChanged;
    public EventHandler tbHStepSizeChanged;
    public EventHandler tbVLocalAreaSizeChanged;
    public EventHandler tbVTolerLocalAreaSizeChanged;
    public EventHandler tbVTolerAllLengthChanged;
    public EventHandler tbVStepSizeChanged;
    public EventHandler btnShowDataFormClicked;
    public EventHandler btnSaveChangedClicked;
    public EventHandler btnLoadChangedClicked;
    public EventHandler btnGraphicFormClicked;
    public EventHandler btnPdfFormClicked;
    public EventHandler btnExitClicked;


    public CollimatorMainForm(CollimatorType collimatorType, DateTime date, string actNumber)
    {
        InitializeComponent();
        _controller = new CollimatorController(this, collimatorType, date, actNumber);
        _lblColimmatorType.Text = collimatorType.ToString();
        
    }

    private void tbToolName_Change(object sender, EventArgs e)
    {
        tbToolNameChanged?.Invoke(this, e);
    }

    private void tbDescription_Change(object sender, EventArgs e)
    {
        tbDescriptionChanged?.Invoke(this, e);
    }

    private void tbWorkerName_Change(object sender, EventArgs e)
    {
        tbWorkerNameChanged?.Invoke(this, e);
    }

    private void dateTimePicker_ValueChange(object sender, EventArgs e)
    {
        dateTimePickerValueChanged?.Invoke(this, e);
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

    private void tbHLocalAreaSize_Change(object sender, EventArgs e)
    {
        tbHLocalAreaSizeChanged.Invoke(this, e);
    }

    private void tbHTolerLocalAreaSize_Change(object sender, EventArgs e)
    {
        tbHTolerLocalAreaSizeChanged.Invoke(this, e);
    }

    private void tbHTolerAllLength_Change(object sender, EventArgs e)
    {
        tbHTolerAllLengthChanged.Invoke(this, e);
    }

    private void tbHStepSize_Change(object sender, EventArgs e)
    {
        tbHStepSizeChanged.Invoke(this, e);
    }
    
    private void tbVLocalAreaSize_Change(object sender, EventArgs e)
    {
        tbVLocalAreaSizeChanged.Invoke(this, e);
    }

    private void tbVTolerLocalAreaSize_Change(object sender, EventArgs e)
    {
        tbVTolerLocalAreaSizeChanged.Invoke(this, e);
    }

    private void tbVTolerAllLength_Change(object sender, EventArgs e)
    {
        tbVTolerAllLengthChanged.Invoke(this, e);
    }

    private void tbVStepSize_Change(object sender, EventArgs e)
    {
        tbVStepSizeChanged.Invoke(this, e);
    }
}