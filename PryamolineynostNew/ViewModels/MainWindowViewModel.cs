using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace PryamolineynostNew.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _currentPage = _pages[0];
        }
        
        private readonly PageViewModelBase[] _pages =
        {
            new HomePageViewModel(),
            new ParamsPageViewModel(),
            new DataPageViewModel(),
            new GraphicPageViewModel(),
            new SettingsPageViewModel()
        };

        [ObservableProperty]
        private PageViewModelBase _currentPage;
        
        public void SetHomePage() => CurrentPage = _pages[0];
        public void SetParamsPage() => CurrentPage = _pages[1];
        public void SetDataPage() => CurrentPage = _pages[2];
        public void SetGraphicPage() => CurrentPage = _pages[3];
        public void SetSettingsPage() => CurrentPage = _pages[4];
    }
}
