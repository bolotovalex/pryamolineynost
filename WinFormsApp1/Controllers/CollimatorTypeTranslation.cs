using PryamolineynostWF.Enums;

namespace PryamolineynostWF.Controllers
{
    public static class CollimatorTypeTranslation
    {
        public static readonly Dictionary<CollimatorType, string> GetTranslation = new()
            {
                {CollimatorType.ACU02, "АКУ-0.2" },
                {CollimatorType.ACU05, "АКУ-0.5" },
                {CollimatorType.ACU1, "АКУ-1" },
            };
    }
}
