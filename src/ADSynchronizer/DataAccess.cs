using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSynchronizer
{
    public class DataAccess
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly string _dbConnectionString;

        public DataAccess(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public static bool TestConnectionToDBServer(string dbConnectionString)
        {
            try
            {
                using (var conn = new SqlConnection(dbConnectionString))
                {
                    conn.Open(); // throws if invalid
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Could not connect to DB ", ex);
                return false;
            }
        }
    }
}
