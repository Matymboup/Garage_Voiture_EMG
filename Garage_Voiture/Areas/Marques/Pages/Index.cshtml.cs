﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Garage_Voiture.Data.ApplicationDbContext _context;

        public IndexModel(Garage_Voiture.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Marque> Marque { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Marque = await _context.Marques.ToListAsync();
        }
    }
}
