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
            var properties = (typeof(TEntity)).GetProperties()
                                                .Where(x => x.GetCustomAttributes(typeof(DtaNamesAttribute), true).Any())
                                                .ToList();
            
            IList<TEntity> entities = new List<TEntity>();
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
