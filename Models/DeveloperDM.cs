using EvaluationBizsol.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationBizsol.Models
{
    public class DeveloperDM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
    }
}
