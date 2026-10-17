using BaoHiem.DAO;
namespace BaoHiem.Data;

/// <summary>Kho dữ liệu trong bộ nhớ: mỗi thực thể một DAO (singleton).</summary>
public static class Db
{
    public static readonly KhachHangDAO KhachHang = new();
    public static readonly LoaiBaoHiemDAO LoaiBaoHiem = new();
    public static readonly NhanVienDAO NhanVien = new();
    public static readonly HopDongDAO HopDong = new();
    public static readonly ChiTietHopDongDAO ChiTiet = new();
    public static readonly LichSuDongTienDAO LichSu = new();
    public static readonly YeuCauBaoHiemDAO YeuCau = new();
    public static readonly QuyenLoiDAO QuyenLoi = new();
    public static readonly HoaHongDAO HoaHong = new();
}
