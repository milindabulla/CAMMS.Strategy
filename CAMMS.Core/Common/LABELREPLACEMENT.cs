using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAMMS.Domain
{
    public class LABELREPLACEMENT
    {
        [Column("ORIGINALTEXT")]
        public string ORIGINALTEXT { get; set; }

        [Column("REPLACEMENTTEXT")]
        public string REPLACEMENTTEXT { get; set; }

        [Column("LABELREPLACEMENTID")]
        public Guid LABELREPLACEMENTID { get; set; }
    }
}
