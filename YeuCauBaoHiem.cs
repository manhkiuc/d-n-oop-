using BaoHiem.Enums;
namespace BaoHiem.Models;

public class YeuCauBaoHiem
{
    public string MaYeuCau { get; set; } = "";
    public long SoTienYeuCau { get; set; }
    public long SoTienDuyetChi { get; set; }
    public DateOnly NgayYeuCau { get; set; }
    public TrangThaiYeuCau TrangThai { get; set; }
    public string MaChiTietHopDong { get; set; } = "";

    public YeuCauBaoHiem() { }
    public YeuCauBaoHiem(string ma, long soTienYeuCau, long soTienDuyetChi, DateOnly ngay, TrangThaiYeuCau trangThai, string maChiTiet)
    {
        MaYeuCau = ma; SoTienYeuCau = soTienYeuCau; SoTienDuyetChi = soTienDuyetChi;
        NgayYeuCau = ngay; TrangThai = trangThai; MaChiTietHopDong = maChiTiet;
    }
    public override string ToString() =>
        $"YeuCauBaoHiem[{MaYeuCau}, yeu cau={SoTienYeuCau:N0}, duyet={SoTienDuyetChi:N0}, {NgayYeuCau:yyyy-MM-dd}, {TrangThai}, CT={MaChiTietHopDong}]";
}
