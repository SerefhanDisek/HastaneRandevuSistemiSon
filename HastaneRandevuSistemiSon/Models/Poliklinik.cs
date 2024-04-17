using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiSon.Models
{
  public class Poliklinik
  {
        [Key]
    public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Poliklinik Ad")]
    public string Isim { get; set; }
    public ICollection<Birim> Birims { get; set; }
  }
}
