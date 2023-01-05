namespace TrainingStudio02.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Details { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<FitnessClass>? FitnessClasses { get; set; }
    }
}
