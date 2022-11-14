using System;
namespace RecipeAPI.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string Instructions { get; set; }

        public int NutritionID { get; set; }
        public Nutrition? Nutrition { get; set; }
    }
}

