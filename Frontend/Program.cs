using Frontend;
using Grpc.Net.Client;

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

// The port number must match the port of the gRPC server.
//using var channel = GrpcChannel.ForAddress("http://localhost:5057");
//var client = new Frontend.CategoryService.CategoryServiceClient(channel);
//Console.WriteLine("START...");
//var reply = client.ListCategories(new Frontend.Void());
//foreach (Category cat in reply.CategoriesList)
//    Console.WriteLine($"Id: {cat.Id}, Name: {cat.Name}");
//Console.WriteLine("Press any key to exit...");
//Console.ReadKey();


//if (reply != null)
//{
//    foreach (Category cat in reply.CategoriesList)
//        Console.WriteLine($"Id: {cat.Id}, Name: {cat.Name}");
//}

public static class Requests
{
    private readonly static Grpc.Net.Client.GrpcChannel _channel = GrpcChannel.ForAddress(Program.config["baseAddress"]);
    private readonly static Frontend.CategoryService.CategoryServiceClient _client = new(_channel);

    async public static Task<Categories> ListCategories()
    {
        return await _client.ListCategoriesAsync(new Frontend.Void());
    }
}