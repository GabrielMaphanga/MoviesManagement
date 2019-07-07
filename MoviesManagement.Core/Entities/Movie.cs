using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace MoviesManagement.Core.Entities
{
    [DataContract]
    public class Movie
    {
        
        [DataMember(Name = "id")]
        [Key]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }
    }
}
