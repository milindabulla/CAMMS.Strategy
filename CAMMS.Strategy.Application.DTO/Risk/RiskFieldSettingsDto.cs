using System;

namespace CAMMS.Strategy.Application.DTO
{
    public class RiskFieldSettingsDto
    {
        public Guid RiskFieldID { get; set; }

        public string RiskFieldName { get; set; }

        public string RiskFieldDescription { get; set; }

        public bool? IsVisibleinInitial { get; set; }

        public bool? IsVisibleinRevised { get; set; }

        public bool? IsVisibleinFuture { get; set; }

        public DateTime? LastChanged { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool? IsMandatory { get; set; }

        public string LabelName { get; set; }

        public Guid? FieldTypeID { get; set; }

        public int? Sequence { get; set; }

        public string RiskFieldTypeName { get; set; }

        public bool? IsVisibleInDetail { get; set; }

        public bool? IsVisibleInQuickUpdate { get; set; }

        public bool? IsVisibleInGrid { get; set; }

        public bool? IsVisibleInRegister { get; set; }

        public bool? IsVisibleInRegisterSearch { get; set; }

        public Guid? RiskSharedFieldTypeId { get; set; }

        public bool IsRequiredInInitial { get; set; }

        public bool IsRequiredInRevised { get; set; }

        public bool IsRequiredInFuture { get; set; }

        public bool IsStandard { get; set; }

        public bool IsVisibleInControlRiskDetail { get; set; }

        public bool IsUnique { get; set; }

        public Guid? RiskTypeId { get; set; }

        public string RevisedAssessmentLabelName { get; set; }

        public string FutureAssessmentLabelName { get; set; }

        public int? SequenceInRevised { get; set; }

        public int? SequenceInFuture { get; set; }

        public bool? IsVisibleInQuickUpdateRevisedAssessment { get; set; }

        public bool? IsVisibleInQuickUpdateFutureAssessment { get; set; }

        public bool? IsRequiredInGrid { get; set; }

        public string RiskFieldInformationInitial { get; set; }

        public string RiskFieldInformationRevised { get; set; }

        public string RiskFieldInformationFuture { get; set; }

        public string ReviewFieldInformation { get; set; }

        public string ControlFieldInformation { get; set; }

        public string ActionFieldInformation { get; set; }

        public bool IsVisibleInReview { get; set; }

        public bool IsRequiredInReview { get; set; }

        public bool IsRequiredInControlDetail { get; set; }

        public bool IsRequiredInControlRiskDetail { get; set; }

        public bool IsVisibleInRiskActionDetail { get; set; }

        public bool IsVisibleInRiskActionGrid { get; set; }

        public bool IsVisibleInQuickUpdateRiskActionGrid { get; set; }

        public bool IsVisibleInQuickUpdateRiskActionDetail { get; set; }

        public bool EnableMultiselect { get; set; }

        public bool IsReadOnly { get; set; }

        public bool IsReviewComment { get; set; }
    }
}
