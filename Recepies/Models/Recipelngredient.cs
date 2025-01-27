using Microsoft.EntityFrameworkCore;
using Recipes.Models;

public class RecipeIngredient
{
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }

    [Precision(18, 4)]
    public decimal Quantity { get; set; }
}
