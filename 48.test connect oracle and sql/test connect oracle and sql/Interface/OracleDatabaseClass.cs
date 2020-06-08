using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_connect_oracle_and_sql.Dto;
using test_connect_oracle_and_sql.OracleDatabase;

namespace test_connect_oracle_and_sql.Interface
{
    public class OracleDatabaseClass<T> : IDatabase<T> where T : class
    {
        Model1 db = new Model1();
        public int Select5()
        {
            var results = db.Database.SqlQuery<int>("SELECT 5 from dual").ToArray();
            return results.FirstOrDefault();
        }

        public List<T> SelectFromActaTeck()
        {
            //List<ACTATEK_LOGS> list = db.ACTATEK_LOGS.ToList();

            //AutoMapper.Mapper.CreateMap<ACTATEK_LOGS, ActateckLogsOracleDto>();
            //var results = AutoMapper.Mapper.Map<IEnumerable<ACTATEK_LOGS>, IEnumerable<ActateckLogsOracleDto>>(list).ToList();

            //return results;
            List<T> list = db.Set<T>().ToList();

            //AutoMapper.Mapper.CreateMap<ACTATEK_LOGS, ACTATEK_LOGS_Dto>();
            //var results = AutoMapper.Mapper.Map<IEnumerable<ACTATEK_LOGS>, IEnumerable<ACTATEK_LOGS_Dto>>(list).ToList();

            return list;
        }
        
    }
}
