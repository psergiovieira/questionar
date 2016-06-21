using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace ApiQuestionar.Models
{
    public class MQuestion
    {
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<Alternative> Alternatives { get; set; }
    }
}