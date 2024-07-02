using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork2.Modelo
{
    public class Measurement_Unit
    {
        [Key]
        public int Measurement_ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Measurement { get; set; }

        public Measurement_Unit() { }
        public Measurement_Unit(int Measurement_ID, string Measurement)
        {
            this.Measurement_ID = Measurement_ID;
            this.Measurement = Measurement; 
        }

        /// <summary>
        /// Método que devuelve absolutamente toda la información del país (toda la tabla)
        /// </summary>
        /// <returns>string</returns>
        public string GetAllMeasurementUnitInformation()
        {
            return $"Id: {Measurement_ID} Name: {Measurement}";
        }
    }
}
