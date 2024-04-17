using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiSon.Models
{
  public class Doktor
  {
        [Key]
    public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Doktor Ad")]
    public string Isim { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Doktor SoyAd")]
    public string SoyIsim { get; set; }
    public int BirimId { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Birim Ad")]
    public Birim Birim { get; set; }

    public int PoliklinikId { get ; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Poliklinik Ad")]
    public string Poliklinik { get; set; }  

    




    }
}
