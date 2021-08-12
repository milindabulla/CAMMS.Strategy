using System;

namespace CAMMS.Domain
{   
        public class AuditLog
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public string Type { get; set; }
            public string SubType { get; set; }
            public string TableName { get; set; }
            public int PrimaryKey { get; set; }
            public DateTime DateTime { get; set; }
            public string ObjectValues { get; set; }
            public string OldValues { get; set; }
            public string NewValues { get; set; }
            public string AffectedColumns { get; set; }
        }  
}
