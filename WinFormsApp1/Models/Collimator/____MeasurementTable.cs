//namespace PryamolineynostWF.Models.Collimator
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel;
//    using System.Data;
//    using System.Linq;

//    public class MeasurementTable
//    {
//        private string _name;
//        private List<Column> _columns = new List<Column>();
//        private BindingList<Row> _rows = new BindingList<Row>();
//        private DataTable _dataTable = new DataTable();
//        public List<Column> Columns => _columns;
//        public BindingList<Row> Rows => _rows;
//        public DataTable DataTable => _dataTable;
//        public MeasurementTable(string tableName)
//        {
//            _name = tableName;
//            CreateTable();
//        }
//        private Dictionary<int, string> _columnPosition = new Dictionary<int, string>();
//        private void CreateTable() 
//        {
//            AddColumn("ID", "ID", typeof(int), readOnly: true);
//            AddColumn("interval", "Проверяемый интервал, мм", typeof(int), readOnly: true);
//            AddColumn("fDegree", "Пр.° ", typeof(int));
//            AddColumn("fMinutes", "Пр.'", typeof(int));
//            AddColumn("fSeconds", "Пр.\"", typeof(decimal));
//            AddColumn("rDegree", "Обр.° ", typeof(int));
//            AddColumn("rMinutes", "Обр.'", typeof(int));
//            AddColumn("rSeconds", "Обр.\"", typeof(decimal));
//            AddColumn("mean", "Среднее значение", typeof(string), readOnly: true);
//            AddColumn("bi", "βi, угл. с", typeof(string), readOnly: true);
//            AddColumn("hi", "hi, мкм", typeof(string), readOnly: true);
//            AddColumn("Ai", "Ai, мкм", typeof(string), readOnly: true);
//            AddColumn("Bi", "Bi, мкм", typeof(string), readOnly: true);
//            AddColumn("Hi", "Hi, мкм", typeof(string), readOnly: true);
//            AddRow(0, 0, 0, 0, 0, 0);
//        }

//        //public GetTable(string tableName)
//        //{
//        //    var table = new MeasurementTable(tableName);
//        //    

//        //    return table;
//        //}

//        public class Column
//        {
//            public string DisplayName { get; private set; } // Имя для отображения
//            public string Name { get; private set; } // Имя для обращения
//            public Type DataType { get; private set; }

//            public Column(string name, string displayName, Type dataType)
//            {
//                Name = name;
//                DisplayName = displayName;
//                DataType = dataType;
//            }
//        }

//        public void AddColumn(string name, string displayName, Type dataType, bool readOnly = false)
//        {
//            if (!readOnly)
//            {
//                _columnPosition.Add(_columns.Count, name);
//            }
//            _columns.Add(new Column(name, displayName, dataType));
//            _dataTable.Columns.Add(displayName, dataType); // Используем DisplayName в DataTable
//            _dataTable.Columns[displayName].ReadOnly = readOnly;


//        }

//        public class Row
//        {
//            private Dictionary<string, object> _values = new Dictionary<string, object>();

//            public Row(Dictionary<string, object> values)
//            {
//                _values = values;
//            }

//            public object this[string columnName]
//            {
//                get => _values[columnName];
//                set => _values[columnName] = value;
//            }
//        }

//        public void AddRow(params object[] values)
//        {

//            if (values.Length != _columnPosition.Count)
//                throw new ArgumentException("Количество значений не совпадает с количеством колонок.");

//            Dictionary<string, object> rowValues = new Dictionary<string, object>();
//            object[] dataTableRow = new object[values.Length+1];
//            dataTableRow[0] = _rows.Count;
//            for (int i = 1; i < values.Length; i++)
//            {
//                if (values[i].GetType() != _columns[i].DataType)
//                {
//                    if (_columns[i].DataType == typeof(decimal) && values[i] is int intValue)
//                    {
//                        dataTableRow[i] = Convert.ToDecimal(intValue);
//                    }
//                    else if (_columns[i].DataType == typeof(string))
//                    {
//                        dataTableRow[i] = values[i].ToString();
//                    }
//                    else
//                    {
//                        throw new ArgumentException($"Тип данных в колонке {_columns[i].Name} должен быть {_columns[i].DataType.Name}");    
//                    }

//                }
//                rowValues[_columns[i].Name] = values[i];
//                dataTableRow[i] = values[i];
//            }

//            _rows.Add(new Row(rowValues));
//            var newRow = _dataTable.Rows.Add(dataTableRow); // Добавляем строку в DataTable

//        }

//        public IEnumerable<object> this[string columnName] => _rows.Select(row => row[columnName]);
//    }
//}


namespace PryamolineynostWF.Models.Collimator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;

    public class MeasurementTable
    {
        public const int IntPlaceholder = int.MinValue;
        public const decimal DecimalPlaceholder = decimal.MinValue;

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
            CreateTable();
        }

        private Dictionary<int, string> _editableColumns = new Dictionary<int, string>();

        private void CreateTable()
        {
            AddColumn("ID", "ID", typeof(int), readOnly: true);
            AddColumn("interval", "Проверяемый интервал, мм", typeof(int), readOnly: true);
            AddColumn("fDegree", "Пр.° ", typeof(int));
            AddColumn("fMinutes", "Пр.'", typeof(int));
            AddColumn("fSeconds", "Пр.\"", typeof(int));
            AddColumn("rDegree", "Обр.° ", typeof(int));
            AddColumn("rMinutes", "Обр.'", typeof(int));
            AddColumn("rSeconds", "Обр.\"", typeof(int));
            AddColumn("mean", "Среднее значение", typeof(string), readOnly: true);
            AddColumn("bi", "βi, угл. с", typeof(string), readOnly: true);
            AddColumn("hi", "hi, мкм", typeof(string), readOnly: true);
            AddColumn("Ai", "Ai, мкм", typeof(string), readOnly: true);
            AddColumn("Bi", "Bi, мкм", typeof(string), readOnly: true);
            AddColumn("Hi", "Hi, мкм", typeof(string), readOnly: true);
            AddRow(0, 0, 0, 0, 0, 0);
            AddRow();
        }

        public class Column
        {
            public string DisplayName { get; private set; }
            public string Name { get; private set; }
            public Type DataType { get; private set; }
            public bool IsReadOnly { get; private set; }

            public Column(string name, string displayName, Type dataType, bool readOnly = false)
            {
                Name = name;
                DisplayName = displayName;
                DataType = dataType;
                IsReadOnly = readOnly;
            }
        }

        public void AddColumn(string name, string displayName, Type dataType, bool readOnly = false)
        {
            if (!readOnly)
            {
                _editableColumns.Add(_columns.Count, name);
            }
            var newColumn = new Column(name, displayName, dataType, readOnly);
            _columns.Add(newColumn);
            _dataTable.Columns.Add(displayName, dataType);
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
                get => _values[columnName];
                set => _values[columnName] = value;
            }

            public bool ContainsPlaceholder()
            {
                return _values.Values.Any(value =>
                    (value is int intValue && intValue == IntPlaceholder) ||
                    (value is decimal decValue && decValue == DecimalPlaceholder));
            }
        }



        public void AddRow()
        {
            //AddRow(IntPlaceholder, IntPlaceholder, DecimalPlaceholder, IntPlaceholder, IntPlaceholder, DecimalPlaceholder);
            AddRow(IntPlaceholder, IntPlaceholder, IntPlaceholder, IntPlaceholder, IntPlaceholder, IntPlaceholder);
        }

        public void AddRow(params object[] values)
        {
            var editableColumns = _columns.Where(c => !c.IsReadOnly).ToList();

            if (values.Length != editableColumns.Count)
                throw new ArgumentException("Количество значений не совпадает с количеством редактируемых колонок.");

            Dictionary<string, object> rowValues = new Dictionary<string, object>();
            object[] dataTableRow = new object[_columns.Count]; // Полный массив под все столбцы
            dataTableRow[0] = _rows.Count; // ID строки

            int valueIndex = 0;
            for (int i = 0; i < _columns.Count; i++)
            {
                var column = _columns[i];
                if (column.IsReadOnly) continue; // Пропускаем ReadOnly столбцы

                rowValues[column.Name] = values[valueIndex];
                dataTableRow[i] = values[valueIndex];
                valueIndex++;
            }

            var newRow = new Row(rowValues);
            _rows.Add(newRow);

            if (_dataTable.Rows.Count < _rows.Count)
            {
                _dataTable.Rows.Add(dataTableRow);
            }
        }


        public void UpdateRow(int rowIndex, int columnIndex, object newValue)
        {
            if (rowIndex == 0)
            {
                _dataTable.Rows[0][columnIndex] = 0;
            }
            else if (newValue == DBNull.Value)
            {
                _dataTable.Rows[rowIndex][columnIndex] = IntPlaceholder;
            }
            else if (newValue is Int32)
            {
               
            }

            var state = true;
            foreach (var colimnIndex in _editableColumns.Keys)
            {
                if ((Int32)_dataTable.Rows[rowIndex][columnIndex] != IntPlaceholder)
                {
                    state = false;
                    break;
                }
            }

            if (state && _dataTable.Rows.Count > rowIndex + 1)
            {
                _dataTable.Rows.RemoveAt(rowIndex);
            }
            else if (!state && _dataTable.Rows.Count == rowIndex + 1)
            {
                AddRow();
            }
        }

        private void RecalculateReadOnlyFields(int rowIndex)
        {
            var row = _rows[rowIndex];
            if (row.ContainsPlaceholder()) return;

            // TODO Здесь должны быть формулы расчёта, пока просто заглушка
            _rows[rowIndex]["mean"] = "calc_mean";
            _rows[rowIndex]["bi"] = "calc_bi";
            _rows[rowIndex]["hi"] = "calc_hi";
            _rows[rowIndex]["Ai"] = "calc_Ai";
            _rows[rowIndex]["Bi"] = "calc_Bi";
            _rows[rowIndex]["Hi"] = "calc_Hi";

            _dataTable.Rows[rowIndex]["Среднее значение"] = "calc_mean";
            _dataTable.Rows[rowIndex]["βi, угл. с"] = "calc_bi";
            _dataTable.Rows[rowIndex]["hi, мкм"] = "calc_hi";
            _dataTable.Rows[rowIndex]["Ai, мкм"] = "calc_Ai";
            _dataTable.Rows[rowIndex]["Bi, мкм"] = "calc_Bi";
            _dataTable.Rows[rowIndex]["Hi, мкм"] = "calc_Hi";
        }

        public IEnumerable<object> this[string columnName] => _rows.Select(row => row[columnName]);
    }
}
