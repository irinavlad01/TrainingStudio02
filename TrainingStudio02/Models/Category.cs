using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TrainingStudio02.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public ICollection<FitnessClassCategory>? FitnessClassCategories { get; set; }
    }
}
