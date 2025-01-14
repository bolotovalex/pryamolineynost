using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PryamolineynostNew.ViewModels;

namespace PryamolineynostNew.Views;

public partial class CollimatorDataPageView : UserControl
{
    public CollimatorDataPageView()
    {
        InitializeComponent();
        DataContext = new CollimatorDataPageViewModel();
    }
}