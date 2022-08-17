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

    public void OverWriteCategories(List<Category> categories)
    {
        var newString = JsonSerializer.Serialize<List<Category>>(categories);
        File.WriteAllText(_fileNameCategories, newString);
    }

    public Category SaveCategories(Category category)
    {
        List<Category> categories = ListCategories();
        categories.Add(category);
        OverWriteCategories(categories);
        return category;
    }

    public List<Category> ListCategories()
    {
        var jsonString = ReadCategories();
        var categories = JsonSerializer.Deserialize<List<Category>>(jsonString)!;
        return categories;
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

    public Category UpdateCategory(Guid id, string name)
    {
        List<Category> categories = ListCategories().FindAll(c => c.Id != id.ToString());
        Category category = ListCategories().Where(c => c.Id == id.ToString()).First();
        category.Name = name;
        categories.Add(category);
        OverWriteCategories(categories);
        return category;
    }
}