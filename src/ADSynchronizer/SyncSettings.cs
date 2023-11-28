using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
                        
            return JsonSerializer.Deserialize<SyncSettings>(syncSettings);
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
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
