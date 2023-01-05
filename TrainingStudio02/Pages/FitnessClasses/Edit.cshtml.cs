using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingStudio02.Data;
using TrainingStudio02.Models;

namespace TrainingStudio02.Pages.FitnessClasses
{
    public class EditModel : PageModel
    {
        private readonly TrainingStudio02.Data.TrainingStudio02Context _context;

        public EditModel(TrainingStudio02.Data.TrainingStudio02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public FitnessClass FitnessClass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FitnessClass == null)
            {
                return NotFound();
            }

            var fitnessclass =  await _context.FitnessClass.FirstOrDefaultAsync(m => m.ID == id);
            if (fitnessclass == null)
            {
                return NotFound();
            }
            FitnessClass = fitnessclass;
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

            _context.Attach(FitnessClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessClassExists(FitnessClass.ID))
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

        private bool FitnessClassExists(int id)
        {
          return _context.FitnessClass.Any(e => e.ID == id);
        }
    }
}
