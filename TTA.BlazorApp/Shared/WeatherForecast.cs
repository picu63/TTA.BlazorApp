using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace TTA.BlazorApp.Shared
{
    public class WeatherForecast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(-50, 60, ErrorMessage = "Temperatura musi znajdować się pomiędzy -50 a 60 stopni Celsjusza")]
        public int TemperatureC { get; set; }

        [MaxLength(15)]
        public string Summary { get; set; }

        [IgnoreDataMember]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
