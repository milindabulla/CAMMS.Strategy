using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAMMS.Domain
{   
        public class Permission
        {
        [Column("PERMISSIONID")]
        public Guid PERMISSIONID { get; set; }

        [Column("NAME")]
        public string NAME { get; set; }

        [Column("PARENTID")]
        public Guid? PARENTID { get; set; }

        [Column("IsArchived")]
        public bool? IsArchived { get; set; }

        [Column("DisplayName")]
        public string DisplayName { get; set; }

        [Column("SortOrder")]
        public int? SortOrder { get; set; }
    }  
}
