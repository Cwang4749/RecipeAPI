using System;
namespace RecipeAPI.Models
{
    public class Nutrition
    {
        public int NutritionID { get; set; }
        public string? ServingSize { get; set; }
        public int Calories { get; set; }
        public string? TotalFat { get; set; }
        public string? Cholesterol { get; set; }
        public string? Sodium { get; set; }
        public string? TotalCarbs { get; set; }
        public string? Sugars { get; set; }
        public string? Protein { get; set; }
    }
}

