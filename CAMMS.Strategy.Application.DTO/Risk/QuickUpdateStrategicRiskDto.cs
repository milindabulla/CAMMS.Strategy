using System;

namespace CAMMS.Strategy.Application.DTO
{
    public class QuickUpdateStrategicRiskDto
    {
        public Guid StrategicRiskAssessmentID { get; set; }   
        public string RiskIdNumber { get; set; }     
        public string Title { get; set; }     
        public Guid? EnvironmentalIssueId { get; set; }     
        public DateTime? NextReviewDate { get; set; }      
        public Guid? RiskRatingLogoId { get; set; }      
        public Guid? RiskRatingId { get; set; }
        public string RiskRatingTypeName { get; set; }      
        public string RiskRatingTypeColor { get; set; }      
        public Guid? ReportingPeriodId { get; set; }      
        public string ManagerComments { get; set; }
    }
}
