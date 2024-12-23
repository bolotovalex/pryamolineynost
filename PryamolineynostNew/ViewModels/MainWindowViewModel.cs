using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Models.LevelTool;
using PryamolineynostNew.Interfaces;

namespace PryamolineynostNew.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private static Level _model;

        public static Level Model
        {
            get => _model;
            set => _model = value;
        }

        public MainWindowViewModel()
        {
            Model = new Level();
            _currentPage = _pages[0];
            
        }

        private readonly PageViewModelBase[] _pages =
        {
            new HomePageViewModel(),
            new LevelParamsPageViewModel(),
            new DataPageViewModel(),
            new GraphicPageViewModel(),
            new SettingsPageViewModel(),
            new ExitPageViewModel()
        };

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
            
        }
        public void SetParamsPage() => CurrentPage = _pages[1];
        public void SetDataPage() => CurrentPage = _pages[2];
        public void SetGraphicPage() => CurrentPage = _pages[3];
        public void SetSettingsPage() => CurrentPage = _pages[4];
        public void SetExitPage() => CurrentPage = _pages[5];

        private void ActivatePage(string page)
        {
            IsHomePageActive = page == "Home";
            //IsParamsPageActive = page == "Params";
            //IsDataPageActive = page == "Data";
            //IsGraphicPageActive = page == "Graphic";
            //IsSettingsPageActive = page == "Settings";
        }
    }
}
