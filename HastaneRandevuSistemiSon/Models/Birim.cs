using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiSon.Models
{
  public class Birim
  {
        [Key]
    public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Birim Ad")]
    public string Isim { get; set; }
    public ICollection<Doktor> Doktors { get; set;}
  }
}
