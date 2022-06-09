using System.ComponentModel.DataAnnotations;

namespace MarkerService.Domain
{
    public class SlaMarker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int MaxValue { get; set; }

        public string LocationBoundaries {get; set; }

    }

}
