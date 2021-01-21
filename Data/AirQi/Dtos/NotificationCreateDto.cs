using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
{
    public class NotificationCreateDto
    {
        [MaxLength(250)]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description { get; set; }
        
        [Required]
        public double [] Position { get; set; }
    }
}