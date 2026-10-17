using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaoHiem.Queries;
namespace BaoHiem;

/// <summary>Chế độ console: chạy lần lượt các câu truy vấn để trình bày trong video báo cáo.</summary>
public static class ConsoleDemo
{
    static readonly JsonSerializerOptions Opt = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <param name="chon">Số thứ tự câu truy vấn muốn chạy; null = chạy cả 20 câu.</param>
    public static void Run(int? chon = null)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        foreach (var q in QueryCatalog.All.Where(x => chon == null || x.Id == chon))
        {
            Console.WriteLine($"\n=== Query {q.Id} (Thành viên {q.ThanhVien}): {q.MoTa}");
            if (q.ThamSo != null) Console.WriteLine($"    Tham số: {q.ThamSo} = {q.MacDinh}");
            Console.WriteLine(JsonSerializer.Serialize(q.Chay(q.MacDinh), Opt));
        }
    }
}
