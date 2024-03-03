using System.ComponentModel.DataAnnotations;

namespace Garage_Voiture.Models;

public class Modele
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nom")]
    public string Nom { get; set; }

   
    [Display(Name = "Desciption du modèle")]
    public String? Description { get; set; }

}
