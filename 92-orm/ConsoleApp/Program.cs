using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Dapper;
using Dapper.Contrib.Extensions;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace ConsoleApp
{
    [ShortRunJob]
    [MemoryDiagnoser]
    public class Benchmarks
    {
        //private IDbConnection DapperConnection;
        private IDbConnectionFactory OrmLiteConnectionFactory;

        [GlobalSetup]
        public void Setup()
        {
            var connectionString = "Server=LI-598;Database=test;User Id=sa;Password=YourStrong@Passw0rd;";
            OrmLiteConnectionFactory = new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance);
            //DapperConnection = new SqlConnection(connectionString);
            //DapperConnection.Open();
            //using (var connection = OrmLiteConnectionFactory.Open())
            //{
            //    connection.DeleteAll<Todo>();
            //    for (int i = 0; i < 1_000; i++)
            //    {
            //        connection.InsertAll<Todo>(Enumerable.Repeat<Todo>(new Todo()
            //        {
            //            Label = Guid.NewGuid().ToString()
            //        }, 1_000));
            //    }
                
            //}
        }


        [Benchmark]
        public int Dapper()
        {
            using (var connection = OrmLiteConnectionFactory.Open())
            {
                var ret = connection.Query<Todo>("select * from todo").AsList();
                return ret.Count;
            }
        }
        [Benchmark]
        public bool DapperStruct()
        {
            using (var connection = OrmLiteConnectionFactory.Open())
            {
                var ret = connection.Query<Struct>("select * from todo").AsEnumerable();
                return ret.Any();
            }
        }
        [Benchmark]
        public int DapperContrib()
        {
            using (var connection = OrmLiteConnectionFactory.Open())
            {
                var ret = connection.GetAll<Todo>().AsList();
                return ret.Count;
            }
        }
        

        [Benchmark]
        public int OrmLite()
        {
            using (var connection = OrmLiteConnectionFactory.Open())
            {
                var ret = connection.Select<Todo>().AsList();
                return ret.Count;
            }
        }
        //[Benchmark]
        //public int OrmLiteStruct()
        //{
        //    using (var connection = OrmLiteConnectionFactory.Open())
        //    {
        //        var ret = connection.Select<Struct>().AsList();
        //        return ret.Count;
        //    }
        //}
        [Table("Todo")]
        class Todo
        {
            [AutoIncrement]
            public int Id { get; set; }
            public string Label { get; set; }
        }

        struct Struct
        {
            public int Id;
            public string Label;
        }
        
    }

    class Program
    {
        static void Main() => BenchmarkRunner.Run<Benchmarks>();
    }
}
