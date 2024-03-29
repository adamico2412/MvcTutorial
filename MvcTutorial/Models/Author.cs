﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTutorial.Models
{
    public class Author
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        [Required]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        [Required]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "biography")]
        public string Biography { get; set; }

        [JsonProperty(PropertyName = "books")]
        public virtual ICollection<Book> Books { get; set; }
    }
}