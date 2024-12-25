using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PryamolineynostNew.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly PageViewModelBase homePageViewModel;
        

        [ObservableProperty]
        private Models.Enums.Tools _selectedTool;

        private readonly PageViewModelBase[] _pages;

        public MainWindowViewModel()
        {
            homePageViewModel = new HomePageViewModel(this);
            _pages = new PageViewModelBase[]
            {
                homePageViewModel,
                new LevelParamsPageViewModel(),
                new DataPageViewModel(),
                new GraphicPageViewModel(),
                new SettingsPageViewModel(),
                new ExitPageViewModel(),
                new CollimatorParamsPageViewModel()
                
            };
            _currentPage = _pages[0];
        }

        [ObservableProperty]
        private PageViewModelBase _currentPage;
        [ObservableProperty]
        private bool isHomePageActive;

        [RelayCommand]
        public void SetHomePage()
        {
            CurrentPage = _pages[0];
            ActivatePage("Home");
        }

        [RelayCommand]
        private void ExitButton_Click()
        {
            // Implementation for ExitButton_Click
        }

        public void SetParamsPage()
        {
            if (SelectedTool == Models.Enums.Tools.Level)
            {
                CurrentPage = _pages[1];
            }
            else if (SelectedTool == Models.Enums.Tools.Autocollimator)
            {
                CurrentPage = _pages[6];
            }
        }

        public void SetGraphicPage() => CurrentPage = _pages[3];
        public void SetSettingsPage() => CurrentPage = _pages[4];
        public void SetExitPage() => CurrentPage = _pages[5];

        private void ActivatePage(string page)
        {
            IsHomePageActive = page == "Home";
            // Additional page activation logic
        }
    }
}