using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;

namespace Backend.Services;

public class JsonService
{
    private readonly string _fileNameCategories;
    private readonly string _fileNameRecipes;

    public JsonService(string recipesPath, string categoriesPath)
    {
        if (string.IsNullOrEmpty(recipesPath) || string.IsNullOrEmpty(categoriesPath))
        {
            throw new ArgumentException("Error in appsettings.json");
        }
        // Recipes
        _fileNameRecipes = recipesPath;
        if (!File.Exists(_fileNameRecipes))
        {
            File.WriteAllText(_fileNameRecipes, "[]");
        }
        // Categories
        _fileNameCategories = categoriesPath;
        if (!File.Exists(_fileNameCategories))
        {
            File.WriteAllText(_fileNameCategories, "[]");
        }
    }

    public string ReadCategories()
    {
        return File.ReadAllText(_fileNameCategories);
    }

    public string ReadRecipes()
    {
        return File.ReadAllText(_fileNameRecipes);
    }

    public void OverWriteCategories(List<Category> categories)
    {
        var newString = System.Text.Json.JsonSerializer.Serialize<List<Category>>(categories);
        File.WriteAllText(_fileNameCategories, newString);
    }

    public void OverWriteRecipes(Recipes recipes)
    {
        var newString = System.Text.Json.JsonSerializer.Serialize(recipes);
        File.WriteAllText(_fileNameRecipes, newString);
    }

    public Category SaveCategories(Category category)
    {
        List<Category> categories = ListCategories();
        categories.Add(category);
        OverWriteCategories(categories);
        return category;
    }

    public Recipe SaveRecipes(Recipe recipe)
    {
        Recipes recipes = ListRecipes();
        recipes.RecipesList.Add(recipe);
        OverWriteRecipes(recipes);
        return recipe;
    }

    public List<Category> ListCategories()
    {
        var jsonString = ReadCategories();
        var categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(jsonString)!;
        return categories;
    }

    public Recipes ListRecipes()
    {
        var jsonString = ReadRecipes();
        Recipes recipes = JsonConvert.DeserializeObject<Recipes>(jsonString)!;
        return recipes;
    }

    public Category CreateCategory(string name)
    {
        return SaveCategories(
            new Category {
                Id = System.Guid.NewGuid().ToString(),
                Name = name
            }
        );
    }

    public Recipe CreateRecipe(RecipeCreate recipe)
    {
        Recipe newRecipe = new Recipe {
            Id= System.Guid.NewGuid().ToString()    ,
            Name = recipe.Name
        };
        foreach (string ing in recipe.Ingredients)
            newRecipe.Ingredients.Add(ing);
        foreach (string ins in recipe.Instructions)
            newRecipe.Instructions.Add(ins);
        foreach (string id in recipe.CategoriesIds)
            newRecipe.CategoriesIds.Add(id);
        return SaveRecipes(newRecipe);
    }

    public Category UpdateCategory(Guid id, string name)
    {
        List<Category> categories = ListCategories().FindAll(c => c.Id != id.ToString());
        Category category = ListCategories().Where(c => c.Id == id.ToString()).First();
        category.Name = name;
        categories.Add(category);
        OverWriteCategories(categories);
        return category;
    }

    public Recipe UpdateRecipe(Recipe recipe)
    {
        Recipes recipes = ListRecipes();
        Recipes newRecipes = new();
        Recipe target = new();
        foreach(Recipe r in recipes.RecipesList)
        {
            if (r.Id == recipe.Id)
                target = recipe;
            else
                newRecipes.RecipesList.Add(r);
        }
        newRecipes.RecipesList.Add(target);
        OverWriteRecipes(newRecipes);
        return recipe;
    }

    public Category DeleteCategory(Guid id)
    {
        // Cascade to Recipe
        var category = ListCategories().Where(c => c.Id == id.ToString()).First();
        //Recipes recipes = ListRecipes();
        //Recipes newRecipes = new();
        //foreach (Recipe r in recipes.RecipesList)
        //{
        //    foreach(string guid in r.CategoriesIds)
        //    {
        //        if(guid!=id.ToString())
        //        {
        //
        //        }
        //    }
        //}
        //OverWriteRecipes(newRecipes);
        // Delete Category
        var categories = ListCategories().FindAll(c => c.Id != id.ToString());
        OverWriteCategories(categories);
        return category;
    }

    public Recipe DeleteRecipe(RecipeId recipeId)
    {
        Recipes recipes = ListRecipes();
        Recipes newRecipes = new();
        Recipe recipe = new();
        foreach (Recipe r in recipes.RecipesList)
        {
            if (r.Id != recipeId.Id)
                newRecipes.RecipesList.Add(r);
            else
                recipe = r;
        }
        OverWriteRecipes(newRecipes);
        return recipe;
    }
}