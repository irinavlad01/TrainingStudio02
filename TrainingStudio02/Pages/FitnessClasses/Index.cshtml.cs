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

        public IList<FitnessClass> FitnessClass { get; set; } = default!;
        public FitnessClassData FitnessClassD { get; set; }
        public int FitnessClassID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            FitnessClassD = new FitnessClassData();

            FitnessClassD.FitnessClasses = await _context.FitnessClass
             .Include(b => b.Location)
             .Include(b => b.FitnessClassCategories)
             .ThenInclude(b => b.Category)
             .AsNoTracking()
             .OrderBy(b => b.Name)
             .ToListAsync();
            if (id != null)
            {
                FitnessClassID = id.Value;
                FitnessClass fitnessClass = FitnessClassD.FitnessClasses
                .Where(i => i.ID == id.Value).Single();
                FitnessClassD.Categories = fitnessClass.FitnessClassCategories.Select(s => s.Category);
            }
        }
    }
}
