using LogicLibrary;
using Pryamolineynost;
using PryamolineynostWF.Controllers.Collimator;
using PryamolineynostWF.Views;
using PryamolineynostWF.Views.Collimator;

namespace PryamolineynostWF;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();
        //var deviceChooserForm = new DeviceChooseForm();
        //Application.Run(deviceChooserForm);


        var controller = new CollimatorController(Enums.CollimatorType.ACU05, DateTime.Now, "123");
        Application.Run(controller.View);
    }
}