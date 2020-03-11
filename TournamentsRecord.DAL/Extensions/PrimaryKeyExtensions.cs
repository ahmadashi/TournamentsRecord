using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vprc.Domain.Sql.Extensions
{
    public static class PrimaryKeyExtensions
    {
        public static Expression<Func<T, object>> GetPropertySelector<T>(this string propertyName)
        {
            var arg = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(arg, propertyName);
            //return the property as object
            var conv = Expression.Convert(property, typeof(object));
            var exp = Expression.Lambda<Func<T, object>>(conv, new ParameterExpression[] { arg });
            return exp;
        }

        public static IEnumerable<string> FindPrimaryKeyNames<T>(this DbContext dbContext, T entity)
        {
            return from p in dbContext.FindPrimaryKeyProperties<T>(entity)
                select p.Name;
        }

        public static IEnumerable<object> FindPrimaryKeyValues<T>(this DbContext dbContext, T entity)
        {
            return from p in dbContext.FindPrimaryKeyProperties<T>()
                select entity.GetPropertyValue(p.Name);
        }

        public static IReadOnlyList<IProperty> FindPrimaryKeyProperties<T>(this DbContext dbContext)
        {
            return dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
        }

        static IReadOnlyList<IProperty> FindPrimaryKeyProperties<T>(this DbContext dbContext, T entity)
        {
            return dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
        }

        static object GetPropertyValue<T>(this T entity, string name)
        {
            return entity.GetType().GetProperty(name).GetValue(entity, null);
        }

    }
    
}
