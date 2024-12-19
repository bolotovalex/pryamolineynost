using LogicLibrary;
using Pryamolineynost;
using PryamolineynostWF.Interfaces;

namespace PryamolineynostWF.Controllers
{
    public class LevelController
    {
        private IView _view;
        private IModel _model;
        public LevelController(IView view, IModel model) 
        {
            _view = view;
            _model = model;
        }
    }
}
