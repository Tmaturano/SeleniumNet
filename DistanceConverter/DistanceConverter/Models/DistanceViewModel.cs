using System.ComponentModel.DataAnnotations;

namespace DistanceConverter.Models
{
    public class DistanceViewModel
    {
        [Required(ErrorMessage = "Distance in Miles is required")]
        [Range(0.01, 9999999.99, ErrorMessage = "Enter a value between 0.01 and 9999999.99")]
        public double DistanceInMiles { get; set; }
                
        public double DistanceInKm { get; set; }
    }
}
