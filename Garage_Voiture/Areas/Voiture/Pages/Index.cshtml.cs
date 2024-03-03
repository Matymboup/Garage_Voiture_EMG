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
    public class IndexModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public IndexModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Garage_Voiture.Models.Voiture> Voiture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Voiture = await _context.Voiture
                .Include(v => v.Marque)
                .Include(v => v.Modele)
                .Include(v => v.Image).ToListAsync();
        }
    }
}
