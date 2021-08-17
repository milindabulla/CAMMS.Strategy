using System;


namespace CAMMS.Strategy.Application.DTO
{
    public class UserQuickUpdateSectionDto
    {   
        public Guid UserQuickUpdateSectionID { get; set; }
        public Guid QuickUpdateSectionID { get; set; }
        public Guid UserID { get; set; }
        public Guid ApplicationID { get; set; }
        public bool IsVisible { get; set; }
        public bool Collapsed { get; set; }
        public bool IsDefault { get; set; }
        public int Sort { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
