using NLog;

namespace ADSynchronizer
{
    internal class SyncUtil
    {
        private static readonly Logger Logger = LogManager.GetLogger("ErrorLog");
        private static readonly Logger AuditLogger = LogManager.GetLogger("AuditLog");

        public static string DBConnectionString(SyncSettings settings, IEncryptionService encryptionService)
        {
            return string.Format(DataAccess.DBConnectionStringFormat,
                                settings.Destination.Server,
                                settings.Destination.DBName,
                                settings.Destination.UserName,
                                encryptionService.Decrypt(settings.Destination.EncryptedPassword));
        }

        public static string ValidateSettings(SyncSettings settings)
        {
            var result = ValidateSetup(settings);

            if (string.IsNullOrWhiteSpace(result))
            {
                result = ValidateMappings(settings);
            }

            return result;
        }

        public static string ValidateSetup(SyncSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Source?.ConnectionString))
            {
                return "Verify source details";
            }

            if (string.IsNullOrWhiteSpace(settings.Destination?.Server))
            {
                return "Verify destination server";
            }

            if (string.IsNullOrWhiteSpace(settings.Destination?.DBName))
            {
                return "Verify destination database name";
            }

            if (string.IsNullOrWhiteSpace(settings.Destination?.UserName))
            {
                return "Verify destination database user name";
            }

            return string.Empty;
        }

        public static string ValidateMappings(SyncSettings settings)
        {
            if (!settings.Mappings.Any())
            {
                return "Verify mappings";
            }

            if (!settings.Mappings.Any(m => m.DestinationField == DataAccess.PrimaryKey))
            {
                return $"Mapping for {DataAccess.PrimaryKey} is mandatory";
            }

            return string.Empty;
        }

        public static void SyncDB(string dbConnectionString, DataAccess.DBType dbType, KeyValuePair<string, Dictionary<string, string>> studentADData, Action<string> reportProgress)
        {
            try
            {
                var dataAccess = new DataAccess(dbType, dbConnectionString);

                if (studentADData.Value.ContainsKey(nameof(ImportableStudent.Department_Id)))
                {
                    var departmentName = studentADData.Value[nameof(ImportableStudent.Department_Id)];
                    var departmentId = dataAccess.GetDepartmentId(departmentName);

                    if (departmentId <= 0)
                    {
                        reportProgress($"Department {departmentName} not found, adding it");
                        departmentId = dataAccess.AddDepartment(departmentName);
                    }

                    AuditLogger.Debug($"Set {departmentId} as departmentId for user:{studentADData.Key}");
                    studentADData.Value[nameof(ImportableStudent.Department_Id)] = departmentId.ToString();
                }

                if (dataAccess.StudentExist(studentADData.Key))
                {
                    reportProgress($"Updating user {studentADData.Key} with {studentADData.Value.Values?.Count ?? 0} properties to DB");
                    dataAccess.Update(studentADData.Key, studentADData.Value);
                }
                else
                {
                    reportProgress($"Inserting user {studentADData.Key} with {studentADData.Value.Values?.Count ?? 0} properties to DB");
                    dataAccess.Add(studentADData.Value);
                }
            }
            catch (Exception ex)
            {
                reportProgress($"Exception sync DB user:{studentADData.Key}, will continue to next user");
                Logger.Error(ex, $"Exception sync DB user:{studentADData.Key}");
            }
        }

    }
}
