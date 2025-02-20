using System.Data;
namespace PryamolineynostWF.Models.Collimator
{
    public class DimensionTable : DataTable
    {
        public DimensionTable(string tableName)
        {
            TableName = tableName;
            Columns.Add("Interval", typeof(int));
            //Columns.Add("fStroke", typeof(Angle));
            //Columns.Add("revStroke", typeof(Angle));
            //Columns.Add("meanAngle", typeof(Angle));
            Columns.Add("bi", typeof(decimal));
            Columns.Add("hi", typeof(decimal));
            Columns.Add("Ai", typeof(decimal));
            Columns.Add("Bi", typeof(decimal));
            Columns.Add("Hi", typeof(decimal));
        }
    }
}
