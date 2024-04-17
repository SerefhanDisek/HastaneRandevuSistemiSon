using System;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiSon.Models
{
    public class Randevu
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tarih alaný gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Hasta Id alaný gereklidir.")]
        public int HastaIsim { get; set; }
        public Hasta Hasta { get; set; }


        [Required(ErrorMessage = "Doktor Id alaný gereklidir.")]
        public int DoktorIsim { get; set; }
        public Doktor Doktor { get; set;}
    }
}
