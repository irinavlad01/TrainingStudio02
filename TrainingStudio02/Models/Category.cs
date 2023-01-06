﻿namespace TrainingStudio02.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<FitnessClassCategory>? FitnessClassCategories { get; set; }
    }
}
