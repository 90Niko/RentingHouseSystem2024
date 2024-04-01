using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static RentingHouseSystem.Infrastructure.Constants.DataConstants;
using static RentingHouseSystem.Core.Constants.MessageConstants;
using RentingHouseSystem.Core.Contracts.House;

namespace RentingHouseSystem.Core.Models.House
{
    public class HouseServiceModel: IHouseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength, ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength, ErrorMessage = LengthMessage)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name="Image URL")]
        public string ImageUrl { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), HouseRentingPriceMinimum, HouseRentingPriceMaximum, ErrorMessage = "Price per month must be a positive number and less {2} leva")]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name="Is rented")]
        public bool IsRented { get; set; }


    }
}