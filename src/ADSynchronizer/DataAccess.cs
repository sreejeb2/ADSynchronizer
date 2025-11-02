using Dapper;
using MySqlConnector;
using NLog;
using System.Data.Common;
using System.Globalization;
using Npgsql;

namespace ADSynchronizer
{
    public class DataAccess
    {
        private static readonly Logger Logger = LogManager.GetLogger("ErrorLog");
        private readonly DBType _dbType;
        private readonly string _dbConnectionString;

        public DataAccess(DBType dbType, string dbConnectionString)
        {
            _dbType = dbType;
            _dbConnectionString = dbConnectionString;
        }

        public enum DBType { MySql, PostgreSql }
        public static readonly string DBConnectionStringFormat = "Server={0};Database={1};User ID={2};Password={3}";

        public static string PrimaryKey
        {
            get
            {
                return nameof(ImportableStudent.Personal_Number);
            }
        }

        private static DbConnection OpenConnection(DBType dbType, string connectionString) =>
            dbType switch
            {
                DBType.MySql => new MySqlConnection(connectionString),
                DBType.PostgreSql => new NpgsqlConnection(connectionString),
                _ => throw new ArgumentOutOfRangeException(nameof(dbType), dbType, null)
            };

        public static bool TestConnectionToDBServer(DBType dbType, string dbConnectionString)
        {
            try
            {
                using var conn = OpenConnection(dbType, dbConnectionString);
                conn.Open(); // throws if invalid

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Could not connect to DB ");
                return false;
            }
        }

        public bool StudentExist(string id)
        {
            using var dbConnection = OpenConnection(_dbType, _dbConnectionString);
            return dbConnection.ExecuteScalar<bool>(
                "SELECT IF(EXISTS (SELECT * FROM students WHERE personal_number = @id), 1, 0)",
                new { id });
        }

        public long GetDepartmentId(string name)
        {
            using var dbConnection = OpenConnection(_dbType, _dbConnectionString);
            return dbConnection.ExecuteScalar<long>(
                "SELECT id FROM departments WHERE name = @name",
                new { name });
        }

        public long AddDepartment(string name)
        {
            var code = string.Concat(name.Where(c => char.IsUpper(c)));
            string insertQuery = @"
                Insert into departments
                  (name, code, created_at)
                values 
                  (@name, @code, @created);
                select LAST_INSERT_ID();";

            using var dbConnection = OpenConnection(_dbType, _dbConnectionString);
            return dbConnection.ExecuteScalar<long>(insertQuery, new { name, code, created = DateTime.Now });
        }

        public void Add(Dictionary<string, string> syncProps)
        {
            var parameters = new DynamicParameters();
            var columns = new List<string>();
            var columnValues = new List<string>();

            foreach (var prop in syncProps)
            {
                columns.Add(prop.Key);
                parameters.Add(prop.Key, prop.Value);
                columnValues.Add($"@{prop.Key}");
            }

            // add properties with default values
            var columnName = "status";
            columns.Add(columnName);
            parameters.Add(columnName, 1);
            columnValues.Add($"@{columnName}");
            columnName = "ad_sync_time";
            columns.Add(columnName);
            parameters.Add(columnName, DateTime.Now);
            columnValues.Add($"@{columnName}");

            var query = "INSERT INTO students ({0}) VALUES ({1})";
            var insertQuery = string.Format(CultureInfo.CurrentCulture, query, string.Join(',', columns), string.Join(',', columnValues));

            using var dbConnection = OpenConnection(_dbType, _dbConnectionString);
            dbConnection.Execute(insertQuery, parameters);
        }

        public void Update(string id, Dictionary<string, string> syncProps)
        {
            var parameters = new DynamicParameters();
            var updateList = new List<string>();

            parameters.Add("personal_number", id);
            foreach (var prop in syncProps)
            {
                parameters.Add(prop.Key, prop.Value);
                updateList.Add($"{prop.Key} = @{prop.Key}");
            }

            // add properties with default values
            var columnName = "status";
            parameters.Add(columnName, 1);
            updateList.Add($"{columnName} = @{columnName}");
            columnName = "ad_sync_time";
            parameters.Add(columnName, DateTime.Now);
            updateList.Add($"{columnName} = @{columnName}");

            var query = "UPDATE students SET {0} where personal_number = @personal_number";
            var updateQuery = string.Format(CultureInfo.CurrentCulture, query, string.Join(',', updateList));

            using var dbConnection = OpenConnection(_dbType, _dbConnectionString);
            dbConnection.Execute(updateQuery, parameters);
        }

        public void DeactivateUsers(IList<string> users)
        {
            var parameters = new DynamicParameters();
            
            // add properties with default values
            parameters.Add("ad_sync_time", DateTime.Now);

            var query = "UPDATE students SET status=0, ad_sync_time=@ad_sync_time where personal_number not in ('{0}')";
            var updateQuery = string.Format(CultureInfo.CurrentCulture, query, string.Join("','", users.Select(u => u.Replace("'", "''"))));

            using var dbConnection = OpenConnection(_dbType, _dbConnectionString);
            dbConnection.Execute(updateQuery, parameters);
        }
    }
}
