using System.Reflection;
using System.Text.Json;

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

    public List<Category> ListCategories()
    {
        var jsonString = ReadCategories();
        var categories = JsonSerializer.Deserialize<List<Category>>(jsonString)!;
        foreach (Category cat in categories)
            Console.WriteLine($"Id: {cat.Id}, Name: {cat.Name}");
        return categories;
    }
}