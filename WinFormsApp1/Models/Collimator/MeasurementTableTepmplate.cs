using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryamolineynostWF.Models.Collimator
{
    public static class MeasurementTableTepmplate
    {
        public static MeasurementTable GetTable(string tableName)
        {
            var table = new MeasurementTable(tableName);
            table.AddColumn("interval", "Проверяемый интервал, мм", typeof(int));
            table.AddColumn("fDegree", "Пр.° ", typeof(int));
            table.AddColumn("fMinutes", "Пр.'", typeof(int));
            table.AddColumn("fSeconds", "Пр.\"", typeof(decimal));
            table.AddColumn("rDegree", "Обр.° ", typeof(int));
            table.AddColumn("rMinutes", "Обр.'", typeof(int));
            table.AddColumn("rSeconds", "Обр.\"", typeof(decimal));
            table.AddColumn("mean", "Среднее значение", typeof(string));
            table.AddColumn("bi", "βi, угл. с", typeof(string));
            table.AddColumn("hi", "hi, мкм", typeof(string));
            table.AddColumn("Ai", "Ai, мкм", typeof(string));
            table.AddColumn("Bi", "Bi, мкм", typeof(string));
            table.AddColumn("Hi", "Hi, мкм", typeof(string));
            table.AddRow(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            return table;
        }
    }
}
