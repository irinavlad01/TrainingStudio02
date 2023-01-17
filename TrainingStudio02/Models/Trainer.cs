using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TrainingStudio02.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Trainer Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string? Details { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<FitnessClass>? FitnessClasses { get; set; }
    }
}
