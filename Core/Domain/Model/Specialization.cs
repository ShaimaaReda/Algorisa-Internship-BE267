﻿using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Model
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfRequests { get; set; }
    }
}
