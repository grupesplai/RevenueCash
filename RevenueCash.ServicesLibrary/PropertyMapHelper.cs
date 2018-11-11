using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.ServicesLibrary
{
    public class PropertyMapHelper
    {
        public static void Map(Type type, DataRow row, PropertyInfo prop, object entity)
        {
            List<string> columnNames = AttributeHelper.GetDataNames(type, prop.Name);

            foreach (var columnName in columnNames)
            {
                if (!String.IsNullOrWhiteSpace(columnName) && row.Table.Columns.Contains(columnName))
                {
                    var propertyValue = row[columnName];
                    if (propertyValue != DBNull.Value)
                    {
                        ParsePrimitive(prop, entity, row[columnName]);
                        break;
                    }
                }
            }
        }

        private static void ParsePrimitive(PropertyInfo prop, object entity, object value)
        {
            if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(entity, value.ToString().Trim());
            }
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
            {
                if (value == null)
                {
                    prop.SetValue(entity, null);
                }
                else
                {
                    prop.SetValue(entity, int.Parse(value.ToString()));
                }
            }
            else if (prop.PropertyType == typeof(bool))
            {
                prop.SetValue(entity, (value.ToString() == "yes") ? true: false);
            }
            else if (prop.PropertyType == typeof(DateTime))
            {
                prop.SetValue(entity, DateTime.Parse(value.ToString()));
            }
        }
    }
}
