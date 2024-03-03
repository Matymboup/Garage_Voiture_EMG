
namespace Garage_Voiture.Models;

using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;



    public class Repair
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Nom de la Réparation")]
        public string? Name { get; set; }


        [Required]
        [Display(Name = "Prix de la Réparation")]
        public decimal? CoutReparation { get; set; }
        public int? VoitureId { get; set; }

        public virtual Voiture? Voiture { get; set; }


    }

