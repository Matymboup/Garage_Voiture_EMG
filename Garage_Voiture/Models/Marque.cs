using System.ComponentModel.DataAnnotations;

namespace Garage_Voiture.Models;

public class Marque
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nom")]
    public string Nom { get; set; }

    [Display(Name = "Desciption de la Marque")]
    public String? description { get; set; }

}
