using System.Text.Json;
using Frontend;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

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

    async public static Task<Categories> ListCategories()
    {
        return await _client.ListCategoriesAsync(new Frontend.Void());
    }

    async public static Task<Category> CreateCategory(string name)
    {
        return await _client.CreateCategoryAsync(
            new CategoryName { Name = name }
        );
    }

    async public static Task<Category> UpdateCategory(Guid id, string name)
    {
        return await _client.UpdateCategoryAsync(
            new Category
            {
                Id=id.ToString(),
                Name=name
            }
        );
    }

    async public static Task DeleteCategory(Guid id)
    {
        await _client.DeleteCategoryAsync(
            new CategoryId { Id=id.ToString() }
        );
    }
}
