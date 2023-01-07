﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingStudio02.Models;

namespace TrainingStudio02.Data
{
    public class TrainingStudio02Context : DbContext
    {
        public TrainingStudio02Context (DbContextOptions<TrainingStudio02Context> options)
            : base(options)
        {
        }

        public DbSet<TrainingStudio02.Models.FitnessClass> FitnessClass { get; set; } = default!;

        public DbSet<TrainingStudio02.Models.Location> Location { get; set; }

        public DbSet<TrainingStudio02.Models.Trainer> Trainer { get; set; }

        public DbSet<TrainingStudio02.Models.Category> Category { get; set; }

        public DbSet<TrainingStudio02.Models.Member> Member { get; set; }

        public DbSet<TrainingStudio02.Models.Subscription> Subscription { get; set; }
    }
}
