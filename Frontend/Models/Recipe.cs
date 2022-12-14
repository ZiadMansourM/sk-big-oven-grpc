// using FluentValidation;
// namespace Frontend.Models;

// public class Recipe
// {
//     public Guid Id { get; set; }
//     public string Name { get; set; }
//     public List<string> Ingredients { get; set; }
//     public List<string> Instructions { get; set; }
//     public List<Guid> CategoriesIds { get; set; }

//     public Recipe(string name, List<string> ingredients, List<string> instructions, List<Guid> categoriesIds)
//     {
//         Id = Guid.NewGuid();
//         Name = name;
//         Ingredients = ingredients;
//         Instructions = instructions;
//         CategoriesIds = categoriesIds;
//     }

//     public List<Recipe> ToList()
//     {
//         return new List<Recipe> { this };
//     }
// }

// public class RecipeValidator : AbstractValidator<Recipe>
// {
//     public RecipeValidator()
//     {
//         RuleFor(recipe => recipe.Name).NotEmpty();
//         RuleFor(recipe => recipe.Ingredients).NotEmpty();
//         RuleFor(recipe => recipe.Instructions).NotEmpty();
//         RuleFor(recipe => recipe.CategoriesIds).NotEmpty();
//     }
// }
