namespace Garage_Voiture.Models;

using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;


public class Voiture
{
    public int Id { get; set; }

    public string? VIN { get; set; }
    [Display(Name = "Statut")]
    public string? Status { get; set; }


    public int? Année { get; set; }
    [Display(Name = "Marque")]
    public int? MarqueId { get; set; }
    [Display(Name = "Modele")]
    public int? ModeleId { get; set; }
    public virtual Marque? Marque { get; set; }
    public virtual Modele? Modele { get; set; }

[Required]
    [Display(Name = "Date d'achat")]
    public DateTime? DateAchat { get; set; }

    [Required]
    [Display(Name = "Prix d'achat")]
    public decimal? PrixAchat { get; set; }

    [Required]
    [Display(Name = "Date de disponibilité")]
    public DateTime? Disponible { get; set; }



    [Required]
    [Display(Name = "Prix de vente")]
    public decimal? PrixVente { get; set; }

    [Required]
    [Display(Name = "Date de vente")]
    public DateTime? DateVente { get; set; }



    public virtual Image? Image { get; set; }
       public virtual ICollection<Repair>? Réparations { get; set; }
   

}
