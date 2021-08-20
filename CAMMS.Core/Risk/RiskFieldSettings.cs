using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAMMS.Domain
{
    public class RiskFieldSettings
    {
        [Key]
        [Column("RiskFieldID")]
        public Guid RiskFieldID { get; set; }

        [Column("RiskFieldName")]
        public string RiskFieldName { get; set; }

        [Column("RiskFieldDescription")]
        public string RiskFieldDescription { get; set; }

        [Column("IsVisibleinInitial")]
        public bool? IsVisibleinInitial { get; set; }

        [Column("IsVisibleinRevised")]
        public bool? IsVisibleinRevised { get; set; }

        [Column("IsVisibleinFuture")]
        public bool? IsVisibleinFuture { get; set; }

        [Column("LastChanged")]
        public DateTime? LastChanged { get; set; }

        [Column("ModifiedBy")]
        public Guid? ModifiedBy { get; set; }

        [Column("IsMandatory")]
        public bool? IsMandatory { get; set; }

        [Column("LabelName")]
        public string LabelName { get; set; }

        [Column("FieldTypeID")]
        public Guid? FieldTypeID { get; set; }

        [Column("Sequence")]
        public int? Sequence { get; set; }

        [Column("RiskFieldTypeName")]
        public string RiskFieldTypeName { get; set; }

        [Column("IsVisibleInDetail")]
        public bool? IsVisibleInDetail { get; set; }

        [Column("IsVisibleInQuickUpdate")]
        public bool? IsVisibleInQuickUpdate { get; set; }

        [Column("IsVisibleInGrid")]
        public bool? IsVisibleInGrid { get; set; }

        [Column("IsVisibleInRegister")]
        public bool? IsVisibleInRegister { get; set; }

        [Column("IsVisibleInRegisterSearch")]
        public bool? IsVisibleInRegisterSearch { get; set; }

        [Column("RiskSharedFieldTypeId")]
        public Guid? RiskSharedFieldTypeId { get; set; }

        [Column("IsRequiredInInitial")]
        public bool IsRequiredInInitial { get; set; }

        [Column("IsRequiredInRevised")]
        public bool IsRequiredInRevised { get; set; }

        [Column("IsRequiredInFuture")]
        public bool IsRequiredInFuture { get; set; }

        [Column("IsStandard")]
        public bool IsStandard { get; set; }

        [Column("IsVisibleInControlRiskDetail")]
        public bool IsVisibleInControlRiskDetail { get; set; }

        [Column("IsUnique")]
        public bool IsUnique { get; set; }

        [Column("RiskTypeId")]
        public Guid? RiskTypeId { get; set; }

        [Column("RevisedAssessmentLabelName")]
        public string RevisedAssessmentLabelName { get; set; }

        [Column("FutureAssessmentLabelName")]
        public string FutureAssessmentLabelName { get; set; }

        [Column("SequenceInRevised")]
        public int? SequenceInRevised { get; set; }

        [Column("SequenceInFuture")]
        public int? SequenceInFuture { get; set; }

        [Column("IsVisibleInQuickUpdateRevisedAssessment")]
        public bool? IsVisibleInQuickUpdateRevisedAssessment { get; set; }

        [Column("IsVisibleInQuickUpdateFutureAssessment")]
        public bool? IsVisibleInQuickUpdateFutureAssessment { get; set; }

        [Column("IsRequiredInGrid")]
        public bool? IsRequiredInGrid { get; set; }

        [Column("RiskFieldInformationInitial")]
        public string RiskFieldInformationInitial { get; set; }

        [Column("RiskFieldInformationRevised")]
        public string RiskFieldInformationRevised { get; set; }

        [Column("RiskFieldInformationFuture")]
        public string RiskFieldInformationFuture { get; set; }

        [Column("ReviewFieldInformation")]
        public string ReviewFieldInformation { get; set; }

        [Column("ControlFieldInformation")]
        public string ControlFieldInformation { get; set; }

        [Column("ActionFieldInformation")]
        public string ActionFieldInformation { get; set; }

        [Column("IsVisibleInReview")]
        public bool IsVisibleInReview { get; set; }

        [Column("IsRequiredInReview")]
        public bool IsRequiredInReview { get; set; }

        [Column("IsRequiredInControlDetail")]
        public bool IsRequiredInControlDetail { get; set; }

        [Column("IsRequiredInControlRiskDetail")]
        public bool IsRequiredInControlRiskDetail { get; set; }

        [Column("IsVisibleInRiskActionDetail")]
        public bool IsVisibleInRiskActionDetail { get; set; }

        [Column("IsVisibleInRiskActionGrid")]
        public bool IsVisibleInRiskActionGrid { get; set; }
        
        [Column("IsVisibleInQuickUpdateRiskActionGrid")]
        public bool IsVisibleInQuickUpdateRiskActionGrid { get; set; }

        [Column("IsVisibleInQuickUpdateRiskActionDetail")]
        public bool IsVisibleInQuickUpdateRiskActionDetail { get; set; }

        [Column("EnableMultiselect")]
        public bool EnableMultiselect { get; set; }

        [Column("IsReadOnly")]
        public bool IsReadOnly { get; set; }

        [Column("IsReviewComment")]
        public bool IsReviewComment { get; set; }

    }
}
