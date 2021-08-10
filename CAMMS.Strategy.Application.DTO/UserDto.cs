using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Salutation { get; set; }
        public byte[] SHA1Password { get; set; }
        public byte[] MD5Password { get; set; }
        public int TotalLogins { get; set; }
        public bool Active { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? CurrentSystemPeriodId { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string ApplicationSettings { get; set; }
        public bool RestrictedAccess { get; set; }
        public string? EmployeeNo { get; set; }
        public bool? IsCurrentUserLoggedIn { get; set; }
        public DateTime? UserLastLoggedInTime { get; set; }
        public bool? IsEmailSent { get; set; }
        public bool? IsAddCollabDiscussionGroup { get; set; }
        public int? SharedUserId { get; set; }
        public string? FullStaffName { get; set; }
        public Guid? StaffImageID { get; set; }
        public bool? IsPortalUser { get; set; }
        public int? Id { get; set; }
    }
}
