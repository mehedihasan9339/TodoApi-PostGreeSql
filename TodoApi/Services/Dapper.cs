using System.Data.Common;
using System.Data;
using Dapper;
using Npgsql;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TodoApi.ViewModels;

namespace TodoApi.Services
{
    public class Dapper : IDapper
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";

        public Dapper(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {

        }

        public async Task<List<T>> FromSqlAsync<T>(FormattableString sqlQuery, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new NpgsqlConnection("Host=localhost;Database=todo;Username=postgres;Password=sa@123");
            var data = await db.QueryAsync<MemberTodoItemDTO>("CALL get_member_todo_items(2)", commandType: CommandType.Text);
            var result = await db.QueryAsync<T>("CALL get_member_todo_items(2)", commandType: CommandType.Text);
            return result.ToList();
        }

        public List<T> FromSql<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            var result = db.Query<T>(SqlQuery.ToString(), commandType: commandType);
            return result.ToList();
        }
        public async Task<T> FromSqlFirstOrDefaultAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QueryFirstOrDefaultAsync<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }
        public T FromSqlFirstOrDefault<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            var result = db.QueryFirstOrDefault<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }

        public async Task<T> FromSqlSingleOrDefaultAsync<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QuerySingleOrDefaultAsync<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }
        public T FromSqlSingleOrDefault<T>(FormattableString SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            var result = db.QuerySingleOrDefault<T>(SqlQuery.ToString(), commandType: commandType);
            return result;
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }



        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public DbConnection GetDbconnection()
        {
            return new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new NpgsqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
    }
}
