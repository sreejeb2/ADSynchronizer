using NLog;

namespace ADSynchronizer
{
    internal class Scheduler
    {
        private static readonly Logger Logger = LogManager.GetLogger("ErrorLog");
        private static readonly Logger AuditLogger = LogManager.GetLogger("AuditLog");

        public void Start(FileInfo settingsFile, IEncryptionService encryptionService)
        {
            try
            {
                AuditLogger.Info($"Scheduler: Started scheduled run using {settingsFile.FullName}");
                var settings = SyncSettings.Deserialize(File.ReadAllText(settingsFile.FullName));
                var adUserName = string.IsNullOrEmpty(settings.Source.UserName) ? null : settings.Source.UserName;
                var adUserPassword = string.IsNullOrEmpty(settings.Source.EncryptedPassword) ? null : encryptionService.Decrypt(settings.Source.EncryptedPassword);
                using var ad = new ActiveDirectoryUtility(settings.Source.ConnectionString, adUserName, adUserPassword);

                AuditLogger.Info("Scheduler: Started reading AD data");
                var result = ad.GetAllUsers(settings.Mappings);
                AuditLogger.Info($"Scheduler: Completed reading AD data, got {result?.Values.Count ?? 0} users");

                if (result?.Count() > 0)
                {
                    AuditLogger.Info($"Scheduler: Started sync to DB");
                    var dbConnectionString = SyncUtil.DBConnectionString(settings, encryptionService);

                    foreach (var studentADData in result.Select((user, i) => new { i, user }))
                    {
                        SyncUtil.SyncDB(dbConnectionString, studentADData.user, (m) => AuditLogger.Info(m));
                    }

                    AuditLogger.Info($"Scheduler: Completed sync to DB");

                    AuditLogger.Info($"Scheduler: Started deactivating users");
                    var dataAccess = new DataAccess(dbConnectionString);
                    dataAccess.DeactivateUsers(result.Keys.ToList());
                    AuditLogger.Info($"Completed deactivating users");
                }
                else
                {
                    AuditLogger.Info($"Scheduler: No users found to sync to DB");
                }

                AuditLogger.Error("Scheduler: Scheduled run completed successfully for ADSync");
            }
            catch (Exception ex)
            {
                AuditLogger.Error("Scheduler: Scheduled run failed with exception for ADSync");
                Logger.Error(ex, "Scheduler: Exception sync AD");
                throw;
            }            
        }
    }
}
