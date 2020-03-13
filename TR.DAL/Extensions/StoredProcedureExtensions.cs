using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace Vprc.Domain.Sql.Extensions
{
    public static class StoredProcedureExtensions
    {
        public static SqlParameter WithValue<T>(this SqlParameter sqlParam, T val)
        {
            if(IsOfNullableType(val))
            {
                if (val == null)
                {
                    sqlParam.IsNullable = true;
                    sqlParam.Value = DBNull.Value;
                }
                else
                {
                    sqlParam.Value = val;
                }

                return sqlParam;
            }
            sqlParam.Value = val;
            return sqlParam;
        }

        public static DynamicParameters ToDynamicParameters(this IEnumerable<SqlParameter> sqlParams)
        {
            var dynParams = new DynamicParameters();
            foreach (var p in sqlParams)
            {
                dynParams.Add(p.ParameterName, p.Value);
            }

            return dynParams;
        }

        private static bool IsOfNullableType<T>(T o)
        {
            var type = typeof(T);
            return Nullable.GetUnderlyingType(type) != null;
        }

        //public static SqlParameter WithValueNullable(this SqlParameter sqlParam, Nullable val)
        //{
        //    if (val == null)
        //    {
        //        sqlParam.IsNullable = true;
        //        sqlParam.Value = DBNull.Value;
        //        return sqlParam;
        //    }
        //    sqlParam.Value = val;
        //    return sqlParam;
        //}

    }
}
