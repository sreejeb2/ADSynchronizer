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
        public string SourceConnectionString { get; set; }
        public string DestinationConnectionString { get; set; }

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

    public class Mapping
    {
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}
