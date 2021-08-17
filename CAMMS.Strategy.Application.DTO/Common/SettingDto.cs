using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.DTO.Common
{
    public class SettingDto
    {
        public Guid SettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsInternal { get; set; }
    }
}
