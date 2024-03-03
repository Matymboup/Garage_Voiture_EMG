using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_Voiture.Data;
using Garage_Voiture.Models;

namespace Garage_Voiture.Areas.Voiture.Pages
{
    public class EditModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public EditModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Garage_Voiture.Models.Voiture Voiture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture =  await _context.Voiture
                 .Include(f => f.Image)
                  .Include(c => c.Marque)
                .Include(c => c.Modele)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }
            Voiture = voiture;
           ViewData["MarqueId"] = new SelectList(_context.Marques, "Id", "Nom");
           ViewData["ModeleId"] = new SelectList(_context.Modeles, "Id", "Nom");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Voiture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoitureExists(Voiture.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VoitureExists(int id)
        {
            return _context.Voiture.Any(e => e.Id == id);
        }
    }
}
