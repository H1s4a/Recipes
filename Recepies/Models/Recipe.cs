namespace Recipes.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public string Instructions { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
