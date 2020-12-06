using System;

namespace ApiBase.Models
***REMOVED***
    public class Notification : BaseEntity
    ***REMOVED***
        public string Title ***REMOVED*** get; set;***REMOVED***
        public string Description ***REMOVED*** get; set;***REMOVED***
        public string Type ***REMOVED*** get; set;***REMOVED***
        public DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        public Notification()
        ***REMOVED***

       ***REMOVED***

        public Notification(string title, string description, string type, DateTime dateTime)
        ***REMOVED***
            Title = title;
            Description = description;
            Type = type;
            CreatedAt = CreatedAt;
       ***REMOVED***
   ***REMOVED***
***REMOVED***