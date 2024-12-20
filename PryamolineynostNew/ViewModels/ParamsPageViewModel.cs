using System;
using ReactiveUI;
using System.Reactive;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PryamolineynostNew.ViewModels
{
    public partial class ParamsPageViewModel : PageViewModelBase
    {
        [ObservableProperty]
        private string? _projectName;

        public void UpdateProjectName(string projectName)
        {
            _projectName = projectName;
        }
        //public string? ProjectName
        //{
        //    get => _projectName;
        //    set => this.RaiseAndSetIfChanged(ref _projectName, value); 
        //}

        public ParamsPageViewModel()
        {
            // Реакция на изменения в свойстве Text
            
        }
        
    }
    
    
}
