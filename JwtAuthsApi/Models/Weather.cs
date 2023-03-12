using System.ComponentModel.DataAnnotations;

namespace JwtAuthsApi.Models
{
    public class Weather
    {
        [Key]
        public string CityId { get; set; }
        public string CityName { get; set; }
    }
}
