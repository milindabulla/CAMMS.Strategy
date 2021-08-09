using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Domain
{
    public class Action
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }

        [Column("ACTIONID")]
        public Guid ActionId { get; set; }

        [Column("STRATEGYID")]
        public Guid? StrategyId { get; set; }

        [Column("STAFFID")]
        public Guid? StaffId { get; set; }

        [Column("SERVICEPROFILEID")]
        public Guid? ServiceProfileId { get; set; }

        [Column("CRITICALISSUEID")]
        public Guid? CriticalIssueId { get; set; }

        [Column("POSITION")]
        public int? Position { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("COMMENTS")]
        public string Comments { get; set; }

        [Column("STARTDATE")]
        public DateTime? StartDate { get; set; }

        [Column("ENDDATE")]
        public DateTime? EndDate { get; set; }

        [Column("BUDGETTYPEID")]
        public Guid? BudgetTypeId { get; set; }

        [Column("RESOLUTION")]
        public bool? Resolution { get; set; }

        [Column("RESOLUTIONDETAIL")]
        public string ResolutionDetail { get; set; }

        [Column("ACTIONSTATUSID")]
        public Guid? ActionStatusId { get; set; }

        [Column("PERCENTCOMPLETE")]
        public int? PercentComplete { get; set; }

        [Column("COUNCILPLAN")]
        public bool CouncilPlan { get; set; }

        [Column("BESTVALUE")]
        public bool BestValue { get; set; }

        [Column("EMTREPORT")]
        public bool EMTReport { get; set; }

        [Column("PRIORITY")]
        public int? Priority { get; set; }

        [Column("ADDTIONALCOMMENT")]
        public string AddtionalComment { get; set; }

        [Column("LASTCHANGE")]
        public DateTime? LastChange { get; set; }

        [Column("MODIFEDBY")]
        public Guid? ModifiedBy { get; set; }

        [Column("ProjectID")]
        public Guid? ProjectId { get; set; }

        [Column("DESCRIPTION")]
        public string ActionDescription { get; set; }

        [Column("REVISEDSTARTDATE")]
        public DateTime? RevisedStartDate { get; set; }

        [Column("REVISEDENDDATE")]
        public DateTime? RevisedEndDate { get; set; }

        [Column("CRITICALDATE")]
        public DateTime? CriticalDate { get; set; }

        [Column("AGENCYID")]
        public Guid? AgencyId { get; set; }

        [Column("CONFIDENTIAL")]
        public bool? Confidential { get; set; }

        //[Column("Value")]
        //public bool? SettingValue { get; set; }

        [Column("ACTIONREFERENCE")]
        public string ActionReference { get; set; }

        [Column("PROGRESSUPDATEDATE")]
        public DateTime? ProgressUpdateDate { get; set; }

        [Column("COMMENTUPDATED")]
        public bool? CommentUpdated { get; set; }

        [Column("PROJECTEDSTATUSID")]
        public Guid? ProjectedStatusId { get; set; }

        [Column("PRIORITYID")]
        public Guid? PriorityId { get; set; }

        [Column("RISKID")]
        public Guid? RiskId { get; set; }

        [Column("RISKCATEGORYID")]
        public Guid? RiskCategoryId { get; set; }

        [Column("HierarchyNodeId")]
        public Guid? HierarchyNodeId { get; set; }

        [Column("LATITUDE")]
        public string Latitude { get; set; }

        [Column("LONGITIUDE")]
        public string Longitiude { get; set; }

        [Column("ZOOM")]
        public int? Zoom { get; set; }

        [Column("IMAGEDATA")]
        public byte[] ImageData { get; set; }

        [Column("IMAGETHUMBNAIL")]
        public byte[] Thumbnail { get; set; }

        [Column("MANUALPROGRESS")]
        public Guid? ManualProgress { get; set; }

        [Column("COMPLETIONDATE")]
        public DateTime? CompletionDate { get; set; }

        [Column("ReviewedBy")]
        public Guid? ReviewedBy { get; set; }

        [Column("ReviewedDate")]
        public DateTime? ReviewedDate { get; set; }

        [Column("ReviewComments")]
        public string ReviewComments { get; set; }

        [Column("NextReviewedDate")]
        public DateTime? NextReviewedDate { get; set; }

        [Column("ReviewReportingPeriodId")]
        public Guid? ReviewReportingPeriodId { get; set; }

        [Column("ActionRatingId")]
        public Guid? ActionRatingId { get; set; }

        [Column("IsAllowThirdPartyReviews")]
        public bool? IsAllowThirdPartyReviews { get; set; }


        [Column("ISCOLLABORATE")]
        public bool? IsCollaborate { get; set; }

        [Column("ISADDEDFROMCOLLAB")]
        public bool? IsAddedFromCollab { get; set; }

        [Column("SHAREDACTIONIID")]
        public int? SharedActionId { get; set; }

        [Column("SHAREDTASKID")]
        public int? SharedTaskId { get; set; }

        [Column("SHOWPROGRESSTORECIPIENT")]
        public bool? ShowProgressToRecipient { get; set; }

        [Column("ISSHAREDENABLED")]
        public bool? IsSharedEnabled { get; set; }

        //[Column("KEY")]
        //public string Key { get; set; }

        //[Column("APPAREA")]
        //public string AppArea { get; set; }

        [Column("ISKEYINDICATOR")]
        public bool? IsKeyIndicator { get; set; }

        [Column("MANAGERCOMMENTS")]
        public string ManagerComments { get; set; }


        //[Column("PERFORMANCECOLOURCODE")]
        //public string PerformanceColourCode { get; set; }

        //[Column("ProjectCode")]
        //public string ProjectCode { get; set; }
    }
}
