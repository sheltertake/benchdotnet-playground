using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi3.Controllers
{
    /*
     *
    sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest
     *
     */
    public class DapperController
    {
        private readonly IDbConnection _connection;

        public DapperController(IDbConnection connection)
        {
            _connection = connection;
        }
        [HttpGet("db/sync")]
        public IEnumerable<Todo> Sync()
        {
            return _connection.Query<Todo>(@"SELECT * FROM todo");
        }
        [HttpGet("db/async")]
        public async Task<IEnumerable<Todo>> Async()
        {
            return await _connection.QueryAsync<Todo>(@"SELECT * FROM todo");
        }
        public class Todo
        {
            public int Id { get; set; }
            public string Label { get; set; }
        }
    }
}
