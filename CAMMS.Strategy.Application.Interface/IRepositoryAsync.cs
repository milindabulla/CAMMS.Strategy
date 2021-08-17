using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CAMMS.Strategy.Application.Interface
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(int id);

        Task<T> GetByGuidAsync(Guid id);

        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAllQueryable();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        Task<int> ExecuteNonQueryAsync(string sqlCommand, object[] parameterList);
        Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[] parameterList);
        Task<Guid> ExecuteScalarAsync(string procedureName, SqlParameter[] parameterList);
        Task<List<T>> ExecuteReaderAsync<T>(string sqlCommand, object[] parameterList) where T : class;
        Task<List<T>> ExecuteReaderAsync<T>(string procedureName, SqlParameter[] parameterList);
        Task<List<T>> ExecuteReaderAsync<T>(string procedureName);
    }
}
