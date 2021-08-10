using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Domain
{
    public class User
    {
        [Column("USERID")]           
        public Guid UserId { get; set; }

        [Column("USERNAME")]
        public string UserName { get; set; }
        [Column("SALUTATION")]
        public string Salutation { get; set; }
        [Column("SHA1PASSWORD")]
        public byte[] SHA1Password { get; set; }
        [Column("MD5PASSWORD")]
        public byte[] MD5Password { get; set; }
        [Column("TOTALLOGINS")]
        public int TotalLogins { get; set; }
        [Column("ACTIVE")]
        public bool Active { get; set; }
        [Column("LASTCHANGE")]
        public DateTime? LastChange { get; set; }
        [Column("CURRENTSYSTEMPERIODID")]
        public Guid? CurrentSystemPeriodId { get; set; }
        [Column("MODIFEDBY")]
        public Guid? ModifiedBy { get; set; }
        [Column("APPLICATIONSETTINGS")]
        public string ApplicationSettings { get; set; }

        [Column("RESTRICTEDACCESSACCOUNT")]
        public bool RestrictedAccess { get; set; }

        [Column("EMPLOYEENO")]
        public string? EmployeeNo { get; set; }

        [Column("ISCURRENTUSERLOGGEDIN")]
        public bool? IsCurrentUserLoggedIn { get; set; }

        [Column("USERLASTLOGGEDINTIME")]
        public DateTime? UserLastLoggedInTime { get; set; }

        [Column("ISEMAILSENT")]
        public bool? IsEmailSent { get; set; }

        [Column("ISADDCOLLABDISCUSSIONGROUP")]
        public bool? IsAddCollabDiscussionGroup { get; set; }

        [Column("SHAREDUSERID")]
        public int? SharedUserId { get; set; }

        //[Column("FullStaffName")]
        //public string? FullStaffName { get; set; }

        //[Column("StaffImageID")]
        //public Guid? StaffImageID { get; set; }

        [Column("ISPORTALUSER")]
        public bool? IsPortalUser { get; set; }

        //[Column("Id")]
        //public int? Id { get; set; }
    }
}
