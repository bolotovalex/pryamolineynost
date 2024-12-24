using System;
using CommunityToolkit.Mvvm.Input;
namespace PryamolineynostNew.ViewModels;

public partial class ExitPageViewModel : PageViewModelBase
{
    private PageViewModelBase? _prevPanel;
    [RelayCommand]
    private void ExitButton_Click()
    {
        Environment.Exit(0);
    }

    [RelayCommand]
    private void CancelButton_Click()
    {
        
    }

    public void SetPrevPanel(PageViewModelBase panel)
    {
        _prevPanel = panel;
    }
}
