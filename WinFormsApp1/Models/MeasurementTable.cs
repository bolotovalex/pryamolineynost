namespace PryamolineynostWF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;

    public class MeasurementTable
    {
        private string _name;
        private List<Column> _columns = new List<Column>();
        private BindingList<Row> _rows = new BindingList<Row>();
        private DataTable _dataTable = new DataTable();
        public List<Column> Columns => _columns;
        public BindingList<Row> Rows => _rows;
        public DataTable DataTable => _dataTable;
        public MeasurementTable(string tableName)
        {
            _name = tableName;
            _columns.Add(new Column("id", "ID", typeof(int)));
            _dataTable.Columns.Add("ID", typeof(int));
        }
        
        public class Column
        {
            public string DisplayName { get; private set; } // Имя для отображения
            public string Name { get; private set; } // Имя для обращения
            public Type DataType { get; private set; }

            public Column(string name, string displayName, Type dataType)
            {
                Name = name;
                DisplayName = displayName;
                DataType = dataType;
            }
        }
        
        public void AddColumn(string name, string displayName, Type dataType, bool readOnly = false)
        {
            _columns.Add(new Column(name, displayName, dataType));
            _dataTable.Columns.Add(displayName, dataType); // Используем DisplayName в DataTable
            _dataTable.Columns[displayName].ReadOnly = readOnly;

        }

        public class Row
        {
            private Dictionary<string, object> _values = new Dictionary<string, object>();

            public Row(Dictionary<string, object> values)
            {
                _values = values;
            }

            public object this[string columnName]
            {
                get
                {
                    return _values[columnName];
                }
                set
                {
                    _values[columnName] = value;
                }
            }
        }
        
        public void AddRow(params object[] values)
        {
            
            if (values.Length != _columns.Count-1)
                throw new ArgumentException("Количество значений не совпадает с количеством колонок.");

            Dictionary<string, object> rowValues = new Dictionary<string, object>();
            object[] dataTableRow = new object[values.Length+1];
            dataTableRow[0] = _rows.Count;
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].GetType() != _columns[i].DataType)
                {
                    if (_columns[i].DataType == typeof(decimal) && values[i] is int intValue)
                    {
                        dataTableRow[i] = Convert.ToDecimal(intValue);
                    }
                    else if (_columns[i].DataType == typeof(string))
                    {
                        dataTableRow[i] = values[i].ToString();
                    }
                    else
                    {
                        throw new ArgumentException($"Тип данных в колонке {_columns[i].Name} должен быть {_columns[i].DataType.Name}");    
                    }
                    
                }
                rowValues[_columns[i].Name] = values[i];
                dataTableRow[i] = values[i];
            }

            _rows.Add(new Row(rowValues));
            _dataTable.Rows.Add(dataTableRow); // Добавляем строку в DataTable
        }

        public IEnumerable<object> this[string columnName] => _rows.Select(row => row[columnName]);
    }
}
