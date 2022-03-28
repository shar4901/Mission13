using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class Recipe
    {
        [Key]
        [Required]
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }

        public int RecipeClassId { get; set; }
        public string Preparation { get; set; }
        public string Notes { get; set; }

    }
}
