using System.Text.Json.Serialization;
using BaoHiem.Data;
namespace BaoHiem;

public static class Program
{
    /// <summary>
    /// dotnet run                -> chạy web server (http://localhost:5000)
    /// dotnet run -- console     -> chạy cả 20 truy vấn trên console
    /// dotnet run -- console 7   -> chỉ chạy Query 7
    /// </summary>
    public static void Main(string[] args)
    {
        DataSeeder.Seed();                       // nạp dữ liệu mẫu vào các DAO

        if (args.Length > 0 && args[0] == "console")
        {
            int? chon = args.Length > 1 && int.TryParse(args[1], out var n) ? n : null;
            ConsoleDemo.Run(chon);
            return;
        }

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureHttpJsonOptions(o =>
            o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));   // enum <-> chuỗi

        var app = builder.Build();
        app.UseDefaultFiles();                   // wwwroot/index.html
        app.UseStaticFiles();
        ApiRoutes.Map(app);                      // đăng ký các endpoint
        app.Run();
    }
}
