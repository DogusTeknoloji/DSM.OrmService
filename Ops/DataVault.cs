using Dapper;
using DSM.Core.Models;
using DSM.Core.Ops;
using DSM.OrmService.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DSM.OrmService.Ops
{
    public class DataVault
    {
        private readonly string _baseConnectionString = null;
        public DataVault(string dbConnectionString)
        {
            _baseConnectionString = dbConnectionString;
        }

        private bool ValidateProcedure<T>(string spName, T item)
        {
            if (string.IsNullOrWhiteSpace(spName) || item.Equals(default(T)))
            {
                return false;
            }

            IEnumerable<StoredProcedureParameter> SpParameters;

            using (SqlConnection conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProcedureName", spName);
                SpParameters = conn.Query<StoredProcedureParameter>("GetProcedureParameters", parameters, commandType: CommandType.StoredProcedure);
            }

            IEnumerable<StoredProcedureParameter> itemProperties = item
                .GetType()            // Get Type Instance
                .GetProperties()
                .Where(p => !p.GetCustomAttributes(true) // Get Properties of Type
                             .Any(a => a.GetType() == typeof(ExcludeFromDataModelAttribute)    // Exclude reserved attributes from sp. 
                                    || a.GetType() == typeof(DatabaseGeneratedAttribute)))
                .Select(p =>          // Transform PropertyInfo type to StoredProcedureParameter Type
                    new StoredProcedureParameter
                    {
                        ParamName = p.Name,
                        TypeName = p.PropertyType.Name.ToLower(new System.Globalization.CultureInfo("en-US")),
                        //MaxLength = p.GetValue(obj: xType)?.ToString()?.Length,
                        //Nullable = false
                    }); // Get Enumerable Collection of Items...

            IEnumerable<StoredProcedureParameter> results = SpParameters.Except(itemProperties, new SpParameterComparer());  // Except two colections  A x B
            return results.Count() < 1; //  if new result variable contains all values of sp parameter, it means all parameters defined correctly.
        }

        internal SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(_baseConnectionString);
            connection.Open();
            return connection;
        }

        public IEnumerable<T> GetList<T>(string spName)
        {
            using (SqlConnection conn = GetOpenConnection())
            {
                IEnumerable<T> items = conn.Query<T>(spName, commandType: CommandType.StoredProcedure);
                return items;
            }
        }


        public T Get<T>(string spName)
        {
            using (SqlConnection conn = GetOpenConnection())
            {
                bool isEnumerable = typeof(IEnumerable).IsAssignableFrom(typeof(T));

                if (isEnumerable)
                {
                    return default(T);
                }

                T items = conn.Query<T>(spName, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return items;
            }
        }

        public IEnumerable<T> GetList<T>(string spName, object values)
        {
            using (SqlConnection conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddDynamicParams(values);
                IEnumerable<T> items = conn.Query<T>(spName, parameters, commandType: CommandType.StoredProcedure);
                return items;
            }
        }

        public T Get<T>(string spName, object values)
        {
            using (SqlConnection conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddDynamicParams(values);
                T items = conn.Query<T>(spName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return items;
            }
        }

        public int Post<X>(string spName, object values)
        {
            using (SqlConnection conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddDynamicParams(values);
                IEnumerable<int> result = conn.Query<int>(spName, parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public int Post<X>(string spName, X obj)
        {
            using (SqlConnection conn = GetOpenConnection())
            {
                bool isValid = ValidateProcedure(spName, obj);
                if (!isValid)
                {
                    return -2;
                }

                Dictionary<string, object> pairs = obj.UseForPost();
                DynamicParameters parameters = new DynamicParameters(pairs);
                IEnumerable<int> result = conn.Query<int>(spName, parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<T> Post<T>(string spName, IEnumerable<T> objects)
        {
            using (SqlConnection conn = GetOpenConnection())
            {
                bool isValid = true;
                if (!isValid)
                {
                    return new List<T>();
                }

                IEnumerable<T> results = conn.Query<T>(spName, new
                {
                    Table = objects.ToDataTable()
                }, commandType: CommandType.StoredProcedure);

                return results;
            }
        }

        public IEnumerable<dynamic> Post(string spName, object values)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddDynamicParams(values);
                return conn.Query(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}