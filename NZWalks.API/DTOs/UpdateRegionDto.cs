using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTOs
{
    public class UpdateRegionDTO
    {
        [Required]
        [MinLength(6, ErrorMessage = "Postcode should be a minimum of 6 characters.")]
        [MaxLength(6, ErrorMessage = "Postcode should be a maximum of 6 characters.")]
        public string Code { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Name should be a maximum of 5 characters.")]
        [MaxLength(50, ErrorMessage = "Name should be a maximum of 50 characters.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
