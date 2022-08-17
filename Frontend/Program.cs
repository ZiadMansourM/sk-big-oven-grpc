using System.Threading.Tasks;
using Frontend;
using Grpc.Net.Client;


// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5057");
var client = new Frontend.CategoryService.CategoryServiceClient(channel);
Console.WriteLine("START...");
var reply = client.ListCategories(new Frontend.Void());

foreach (Category cat in reply.CategoriesList)
    Console.WriteLine($"Id: {cat.Id}, Name: {cat.Name}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();




//using Frontend;
//using Grpc.Net.Client;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorPages();

//var app = builder.Build();

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();
//app.MapRazorPages();

//app.Run();

//public partial class Program
//{
//    public static readonly IConfiguration config = new ConfigurationBuilder()
//        .AddJsonFile("appsettings.json")
//        .Build();
//}

//public static class Requests
//{
//    private readonly static Grpc.Net.Client.GrpcChannel _channel = GrpcChannel.ForAddress(Program.config["baseAddress"]);
//    private readonly static Frontend.CategoryService.CategoryServiceClient _client = new(_channel);

//    public static void ListCategories()
//    {
//        Console.WriteLine("DEBUG TWO");
//        Frontend.Void request = new();
//        Console.WriteLine("DEBUG THREE");
//        var reply = _client.ListCategories(request);
//        Console.WriteLine("DEBUG FOUR");
//        if (reply != null)
//        {
//            foreach (var category in reply.CategoriesList)
//            {
//                Console.WriteLine(category);
//            }
//        }
//    }
//}