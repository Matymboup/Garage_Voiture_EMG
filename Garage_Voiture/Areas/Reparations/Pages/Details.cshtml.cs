using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage_Voiture.Data;
using Garage_Voiture.Models;

namespace Garage_Voiture.Areas.Reparations.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public DetailsModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Repair Repair { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Reparations
                .Include(c => c.Voiture.VIN)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repair == null)
            {
                return NotFound();
            }
            else
            {
                Repair = repair;
            }
            return Page();
        }
    }
}
