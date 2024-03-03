using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage_Voiture.Data;
using Garage_Voiture.Models;

namespace Garage_Voiture.Areas.Reparations.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public CreateModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["VoitureId"] = new SelectList(_context.Voiture, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Repair Repair { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reparations.Add(Repair);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
