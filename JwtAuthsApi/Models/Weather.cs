﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthsApi.Models
{
    [Table("Weathers")]
    public class Weather
    {
        [Key]
        public string CityName { get; set; }
    }
}
