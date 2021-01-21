using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AirQi.Models.Core;

namespace AssetNXT.Dtos.Core
***REMOVED***
    public class AgreementCreateDto
    ***REMOVED***
        [MaxLength(250)]
        [Required]
        public List<Station> Stations ***REMOVED*** get; set;***REMOVED***

        [MaxLength(250)]
        [Required]
        public string Name ***REMOVED*** get; set;***REMOVED***

        [Required(AllowEmptyStrings = true)]
        public string Description ***REMOVED*** get; set;***REMOVED***

        [Required]
        public double AqiMin ***REMOVED*** get; set;***REMOVED***

        [Required]
        public double AqiMax ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***