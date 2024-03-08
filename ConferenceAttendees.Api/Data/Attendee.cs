using System.ComponentModel.DataAnnotations;

namespace ConferenceAttendees.Api.Data
{
    public class Attendee : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string EmailAddress { get; set; }
        [MaxLength(14)]
        public string PhoneNumber { get; set; }
        [MaxLength(150)]
        public string CompanyName { get; set; }

        public ReferralSource? ReferralSource { get; set; }
        public Guid ReferralSourceId { get; set; }

        public JobRole? JobRole { get; set; }
        public Guid JobRoleId { get; set; }


        public Gender? Gender { get; set; }
        public Guid GenderId { get; set; }

    }
}
