using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage_Voiture.Data;
using Garage_Voiture.Models;

namespace Garage_Voiture.Areas.Modeles.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public DeleteModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Modele Modele { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modele = await _context.Modeles.FirstOrDefaultAsync(m => m.Id == id);

            if (modele == null)
            {
                return NotFound();
            }
            else
            {
                Modele = modele;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modele = await _context.Modeles.FindAsync(id);
            if (modele != null)
            {
                Modele = modele;
                _context.Modeles.Remove(Modele);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
