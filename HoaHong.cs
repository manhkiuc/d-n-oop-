namespace BaoHiem.Models;

public class HoaHong
{
    public string MaHoaHong { get; set; } = "";
    public double TyLeHoaHong { get; set; }
    public long SoTienHoaHong { get; set; }
    public DateOnly NgayChiHoaHong { get; set; }
    public string SoHopDong { get; set; } = "";
    public string MaNhanVien { get; set; } = "";

    public HoaHong() { }
    public HoaHong(string ma, double tyLe, long soTien, DateOnly ngayChi, string soHopDong, string maNv)
    {
        MaHoaHong = ma; TyLeHoaHong = tyLe; SoTienHoaHong = soTien; NgayChiHoaHong = ngayChi;
        SoHopDong = soHopDong; MaNhanVien = maNv;
    }
    public override string ToString() =>
        $"HoaHong[{MaHoaHong}, {TyLeHoaHong}%, {SoTienHoaHong:N0}, {NgayChiHoaHong:yyyy-MM-dd}, HD={SoHopDong}, NV={MaNhanVien}]";
}
