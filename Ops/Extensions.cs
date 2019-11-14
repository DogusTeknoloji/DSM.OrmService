using DSM.Core.Models;
using FastMember;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;

namespace DSM.OrmService.Ops
{
    public static class Extensions
    {
        private static string[] GetFilteredFields<T>()
        {
            Type icType = typeof(T);

            IEnumerable<string> fields = icType       // Get Type Instance
                  .GetProperties()
                  .Where(p => !p.GetCustomAttributes(true) // Get Properties of Type
                         .Any(a => a.GetType() == typeof(ExcludeFromDataModelAttribute)    // Exclude reserved attributes from sp. 
                                || a.GetType() == typeof(DatabaseGeneratedAttribute)))
                  .Select(x => x.Name);

            return fields.ToArray();
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            DataTable table = new DataTable();
            string[] filteredFields = GetFilteredFields<T>();
            using (ObjectReader reader = ObjectReader.Create(data, filteredFields))
            {
                table.Load(reader);
            }

            return table;
        }
    }
}
