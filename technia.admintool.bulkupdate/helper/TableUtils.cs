using System.Data;
using System.Dynamic;
using technia.admintool.settings;

namespace technia.admintool.bulkupdate
{
    public static class TableUtils
    {
        public static readonly string DataPropertyName = "DataPropertyName";
        public static DataTable GetTable(List<ExpandoObject> rows)
        {
            DataTable dataTable = new();
            GetTable(rows, ref dataTable, new(), new(), false);
            return dataTable;
        }

        public static DataTable GetTableWithExtraCols(List<ExpandoObject> rows, List<string> comments, List<string> errors)
        {
            DataTable dataTable = new();
            DataColumn commentsCol = new("Comments");
            dataTable.Columns.Add(commentsCol);
            DataColumn errorsCol = new("Errors");
            dataTable.Columns.Add(errorsCol);
            GetTable(rows, ref dataTable, comments, errors, true);
            return dataTable;
        }

        private static void GetTable(List<ExpandoObject> rows, ref DataTable dataTable, List<string> comments, List<string> errors, bool addExtraCols)
        {
            string[] headers = ExpandoObjectUtils.GetAllKeys(rows);

            foreach (string columnHeader in headers)
                AddRow(ref dataTable, columnHeader, columnHeader);

            for (var i = 0; i < rows.Count; i++)
            {
                var record = rows[i];
                var dict = ExpandoObjectUtils.GetDictionary(record);
                if (!addExtraCols) dataTable.Rows.Add(dict.Values.ToArray());
                else
                {
                    var comment = comments[i];
                    var error = errors[i];
                    // add error as 2nd column
                    var newArray = ArrayImplUtils.AddElementAtFirst(dict.Values.ToArray(), error);
                    // add comments as 1st column
                    newArray = ArrayImplUtils.AddElementAtFirst(newArray, comment);
                    dataTable.Rows.Add(newArray);
                }
            }
        }

        public static void AddRow(ref DataTable dataTable, string value, string displayValue)
        {
            DataColumn? column = new(value)
            {
                ColumnName = displayValue
            };
            column.ExtendedProperties.Add(DataPropertyName, value);
            dataTable.Columns.Add(column);
        }
    }
}