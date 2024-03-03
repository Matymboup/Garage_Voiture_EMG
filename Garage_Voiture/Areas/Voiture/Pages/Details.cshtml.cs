using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage_Voiture.Data;
using Garage_Voiture.Models;

namespace Garage_Voiture.Areas.Voiture.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public DetailsModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Garage_Voiture.Models.Voiture Voiture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voiture
                  .Include(c => c.Marque)
                .Include(c => c.Modele).FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }
            else
            {
                Voiture = voiture;
            }
            return Page();
        }
    }
}
