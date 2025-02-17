using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Models.Collimator
{
    public abstract class DimensionTable
    {
        public DataTable table;
        protected DimensionTable(string tableName)
        {
            this.table = new DataTable(tableName);
            table.Columns.Add("PointNumber", typeof(int));
            table.Columns.Add("Interval", typeof(int));
            table.Columns.Add("fStroke", typeof(Angle));
            table.Columns.Add("revStroke", typeof(Angle));
            table.Columns.Add("meanAngle", typeof(Angle));
            table.Columns.Add("bi", typeof(decimal));
            table.Columns.Add("hi", typeof(decimal));
            table.Columns.Add("Ai", typeof(decimal));
            table.Columns.Add("Bi", typeof(decimal));
            table.Columns.Add("Hi", typeof(decimal));
            table.Rows.Add(0,0,0,0,0,0,0,0,0,0);
        }
    }
}
