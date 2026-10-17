namespace BaoHiem.Models;

public class ChiTietHopDong
{
    public string MaChiTietHopDong { get; set; } = "";
    public string SoHopDong { get; set; } = "";
    public string MaKhachHangThuHuong { get; set; } = "";
    public string MaLoaiBaoHiem { get; set; } = "";

    public ChiTietHopDong() { }
    public ChiTietHopDong(string ma, string soHopDong, string maKhThuHuong, string maLoai)
    {
        MaChiTietHopDong = ma; SoHopDong = soHopDong; MaKhachHangThuHuong = maKhThuHuong; MaLoaiBaoHiem = maLoai;
    }
    public override string ToString() =>
        $"ChiTietHopDong[{MaChiTietHopDong}, HD={SoHopDong}, KH thu huong={MaKhachHangThuHuong}, LBH={MaLoaiBaoHiem}]";
}
