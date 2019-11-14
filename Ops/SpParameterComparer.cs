using DSM.OrmService.Models;
using System;
using System.Collections.Generic;

namespace DSM.OrmService.Ops
{
    internal class SpParameterComparer : IEqualityComparer<StoredProcedureParameter>
    {
        public bool Equals(StoredProcedureParameter x, StoredProcedureParameter y)
        {
            bool paramEquality = string.Equals(x.ParamName, y.ParamName, StringComparison.OrdinalIgnoreCase);
            bool typeEquality = string.Equals(x.TypeName, y.TypeName, StringComparison.OrdinalIgnoreCase);

            return paramEquality && typeEquality;
        }

        public int GetHashCode(StoredProcedureParameter obj)
        {
            return obj.ParamName.GetHashCode();
        }
    }
}
