using CAMMS.Domain;
using CAMMS.Strategy.Infrastructure.Persistence.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Persistence
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }
        public string UserId { get; set; }
        public string TableName { get; set; }
        public int PrimaryKey { get; set; }
        public Dictionary<string, object> ObjectValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public LogType LogType { get; set; }
        public LogSubType LogSubType { get; set; }
        public List<string> ChangedColumns { get; } = new List<string>();
        public AuditLog ToAudit()
        {
            var audit = new AuditLog();
            audit.UserId = UserId;
            audit.Type = LogType.ToString();
            audit.SubType = LogSubType.ToString();
            audit.TableName = TableName;
            audit.DateTime = DateTime.UtcNow;
            audit.PrimaryKey = PrimaryKey;
            audit.ObjectValues = ObjectValues.Count == 0 ? null : JsonConvert.SerializeObject(ObjectValues);
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);
            return audit;
        }
    }
}
