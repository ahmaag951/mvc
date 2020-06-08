using System;
using test_connect_oracle_and_sql.Dto;
using test_connect_oracle_and_sql.Interface;
using test_connect_oracle_and_sql.SqlDatabase;

namespace test_connect_oracle_and_sql
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDatabase<ACTATEK_LOGS_Dto> database = new SqlDatabaseClass<ACTATEK_LOGS_Dto>();
            IDatabase<ACTATEK_LOGS> database = new SqlDatabaseClass<ACTATEK_LOGS>();
            //IDatabase database = new OracleDatabaseClass();

            var result = database.SelectFromActaTeck();

            Console.Read();
        }
    }
}
