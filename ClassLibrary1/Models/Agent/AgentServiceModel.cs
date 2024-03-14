using System.ComponentModel.DataAnnotations;
using static RentingHouseSystem.Core.Constants.MessageConstants;
using static RentingHouseSystem.Infrastructure.Constants.DataConstants;


namespace RentingHouseSystem.Core.Models.Agent
{
    public class AgentServiceModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AgentPhoneMaxLength, MinimumLength = AgentPhoneMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "The {0} field is not a valid phone number.")]
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
