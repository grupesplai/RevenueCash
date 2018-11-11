using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.ServicesLibrary
{
    public static class GeneradorDataSet
    {
        public static DataSet Priests()
        {
            DataTable priestsDataTable = new DataTable();
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "first_name",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "last_name",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "dob",
                DataType = typeof(DateTime)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "job_title",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "taken_name",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "is_american",
                DataType = typeof(string)
            });

            priestsDataTable.Rows.Add(new object[] { "Lenny", "Belardo", new DateTime(1971, 3, 24), "Pontiff","1", "yes" });
            priestsDataTable.Rows.Add(new object[] { "Angelo", "Voiello", new DateTime(1952, 11, 18), "Cardinal Secretary of State", "2", "no" });
            priestsDataTable.Rows.Add(new object[] { "Michael", "Spencer", new DateTime(1942, 5, 12), "Archbishop of New York", "3", "yes" });
            priestsDataTable.Rows.Add(new object[] { "Sofia", "(Unknown)", new DateTime(1974, 7, 2), "Director of Marketing", "4", "no" });
            priestsDataTable.Rows.Add(new object[] { "Bernardo", "Gutierrez", new DateTime(1966, 9, 16), "Master of Ceremonies", "5", "no" });

            DataSet priestsDataSet = new DataSet();
            priestsDataSet.Tables.Add(priestsDataTable);

            return priestsDataSet;
        }
    }
}
