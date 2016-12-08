using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public class SqlDbConnect
    {
        public SqlConnection Conn;
        public SqlCommand Cmd;
        public DataTable Dt { get; set; }

    }
}
