using System;

namespace ApiBase.Models
{
    public class Notification : BaseEntity
    {
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