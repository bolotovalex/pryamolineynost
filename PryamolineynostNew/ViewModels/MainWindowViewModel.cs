using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PryamolineynostNew.Models.LevelTool;
using PryamolineynostNew.Interfaces;

namespace PryamolineynostNew.ViewModels
{
    
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private static Models.Enums.Tools _tool;
        
        private PageViewModelBase _prevPanel;

        public PageViewModelBase PrevPanel
        {
            get => _prevPanel;
            set => SetProperty(ref _prevPanel, value);
        }
        public static Models.Enums.Tools ModelTools
        {
            get => _tool;
            set
            {
                _tool = value;
                
            }
            
        }

        public MainWindowViewModel()
        {
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
        public void SetParamsPage() 
        {
            if (Tool == Models.Enums.Tools.Level)
            {
                CurrentPage = _pages[1];
            }
            else if (Tool == Models.Enums.Tools.Autocollimator)
            {
                CurrentPage = _pages[2];
            }
        }
        //public void SetDataPage()
        //{
                          
        //} 
        public void SetGraphicPage() => CurrentPage = _pages[3];
        public void SetSettingsPage() => CurrentPage = _pages[4];
        public void SetExitPage()
        {
            PrevPanel = CurrentPage;
            CurrentPage = _pages[5];
        }

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
