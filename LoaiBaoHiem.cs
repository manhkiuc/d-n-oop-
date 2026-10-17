using BaoHiem.Enums;
namespace BaoHiem.Models;

public class LoaiBaoHiem
{
    public string MaLoaiBaoHiem { get; set; } = "";
    public string TenLoaiBaoHiem { get; set; } = "";
    public long SoTienBaoHiem { get; set; }
    public long SoTienDongDinhKy { get; set; }
    public KyThanhToan KyThanhToan { get; set; }

    public LoaiBaoHiem() { }
    public LoaiBaoHiem(string ma, string ten, long soTienBaoHiem, long soTienDongDinhKy, KyThanhToan ky)
    {
        MaLoaiBaoHiem = ma; TenLoaiBaoHiem = ten; SoTienBaoHiem = soTienBaoHiem;
        SoTienDongDinhKy = soTienDongDinhKy; KyThanhToan = ky;
    }
    public override string ToString() =>
        $"LoaiBaoHiem[{MaLoaiBaoHiem}, {TenLoaiBaoHiem}, BH={SoTienBaoHiem:N0}, Phi={SoTienDongDinhKy:N0}, {KyThanhToan}]";
}
