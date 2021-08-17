using System;


namespace CAMMS.Strategy.Application.DTO
{
    public class QuickUpdateSectionDto
    {
  
        internal Guid QuickUpdateSectionID { get; set; } 
        internal string SectionName { get; set; }
        internal string UniqueName { get; set; }
        internal int Sort { get; set; }
        internal DateTime? LastChange { get; set; }    
        internal Guid? ModifiedBy { get; set; }
        internal Guid? ParentID { get; set; }
        internal string DisplayName { get; set; }
    }
}
