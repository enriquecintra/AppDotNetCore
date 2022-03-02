using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace OPPI.Data.Helpers
{
    public static class SqlQueryHelpers
    {
        public static async Task<List<T>> RawSqlQueryAsync<T>(this OppiContext context, string query, Func<DbDataReader, T> map)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }
                    return entities;
                }
            }
        }
    }
}
