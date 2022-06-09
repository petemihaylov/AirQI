using System.ComponentModel.DataAnnotations;

namespace MarkerService.Domain
{
    public class Marker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double latitude { get; set; }

        [Required]
        public double longitude { get; set; }

        [Required]
        public string type { get; set; }

        public string ico { get; set; }
    }
}