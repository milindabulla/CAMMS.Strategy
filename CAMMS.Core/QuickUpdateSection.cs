using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Domain
{
    public class QuickUpdateSection
    {
        [Column("QuickUpdateSectionID")]
        public Guid QuickUpdateSectionID { get; set; }

        [Column("SectionName")]
        public string SectionName { get; set; }

        [Column("UniqueName")]
        public string UniqueName { get; set; }

        [Column("Sort")]
        public int Sort { get; set; }

        [Column("LastChange")]
        public DateTime? LastChange { get; set; }

        [Column("ModifiedBy")]
        public Guid? ModifiedBy { get; set; }

        [Column("ParentID")]
        public Guid? m_ParentID { get; set; }

        [Column("DisplayName")]
        public string DisplayName { get; set; }
    }
}
