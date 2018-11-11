using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.ServicesLibrary
{
    public class DataNamesMapper<TEntity> where TEntity : class, new()
    {
        public DataNamesMapper()
        {
        }

        public IEnumerable<TEntity> Map(DataTable table)
        {
            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                                .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                                .ToList();

            //Step 3 - Map the data
            List<TEntity> entities = new List<TEntity>();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var prop in properties)
                {
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                entities.Add(entity);
            }

            return entities;
        }
    }
}
