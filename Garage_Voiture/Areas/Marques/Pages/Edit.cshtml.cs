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
using System.Runtime.ConstrainedExecution;

namespace Garage_Voiture.Areas.Marques.Pages
{
    public class EditModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public EditModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Marque Marque { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var marque =  await _context.Marques.FirstOrDefaultAsync(m => m.Id == id);
            if (marque == null)
            {
                return NotFound();
            }
            Marque = marque;
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

            _context.Attach(Marque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarqueExists(Marque.Id))
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

        private bool MarqueExists(int id)
        {
            return _context.Marques.Any(e => e.Id == id);
        }
    }
}
