using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAMMS.Domain
{
    public class QuickUpdateStrategicRisk
    {
        [Column("STRATEGICRISKASSESSMENTID")]
        public Guid StrategicRiskAssessmentID { get; set; }

        [Column("RISKIDNUMBER")]
        public string RiskIdNumber { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("ENVIRONMENTALISSUEID")]
        public Guid? EnvironmentalIssueId { get; set; }

        [Column("NEXTREVIEWDATE")]
        public DateTime? NextReviewDate { get; set; }

        [Column("RISKRATINGLOGOID")]
        public Guid? RiskRatingLogoId { get; set; }

        [Column("RISKRATINGID")]
        public Guid? RiskRatingId { get; set; }

        [Column("RISKRATINGTYPENAME")]
        public string RiskRatingTypeName { get; set; }

        [Column("RISKRATINGTYPECOLOR")]
        public string RiskRatingTypeColor { get; set; }

        [Column("REPORTINGPERIODID")]
        public Guid? ReportingPeriodId { get; set; }

        [Column("MANAGERCOMMENTS")]
        public string ManagerComments { get; set; }
    }
}
