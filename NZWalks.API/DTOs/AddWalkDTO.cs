using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.DTOs
{
    public class AddWalkDTO
    {
        [Required]
        [MinLength(6, ErrorMessage = "Walk's name should be a minimum of 6 characters.")]
        [MaxLength(100, ErrorMessage = "Walk's name should be a maximum of 100 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(50, ErrorMessage = "Walk's description should be a minimum of 50 characters.")]
        [MaxLength(1000, ErrorMessage = "Walk's description should be a maximum of 1000 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(0, 50)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
