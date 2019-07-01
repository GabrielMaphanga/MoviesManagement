using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MoviesManagement.Core.Entities
{
    [DataContract]
    public class Movie
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }
    }
}
