using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiSon.Models
{
  public class Hasta
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(255)]
    [Display(Name = "Isim")]
    public string Isim { get; set; }
    [Required]
    [MaxLength(255)]
    [Display(Name = "Soy Isim")]
    public string SoyIsim { get; set; }
    public string TelefonNumarasi { get; set; }
    public string Email { get; set; }
    public DateTime DateofBirth { get; set; }


    public ICollection<Randevu> Randevular { get; set; }


}
}
