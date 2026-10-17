using BaoHiem.Enums;
namespace BaoHiem.Models;

public class LichSuDongTien
{
    public string MaGiaoDich { get; set; } = "";
    public DateOnly NgayDongTien { get; set; }
    public long SoTienDong { get; set; }
    public PhuongThuc PhuongThuc { get; set; }
    public string MaChiTietHopDong { get; set; } = "";

    public LichSuDongTien() { }
    public LichSuDongTien(string ma, DateOnly ngay, long soTien, PhuongThuc phuongThuc, string maChiTiet)
    {
        MaGiaoDich = ma; NgayDongTien = ngay; SoTienDong = soTien; PhuongThuc = phuongThuc; MaChiTietHopDong = maChiTiet;
    }
    public override string ToString() =>
        $"LichSuDongTien[{MaGiaoDich}, {NgayDongTien:yyyy-MM-dd}, {SoTienDong:N0}, {PhuongThuc}, CT={MaChiTietHopDong}]";
}
