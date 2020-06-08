using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_connect_oracle_and_sql.Dto;

namespace test_connect_oracle_and_sql.Interface
{
    public interface IDatabase <T>
    {
        int Select5();
        List<T> SelectFromActaTeck();
    }
}
