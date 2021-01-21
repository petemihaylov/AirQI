using System;

namespace AirQi.Dtos
{
    public class NotificationReadDto
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        
        public double [] Position { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}