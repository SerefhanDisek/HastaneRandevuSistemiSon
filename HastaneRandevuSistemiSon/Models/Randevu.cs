using System;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiSon.Models
{
    public class Randevu
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tarih alan� gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Hasta Id alan� gereklidir.")]
        public int HastaIsim { get; set; }
        public Hasta Hasta { get; set; }


        [Required(ErrorMessage = "Doktor Id alan� gereklidir.")]
        public int DoktorIsim { get; set; }
        public Doktor Doktor { get; set;}
    }
}
