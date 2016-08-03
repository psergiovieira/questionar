using System;
using Data;
using System.Collections.Generic;

namespace Domain.Models
{
    public class MQuestion
    {
        public int Id { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<Alternative> Alternatives { get; set; }

        public DateTime SentDate { get; set; }

        public bool Sent { get; set; }
    }
}