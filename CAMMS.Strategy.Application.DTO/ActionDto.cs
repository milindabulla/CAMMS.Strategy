using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.DTO
{
    public class ActionDto
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }


        public Guid ActionId { get; set; }
        public Guid StrategyId { get; set; }
        public Guid StaffId { get; set; }
        public Guid ServiceProfileId { get; set; }
        public Guid? CriticalIssueId { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid BudgetTypeId { get; set; }
        public bool Resolution { get; set; }
        public string ResolutionDetail { get; set; }
        public Guid ActionStatusId { get; set; }
        public int? PercentComplete { get; set; }
        public bool CouncilPlan { get; set; }
        public bool BestValue { get; set; }
        public bool EMTReport { get; set; }
        public int Priority { get; set; }
        public string AddtionalComment { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? ProjectId { get; set; }
        public string ActionDescription { get; set; }
        public DateTime? RevisedStartDate { get; set; }
        public DateTime? RevisedEndDate { get; set; }
        public DateTime? CriticalDate { get; set; }
        public Guid? AgencyId { get; set; }
        public bool? Confidential { get; set; }
        public bool? SettingValue { get; set; }
        public string ActionReference { get; set; }
        public DateTime? ProgressUpdateDate { get; set; }
        public bool? CommentUpdated { get; set; }
        public Guid? ProjectedStatusId { get; set; }
        public Guid? PriorityId { get; set; }
        public Guid? RiskId { get; set; }
        public Guid? RiskCategoryId { get; set; }
        public Guid HierarchyNodeId { get; set; }
        public string Latitude { get; set; }
        public string Longitiude { get; set; }
        public int Zoom { get; set; }
        public byte[] ImageData { get; set; }
        public byte[] Thumbnail { get; set; }
        public Guid? ManualProgress { get; set; }
        public DateTime? CompletionDate { get; set; }
        public Guid? ReviewedBy { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public string ReviewComments { get; set; }
        public DateTime? NextReviewedDate { get; set; }
        public Guid? ReviewReportingPeriodId { get; set; }
        public Guid? ActionRatingId { get; set; }
        public bool? IsAllowThirdPartyReviews { get; set; }
        public bool IsCollaborate { get; set; }
        public bool IsAddedFromCollab { get; set; }
        public int? SharedActionId { get; set; }
        public int? SharedTaskId { get; set; }
        public bool ShowProgressToRecipient { get; set; }
        public bool IsSharedEnabled { get; set; }
        public string Key { get; set; }
        public string AppArea { get; set; }
        public bool? IsKeyIndicator { get; set; }
        public string ManagerComments { get; set; }
        public string PerformanceColourCode { get; set; }
        public string ProjectCode { get; set; }
    }
}
