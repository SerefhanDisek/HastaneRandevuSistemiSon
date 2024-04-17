using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemiSon.Models
{
  public class Hastalik
  {
        [Key]
    public int Id { get; set; }
    public string Isim{ get; set; }

    public string Tanim{ get; set; }

    public string Belirti { get; set; }

    public ICollection<Hasta> Hastas { get; set; }
    }
}
