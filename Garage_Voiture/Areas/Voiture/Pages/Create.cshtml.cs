using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage_Voiture.Data;
using Garage_Voiture.Models;
using Garage_Voiture.Services;
using System.Runtime.ConstrainedExecution;

namespace Garage_Voiture.Areas.Voiture.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;
        private readonly ImageService imageService;

        public CreateModel(Garage_Voiture.Data.ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            this.imageService = imageService; // Initialize the imageService
        }

        public IActionResult OnGet()
        {
        ViewData["MarqueId"] = new SelectList(_context.Marques, "Id", "Nom");
        ViewData["ModeleId"] = new SelectList(_context.Modeles, "Id", "Nom");
            return Page();
        }

        [BindProperty]
        public Garage_Voiture.Models.Voiture Voiture { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyVoiture = new Garage_Voiture.Models.Voiture();
            if (null != Voiture.Image)
            {

                emptyVoiture.Image = await imageService.UploadAsync(Voiture.Image);
                ViewData["Message"] = emptyVoiture.Image.Name;
            }

            await TryUpdateModelAsync(emptyVoiture, "Voiture", c => c.VIN, c => c.Année, c => c.MarqueId, c => c.ModeleId, c => c.DateAchat, c => c.PrixAchat, c => c.Disponible, c => c.PrixVente, c => c.DateVente);
            _context.Voiture.Add(Voiture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
