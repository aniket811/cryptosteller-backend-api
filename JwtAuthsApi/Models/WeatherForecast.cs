using System.ComponentModel.DataAnnotations;

namespace JwtAuthsApi.Models
{
    public class WeatherForecastModel
    {
        [Key]
        public Guid Id { get; set; }
        public string CityName { get; set; }
    }
}
