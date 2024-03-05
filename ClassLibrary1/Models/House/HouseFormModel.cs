using System.ComponentModel.DataAnnotations;
using static RentingHouseSystem.Infrastructure.Constants.DataConstants;
using static RentingHouseSystem.Core.Constants.MessageConstants;

namespace RentingHouseSystem.Core.Models.House
{
    public class HouseFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength, ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength, ErrorMessage = LengthMessage)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(HouseDescriptionMaxLength, MinimumLength = HouseDescriptionMinLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Imagee URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), HouseRentingPriceMinimum, HouseRentingPriceMaximum,ErrorMessage ="Price per month must be a positive number and less {2} leva")]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; }=new List<HouseCategoryServiceModel>();

    }
}
