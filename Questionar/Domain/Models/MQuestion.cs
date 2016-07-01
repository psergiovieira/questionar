using Data;
using System.Collections.Generic;

namespace Domain.Models
{
    public class MQuestion
    {
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<Alternative> Alternatives { get; set; }
    }
}