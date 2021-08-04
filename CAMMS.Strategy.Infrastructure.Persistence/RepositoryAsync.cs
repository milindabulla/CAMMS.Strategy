using CAMMS.Strategy.Application.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Persistence
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly DatabaseContext Context;

        public RepositoryAsync(DatabaseContext databaseContext)
        {
            Context = databaseContext;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }

            Context.Set<T>().Remove(entity);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByGuidAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return await Context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return Context.Set<T>();
        }

        public async Task<int> ExecuteNonQueryAsync(string sqlCommand, object[] parameterList)
        {
            return await Context.Database.ExecuteSqlRawAsync(sqlCommand, parameterList);
        }

        public async Task<List<T>> ExecuteReaderAsync<T>(string sqlCommand, object[] parameterList) where T : class
        {
            return await Context.Set<T>().FromSqlRaw(sqlCommand, parameterList).ToListAsync<T>();
        }

        public async Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[] parameterList)
        {
            DbCommand commend = Context.Database.GetDbConnection().CreateCommand();
            commend.CommandText = procedureName;
            commend.CommandType = CommandType.StoredProcedure;

            if (commend.Connection.State != ConnectionState.Open)
            {
                commend.Connection.Open();
            }

            return await commend.ExecuteNonQueryAsync();
        }

        public async Task<List<T>> ExecuteReaderAsync<T>(string procedureName, SqlParameter[] parameterList)
        {
            using (DbCommand commend = Context.Database.GetDbConnection().CreateCommand())
            {
                commend.CommandText = procedureName;
                commend.CommandType = CommandType.StoredProcedure;
                commend.Parameters.AddRange(parameterList);

                Context.Database.OpenConnection();
                using (var reader = await commend.ExecuteReaderAsync())
                {
                    return ConvertToObjectList<T>(reader);
                }
            }
        }

        private List<T> ConvertToObjectList<T>(DbDataReader reader)
        {
            var result = new List<T>();
            var props = typeof(T).GetRuntimeProperties();

            var colMapping = reader.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        if (colMapping.ContainsKey(prop.Name.ToLower()) && colMapping[prop.Name.ToLower()].ColumnOrdinal != null)
                        {
                            var val = reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                            prop.SetValue(obj, val == DBNull.Value ? null : val);
                        }
                    }
                    result.Add(obj);
                }
            }
            return result;
        }
    }
}
