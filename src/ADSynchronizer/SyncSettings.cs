using System.Text.Json;
using System.Text.Json.Serialization;

namespace ADSynchronizer
{
    public class SyncSettings
    {
        public SourceADDetails Source { get; set; }
        public DestinationDBDetails Destination { get; set; }
        public List<string> ADProperties { get; set; } = new List<string>();
        public IList<Mapping> Mappings { get; set; } = new List<Mapping>();

        public static SyncSettings Deserialize(string syncSettings)
        {
            if (string.IsNullOrEmpty(syncSettings))
            {
                throw new ArgumentNullException("syncSettings");
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            return JsonSerializer.Deserialize<SyncSettings>(syncSettings, options);
        }

        public string Serialize()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            return JsonSerializer.Serialize(this, options);
        }
    }

    public class SourceADDetails
    {
        public string ConnectionString { get; set; }
        public string UserName { get; set; }
        public string EncryptedPassword { get; set; }
        public string Filter { get; set; }
    }

    public class DestinationDBDetails
    {
        public DataAccess.DBType DBType { get; set; }
        public string Server { get; set; }
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string EncryptedPassword { get; set; }
    }

    public class Mapping
    {
        public string SourceField { get; set; }
        public string DestinationField { get; set; }
    }
}
