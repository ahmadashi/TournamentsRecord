using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TR.Infrastructure.Interfaces.Repositories;
using TR.DAL.DataAccess;
using TR.DAL.Exception;

namespace TR.DAL.Repositories
{
    public abstract class ReadOnlyRepositoryBase<TViewModel> : IReadOnlyRespository<TViewModel> where TViewModel : class
    {
        private readonly IRepositoryExceptionHandler _repositoryExceptionHandler;

        protected readonly TRContext Db;

        [Obsolete]
        public abstract Expression<Func<TRContext, DbQuery<TViewModel>>> DataSet();
        //Ashi Try this
        //public abstract Expression<Func<TRContext, DbSet<TViewModel>>> DataSet();

        protected ReadOnlyRepositoryBase(
            TRContext db,
            IRepositoryExceptionHandler repositoryExceptionHandler
            )
        {
            _repositoryExceptionHandler = repositoryExceptionHandler;

            Db = db;
        }

        public async Task<IList<TViewModel>> ExecuteCommandAsync(string command, IList<SqlParameter> sqlParams)
        {
            // Ashi I need to change below code : not supported anymore
            //return null;
            var cmd = $"{command} {string.Join(", ", sqlParams.Select(p => p.ParameterName))}";

            using (var db = Db)
            {
                //return await db.Query<TViewModel>()
                //    .AsNoTracking()
                //    .FromSql(cmd, sqlParams.ToArray())
                //    .ToListAsync();

                return await db.Set<TViewModel>()// .Query<TViewModel>()
                    .FromSqlRaw(command, sqlParams.ToArray())
                    .ToListAsync();
            }
        }

        public async Task<TType> ExecuteScalarCommandAsync<TType>(string command, IList<SqlParameter> sqlParams = null)
        {
            string cmdText = string.Empty;

            if (sqlParams != null)
            {
                cmdText = $"{command} {string.Join(", ", sqlParams.Select(p => p.ParameterName))}";
            }
            else
            {
                cmdText = command;
            }

            try
            {
                using (var db = Db)
                {
                    var conn = db.Database.GetDbConnection();

                    if (conn.State != ConnectionState.Open)
                        await conn.OpenAsync();

                    DbCommand cmd = db.Database.GetDbConnection().CreateCommand();

                    cmd.CommandText = cmdText;

                    if (sqlParams != null)
                        cmd.Parameters.AddRange(sqlParams.ToArray());

                    return (TType) await cmd.ExecuteScalarAsync();

                }
            }
            catch (System.Exception e)
            {
                throw _repositoryExceptionHandler.Handle(e); ;
            }
            finally
            {
                using (var db = Db)
                {
                    var conn = db.Database.GetDbConnection();

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        public async Task ExecuteNonQueryAsync(string command, IList<SqlParameter> sqlParams)
        {
            var cmdText = $"{command} {string.Join(", ", sqlParams.Select(p => p.ParameterName))}";

            using (var db = Db)
            {
                var conn = db.Database.GetDbConnection();

                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                var cmd = conn.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(sqlParams.ToArray());

                await cmd.ExecuteNonQueryAsync();

                conn.Close();
            }
        }

        public async Task ExecuteNonQueryAsync(string command)
        {
            using (var db = Db)
            {
                var conn = db.Database.GetDbConnection();

                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                var cmd = conn.CreateCommand();
                cmd.CommandText = command;
                //cmd.Parameters.AddRange(sqlParams.ToArray());

                await cmd.ExecuteNonQueryAsync();

                conn.Close();
            }
        }

        public async Task<IList<TViewModel>> ExecuteCommandAsync(string command)
        {
            // Ashi I need to change below code : not supported anymore
            //return null;
            using (var db = Db)
            {
                return await db.Set<TViewModel>()//Query<TViewModel>()
                    .FromSqlRaw(command)
                    .ToListAsync();
            }
        }
    }
}
