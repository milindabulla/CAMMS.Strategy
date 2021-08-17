using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Domain.Common
{
   public class Setting
    {
        public Guid SettingId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public Guid DataTypeId { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
        public bool IsInternal { get; set; }
        public DateTime LastChange { get; set; }
        public Guid ModifiedBy { get; set; }
        public string DataType { get; set; }
    }
}
 