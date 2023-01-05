using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingStudio02.Data;
using TrainingStudio02.Models;

namespace TrainingStudio02.Pages.FitnessClasses
{
    public class IndexModel : PageModel
    {
        private readonly TrainingStudio02.Data.TrainingStudio02Context _context;

        public IndexModel(TrainingStudio02.Data.TrainingStudio02Context context)
        {
            _context = context;
        }

        public IList<FitnessClass> FitnessClass { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FitnessClass != null)
            {
                FitnessClass = await _context.FitnessClass.Include(b => b.Trainer).ToListAsync();
                FitnessClass = await _context.FitnessClass.Include(b => b.Location).ToListAsync();
            }
        }
    }
}
