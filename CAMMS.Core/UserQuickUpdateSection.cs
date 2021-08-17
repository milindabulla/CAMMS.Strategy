using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Domain
{
    public class UserQuickUpdateSection
    {
        [Column("UserQuickUpdateSectionID")]
        public Guid UserQuickUpdateSectionID { get; set; }

        [Column("QuickUpdateSectionID")]
        public Guid QuickUpdateSectionID { get; set; }

        [Column("UserID")]
        public Guid UserID { get; set; }

        [Column("ApplicationID")]
        public Guid ApplicationID { get; set; }

        [Column("IsVisible")]
        public bool IsVisible { get; set; }

        [Column("Collapsed")]
        public bool Collapsed { get; set; }

        [Column("IsDefault")]
        public bool IsDefault { get; set; }

        [Column("Sort")]
        public int Sort { get; set; }

        [Column("LastChange")]
        public DateTime? LastChange { get; set; }

        [Column("ModifiedBy")]
        public Guid? ModifiedBy { get; set; }
    }
}
