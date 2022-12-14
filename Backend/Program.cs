using Microsoft.AspNetCore.Mvc;
using Grpc.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Text;
using Backend;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder();
builder.Services.AddGrpc();
builder.WebHost.ConfigureKestrel(k =>
{
    k.ListenLocalhost(5057, o => o.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();

app.MapGrpcService<BigOvenService>();
app.MapGet("/", () => "This server contains a gRPC service");

app.Run();

public partial class Program
{
    public static readonly IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
}

public class BigOvenService : BigOven.BigOvenBase
{
    private static readonly Backend.Services.JsonService _service = new(
        Program.config["RecipesPath"],
        Program.config["CategoriesPath"]
    );

    public override Task<Categories> ListCategories(Backend.Void request, ServerCallContext context)
    {
        Categories categories = new();
        List<Category> categoriesList = _service.ListCategories();
        foreach (Category category in categoriesList)
            categories.CategoriesList.Add(category);
        return Task.FromResult(categories);
    }

    public override Task<Recipes> ListRecipes(Backend.Void request, ServerCallContext context)
    {
        return Task.FromResult(_service.ListRecipes());
    }

    public override Task<Category> CreateCategory(Backend.CategoryName request, ServerCallContext context)
    {
        return Task.FromResult(_service.CreateCategory(request.Name));
    }

    public override Task<Recipe> CreateRecipe(Backend.RecipeCreate request, ServerCallContext context)
    {
        return Task.FromResult(_service.CreateRecipe(request));
    }

    public override Task<Category> UpdateCategory(Backend.Category request, ServerCallContext context)
    {
        return Task.FromResult(_service.UpdateCategory(new Guid(request.Id), request.Name));
    }

    public override Task<Recipe> UpdateRecipe(Backend.Recipe request, ServerCallContext context)
    {
        return Task.FromResult(_service.UpdateRecipe(request));
    }

    public override Task<Backend.Category> DeleteCategory(Backend.CategoryId request, ServerCallContext context)
    {
        return Task.FromResult(_service.DeleteCategory(new Guid(request.Id)));
    }

    public override Task<Recipe> DeleteRecipe(Backend.RecipeId request, ServerCallContext context)
    {
        return Task.FromResult(_service.DeleteRecipe(new RecipeId { Id=request.Id }));
    }
}