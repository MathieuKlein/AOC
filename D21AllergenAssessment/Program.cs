using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D21AllergenAssessment
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);

            var ingredientsLists = new List<IngredientsList>();
            var allergensIngredientsDict = new Dictionary<string, List<string>>();

            foreach (var s in strings)
            {
                var split1 = s.Split(new[] { "(contains", ")" }, StringSplitOptions.RemoveEmptyEntries);
                var ingredients = split1[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var allergens = split1[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                ingredientsLists.Add(new IngredientsList(ingredients, allergens));
                foreach (var a in allergens)
                    allergensIngredientsDict[a] = (allergensIngredientsDict.ContainsKey(a) ? allergensIngredientsDict[a].Intersect(ingredients) : ingredients).ToList();
            }

            while (allergensIngredientsDict.Any(x => x.Value.Count > 1))
            {
                var singles = allergensIngredientsDict.Where(x => x.Value.Count == 1);
                foreach (var single in singles)
                foreach (var allergenPossibleIngredient in allergensIngredientsDict.Where(x => x.Key != single.Key))
                    allergenPossibleIngredient.Value.Remove(single.Value.Single());
            }

            var canonicalDangerousIngredients = allergensIngredientsDict.OrderBy(x => x.Key).Select(x => x.Value.Single()).ToList();

            var safeIngredients = new List<string>();
            foreach (var ingredientsList in ingredientsLists)
                safeIngredients.AddRange(ingredientsList.Ingredients.AsEnumerable().Except(canonicalDangerousIngredients));

            Console.WriteLine(safeIngredients.Count);
            Console.WriteLine(canonicalDangerousIngredients.Aggregate((x, y) => x + "," + y));
            Console.ReadKey();
        }
    }
}