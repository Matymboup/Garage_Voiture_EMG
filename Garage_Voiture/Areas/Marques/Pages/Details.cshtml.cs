using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Garage_Voiture.Data;
using Garage_Voiture.Models;

namespace Garage_Voiture.Areas.Marques.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public DetailsModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Marque Marque { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques.FirstOrDefaultAsync(m => m.Id == id);
            if (marque == null)
            {
                return NotFound();
            }
            else
            {
                Marque = marque;
            }
            return Page();
        }
    }
}
