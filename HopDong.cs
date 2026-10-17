namespace BaoHiem.Models;

public class HopDong
{
    public string SoHopDong { get; set; } = "";
    public DateOnly NgayKyHopDong { get; set; }
    public DateOnly NgayHieuLuc { get; set; }
    public DateOnly NgayHetHan { get; set; }
    public long TriGia { get; set; }
    public string MaKhachHangDaiDien { get; set; } = "";
    public string MaNhanVien { get; set; } = "";

    public HopDong() { }
    public HopDong(string so, DateOnly ngayKy, DateOnly ngayHieuLuc, DateOnly ngayHetHan, long triGia, string maKhDaiDien, string maNv)
    {
        SoHopDong = so; NgayKyHopDong = ngayKy; NgayHieuLuc = ngayHieuLuc; NgayHetHan = ngayHetHan;
        TriGia = triGia; MaKhachHangDaiDien = maKhDaiDien; MaNhanVien = maNv;
    }
    public override string ToString() =>
        $"HopDong[{SoHopDong}, ky={NgayKyHopDong:yyyy-MM-dd}, het han={NgayHetHan:yyyy-MM-dd}, {TriGia:N0}, KH={MaKhachHangDaiDien}, NV={MaNhanVien}]";
}
