using System;
using System.ComponentModel.DataAnnotations;

namespace MarkerService.Domain
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public Notification()
        {

        }

        public Notification(string title, string description, string type, DateTime dateTime)
        {
            Title = title;
            Description = description;
            Type = type;
            CreatedAt = CreatedAt;
        }
    }
}