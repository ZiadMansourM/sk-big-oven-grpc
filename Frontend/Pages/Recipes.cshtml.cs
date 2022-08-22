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
        //foreach (Recipe recipe in recipes.RecipesList)
        //    foreach (string ing in recipe.Ingredients)
        //        Console.WriteLine(ing);
        foreach (Recipe recipe in recipes.RecipesList)
            RecipesRes.Add(recipe);
        Categories categories = await Requests.ListCategories();
        foreach (Category cat in categories.CategoriesList)
            CategoriesRes.Add(cat);
        CategoriesNames = GetCategoriesNames(RecipesRes, CategoriesRes);
        Messages = msgs;
    }

    public async Task<IActionResult> OnPostCreate()
    {
        string name = Request.Form["name"];
        String[] spearator = { "- ", "\n" };
        // Ingredients
        string ingredients = Request.Form["ingredients"];
        List<string> ingredientslist = ingredients.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries).ToList();
        // Instructions
        string instructions = Request.Form["instructions"];
        List<string> instructionslist = instructions.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries).ToList();
        // Guids
        List<Guid> guidIds = new();
        foreach (var guid in Request.Form["categoriesIds"])
            guidIds.Add(new Guid(guid));
        // Validation
        RecipeCreate recipeCreate = new RecipeCreate{ Name=name };
        foreach (string ing in ingredientslist)
            recipeCreate.Ingredients.Add(ing);
        foreach (string ins in instructionslist)
            recipeCreate.Instructions.Add(ins);
        foreach (Guid id in guidIds)
            recipeCreate.CategoriesIds.Add(id.ToString());
        await Requests.CreateRecipe(recipeCreate);
        return RedirectToPage("./Recipes", new { msgs = Messages });
    }

    public async Task<IActionResult> OnPostUpdate()
    {
        Guid id = new Guid(Request.Form["targetId"]);
        string name = Request.Form["name"];
        String[] spearator = { "- ", "\n" };
        // Ingredients
        string ingredients = Request.Form["ingredients"];
        List<string> ingredientslist = ingredients.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries).ToList();
        // Instructions
        string instructions = Request.Form["instructions"];
        List<string> instructionslist = instructions.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries).ToList();
        // Guids
        List<Guid> guidIds = new();
        foreach (var guid in Request.Form["categoriesIds"])
            guidIds.Add(new Guid(guid));
        // Validation
        Recipe recipe = new Recipe { Id = id.ToString(), Name = name };
        foreach (string ing in ingredientslist)
            recipe.Ingredients.Add(ing);
        foreach (string ins in instructionslist)
            recipe.Instructions.Add(ins);
        foreach (Guid guid in guidIds)
            recipe.CategoriesIds.Add(guid.ToString());
        await Requests.UpdateRecipe(recipe);
        return RedirectToPage("./Recipes", new { msgs = Messages });
    }

    public async Task<IActionResult> OnPostDelete(Guid id)
    {
        await Requests.DeleteRecipe(id);
        return RedirectToPage("./Recipes", new { msgs = Messages });
    }

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
                names.Add(catDict[new Guid(id)]);
            catNames.Add(names);
        }
        return catNames;
    }
}
