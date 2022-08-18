using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages;

public class RecipesModel : PageModel
{
    public List<string> Messages { get; set; } = new();
    public List<Recipe> RecipesRes { get; set; } = new();
    public List<Category> CategoriesRes { get; set; } = new();
    public List<List<string>> CategoriesNames { get; set; } = new();
    public Dictionary<Guid, string> catDict { get; set; } = new();

    public async Task OnGet(List<string> msgs)
    {
        Recipes recipes = await Requests.ListRecipes();
        foreach (Recipe recipe in recipes.RecipesList)
            RecipesRes.Add(recipe);
        Categories categories = await Requests.ListCategories();
        foreach (Category cat in categories.CategoriesList)
            CategoriesRes.Add(cat);

        CategoriesNames = GetCategoriesNames(RecipesRes, CategoriesRes);
        Messages = msgs;
    }

    // public async Task<IActionResult> OnPostCreate()
    // {
    //     string name = Request.Form["name"];
    //     String[] spearator = { "- ", "\n" };
    //     string ingredients = Request.Form["ingredients"];
    //     List<string> ingredientslist = ingredients.Split(spearator,
    //        StringSplitOptions.RemoveEmptyEntries).ToList();
    //     string instructions = Request.Form["instructions"];
    //     List<string> instructionslist = instructions.Split(spearator,
    //        StringSplitOptions.RemoveEmptyEntries).ToList();
    //     List<Guid> guidIds = new();
    //     foreach (var guid in Request.Form["categoriesIds"])
    //         guidIds.Add(new Guid(guid));
    //     // Validation
    //     Models.RecipeValidator validator = new();
    //     ValidationResult results = validator.Validate(
    //         new Models.Recipe(name, ingredientslist, instructionslist, guidIds)
    //     );
    //     if (results.IsValid)
    //         await Requests.CreateRecipe(name, ingredientslist, instructionslist, guidIds);
    //     else
    //     {
    //         List<string> msgs = new();
    //         foreach (var failure in results.Errors)
    //             msgs.Add(
    //                 $"Property {failure.PropertyName}: {failure.ErrorMessage}"
    //             );
    //         Messages = msgs;
    //     }
    //     return RedirectToPage("./Recipes", new { msgs = Messages });
    // }

    // public async Task<IActionResult> OnPostUpdate()
    // {
    //     Guid id = new Guid(Request.Form["targetId"]);
    //     string name = Request.Form["name"];
    //     String[] spearator = { "- ", "\n" };
    //     string ingredients = Request.Form["ingredients"];
    //     List<string> ingredientslist = ingredients.Split(spearator,
    //        StringSplitOptions.RemoveEmptyEntries).ToList();
    //     string instructions = Request.Form["instructions"];
    //     List<string> instructionslist = instructions.Split(spearator,
    //        StringSplitOptions.RemoveEmptyEntries).ToList();
    //     List<Guid> guidIds = new();
    //     foreach (var guid in Request.Form["categoriesIds"])
    //         guidIds.Add(new Guid(guid));
    //     // Validation
    //     Models.RecipeValidator validator = new();
    //     ValidationResult results = validator.Validate(
    //         new Models.Recipe(name, ingredientslist, instructionslist, guidIds)
    //     );
    //     if (results.IsValid)
    //         await Requests.UpdateRecipe(id, name, ingredientslist, instructionslist, guidIds);
    //     else
    //     {
    //         List<string> msgs = new();
    //         foreach (var failure in results.Errors)
    //             msgs.Add(
    //                 $"Property {failure.PropertyName}: {failure.ErrorMessage}"
    //             );
    //         Messages = msgs;
    //     }
    //     return RedirectToPage("./Recipes", new { msgs = Messages });
    // }

    // public async Task<IActionResult> OnPostDelete(Guid id)
    // {
    //     await Requests.DeleteRecipe(id);
    //     return RedirectToPage("./Recipes", new { msgs = Messages });
    // }

    private List<List<string>> GetCategoriesNames(List<Recipe> recipes, List<Category> categories)
    {
        Dictionary<Guid, string> Dict = new();
        foreach (Category cat in categories)
            Dict.Add(new Guid(cat.Id), cat.Name);
        catDict = Dict;
        List<List<string>> catNames = new();
        foreach (Recipe recipe in recipes)
        {
            List<string> names = new();
            foreach (var id in recipe.CategoriesIds)
                names.Add(catDict[new Guid(id.Id)]);
            catNames.Add(names);
        }
        return catNames;
    }
}
