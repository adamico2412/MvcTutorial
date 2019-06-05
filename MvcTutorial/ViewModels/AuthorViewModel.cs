using AutoMapper;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MvcTutorial.ViewModels
{
    public class AuthorViewModel
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
    }
}