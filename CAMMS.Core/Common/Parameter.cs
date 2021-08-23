using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Domain.Common
{
    [Keyless]
    public class Parameters
    {
        
        [Column("PARAMETERID")]
        public Guid ParameterId { get; set; }
        [Column("DATA")]
        public byte[] Data { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("LASTCHANGE")]
        public DateTime? LastChange { get; set; }
        [Column("MODIFEDBY")]
        public Guid? ModifedBy { get; set; }
    }
}

