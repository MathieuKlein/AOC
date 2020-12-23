using System.Collections.Generic;
using System.Linq;

namespace D21AllergenAssessment
{
    public class IngredientsList
    {
        public IngredientsList(IEnumerable<string> ingredients, IEnumerable<string> allergens)
        {
            Ingredients = ingredients.ToHashSet();
            Allergens = allergens.ToHashSet();
        }

        public HashSet<string> Ingredients { get; }
        public HashSet<string> Allergens { get; }
    }
}