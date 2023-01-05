using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingStudio02.Data;
using TrainingStudio02.Models;
using TrainingStudio02.Pages.Trainers;

namespace TrainingStudio02.Pages.FitnessClasses
{
    public class CreateModel : PageModel
    {
        private readonly TrainingStudio02.Data.TrainingStudio02Context _context;

        public CreateModel(TrainingStudio02.Data.TrainingStudio02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TrainerID"] = new SelectList(_context.Set<Trainer>(), "ID", "LastName");
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public FitnessClass FitnessClass { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FitnessClass.Add(FitnessClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
