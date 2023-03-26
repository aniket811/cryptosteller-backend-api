using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JwtAuthsApi.Models
{
    public class WeatherDatas
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="City Name is required")]
        public string CityName { get; set; }
    }
}
