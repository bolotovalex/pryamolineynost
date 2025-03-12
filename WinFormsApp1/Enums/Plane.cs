using System.ComponentModel;
using System.Reflection;

namespace PryamolineynostWF.Enums
{
    public enum Plane
    {
        [Description("Гор. + верт.")] Both,
        [Description("Горизонтальная")] Horizontal,
        [Description("Вертикальная")] Vertical
    }
}
