using Frontend;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

public partial class Program
{
    public static readonly IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
}

public static class Requests
{
    private readonly static Grpc.Net.Client.GrpcChannel _channel = GrpcChannel.ForAddress(Program.config["baseAddress"]);
    private readonly static Frontend.CategoryService.CategoryServiceClient _client = new(_channel);

    public static void ListCategories()
    {
        Console.WriteLine("DEBUG TWO");
        Frontend.Void request = new();
        Console.WriteLine("DEBUG THREE");
        var reply = _client.ListCategories(request);
        Console.WriteLine("DEBUG FOUR");
        if (reply != null)
        {
            foreach (var category in reply.CategoriesList)
            {
                Console.WriteLine(category);
            }
        }
    }

    //async public static Task<Frontend.Models.Recipe> GetRecipe(Guid id)
    //{
    //    var uri = new Uri($"{_baseAddress}/recipes/{id}");
    //    using var client = new HttpClient();
    //    var json = await client.GetAsync(uri);
    //    var result = await json.Content.ReadAsStringAsync();
    //    return Deserialize<Frontend.Models.Recipe>(result);
    //}

    //async public static Task<Frontend.Models.Category> GetCategory(Guid id)
    //{
    //    var uri = new Uri($"{_baseAddress}/categories/{id}");
    //    using var client = new HttpClient();
    //    var json = await client.GetAsync(uri);
    //    var result = await json.Content.ReadAsStringAsync();
    //    return Deserialize<Frontend.Models.Category>(result);
    //}

    //async public static Task<Frontend.Models.Recipe> CreateRecipe(string name, List<string> ingredients, List<string> instructions, List<Guid> categoriesIds)
    //{
    //    var uri = new Uri($"{_baseAddress}/recipes");
    //    var recipe = new Frontend.Models.Recipe(name, ingredients, instructions, categoriesIds);
    //    var json = JsonSerializer.Serialize(recipe);
    //    var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    //    using var client = new HttpClient();
    //    var result = await client.PostAsync(uri, payload);
    //    var response = await result.Content.ReadAsStringAsync();
    //    return Deserialize<Frontend.Models.Recipe>(json);
    //}

    //async public static Task<Frontend.Models.Category> CreateCategory(string name)
    //{
    //    var uri = new Uri($"{_baseAddress}/categories");
    //    var category = new Frontend.Models.Category(name);
    //    var json = JsonSerializer.Serialize(category);
    //    Console.WriteLine(json);
    //    var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    //    using var client = new HttpClient();
    //    var result = await client.PostAsync(uri, payload);
    //    var responce = await result.Content.ReadAsStringAsync();
    //    return Deserialize<Frontend.Models.Category>(json);
    //}

    //async public static Task<Frontend.Models.Recipe> UpdateRecipe(Guid id, string name, List<string> ingredients, List<string> instructions, List<Guid> categoriesIds)
    //{
    //    var uri = new Uri($"{_baseAddress}/recipes/{id}");
    //    var recipe = new Frontend.Models.Recipe(name, ingredients, instructions, categoriesIds);
    //    var json = JsonSerializer.Serialize(recipe);
    //    Console.WriteLine(json);
    //    var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    //    using var client = new HttpClient();
    //    var result = await client.PutAsync(uri, payload);
    //    var responce = await result.Content.ReadAsStringAsync();
    //    return Deserialize<Frontend.Models.Recipe>(json);
    //}

    //async public static Task<Frontend.Models.Category> UpdateCategory(Guid id, string name)
    //{
    //    var uri = new Uri($"{_baseAddress}/categories/{id}");
    //    var category = new Frontend.Models.Category(name);
    //    var json = JsonSerializer.Serialize(category);
    //    var payload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    //    using var client = new HttpClient();
    //    var result = await client.PutAsync(uri, payload);
    //    var responce = await result.Content.ReadAsStringAsync();
    //    return Deserialize<Frontend.Models.Category>(json);
    //}

    //async public static Task DeleteRecipe(Guid id)
    //{
    //    var uri = new Uri($"{_baseAddress}/recipes/{id}");
    //    using var client = new HttpClient();
    //    var result = await client.DeleteAsync(uri);
    //    var responce = await result.Content.ReadAsStringAsync();
    //}

    //async public static Task DeleteCategory(Guid id)
    //{
    //    var uri = new Uri($"{_baseAddress}/categories/{id}");
    //    using var client = new HttpClient();
    //    var result = await client.DeleteAsync(uri);
    //    var responce = await result.Content.ReadAsStringAsync();
    //}
}