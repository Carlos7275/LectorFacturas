using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorFacturas.Clases
{
    internal class Utilidades
    {
        public static DataTable CombinarTablas(List<string> columnNames, params IEnumerable<object>[] dataLists)
        {
            DataTable combinedTable = new DataTable();

            // Add data to the DataTable
            foreach (var dataList in dataLists)
            {
                foreach (var dataItem in dataList)
                {
                    DataRow newRow = combinedTable.NewRow();
                    foreach (var columnName in columnNames)
                    {
                        // Split column name for nested properties
                        string[] properties = columnName.Split('.');
                        Type currentType = dataItem.GetType();

                        // Loop through nested properties
                        for (int i = 0; i < properties.Length; i++)
                        {
                            var property = currentType.GetProperty(properties[i]);
                            if (property != null)
                            {
                                if (i == properties.Length - 1)
                                {
                                    // Last property in the hierarchy
                                    // Check if the column already exists
                                    DataColumn existingColumn = combinedTable.Columns[columnName];
                                    if (existingColumn == null)
                                    {
                                        // Column doesn't exist, add it to the DataTable
                                        combinedTable.Columns.Add(columnName, property.PropertyType);
                                    }
                                    else
                                    {
                                        // Column already exists, use the existing one
                                        currentType = existingColumn.DataType;
                                    }
                                }
                                else
                                {
                                    currentType = property.PropertyType;
                                }
                            }
                            else
                            {
                                // Handle the case where a property is not found
                                // Dynamically add the missing column to the DataTable
                                if (!combinedTable.Columns.Contains(properties[i]))
                                {
                                    combinedTable.Columns.Add(properties[i], typeof(object));
                                }

                                // Break the loop to avoid further checks for nested properties
                                break;
                            }
                        }

                        // Set the value for the column
                        DataColumn column = combinedTable.Columns[columnName];
                        if (column != null)
                        {
                            object value = GetValueFromNestedProperty(dataItem, columnName);
                            newRow[columnName] = value ?? DBNull.Value;
                        }
                        // Handle the case where the column doesn't exist in the DataTable
                    }
                    combinedTable.Rows.Add(newRow);
                }
            }

            return combinedTable;
        }

        private static object GetValueFromNestedProperty(object obj, string propertyName)
        {
            string[] properties = propertyName.Split('.');
            foreach (var property in properties)
            {
                var propertyInfo = obj.GetType().GetProperty(property);
                if (propertyInfo == null)
                {
                    // Handle the case where a property is not found
                    return null;
                }
                obj = propertyInfo.GetValue(obj);
            }
            return obj;
        }

    }
}
