﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingStudio02.Data;
using TrainingStudio02.Models;

namespace TrainingStudio02.Pages.Locations
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly TrainingStudio02.Data.TrainingStudio02Context _context;

        public DeleteModel(TrainingStudio02.Data.TrainingStudio02Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }

            var location = await _context.Location.FirstOrDefaultAsync(m => m.ID == id);

            if (location == null)
            {
                return NotFound();
            }
            else 
            {
                Location = location;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }
            var location = await _context.Location.FindAsync(id);

            if (location != null)
            {
                Location = location;
                _context.Location.Remove(Location);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
