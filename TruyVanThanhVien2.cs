using BaoHiem.Data;
using BaoHiem.DAO;
using BaoHiem.Enums;
using BaoHiem.Models;
namespace BaoHiem.Queries;

/// <summary>Thành viên 2: LoaiBaoHiem, QuyenLoi, LichSuDongTien, YeuCauBaoHiem, NhanVien, HoaHong — 10 câu LINQ.</summary>
public static class TruyVanThanhVien2
{
    static KhachHangDAO KH => Db.KhachHang;
    static NhanVienDAO NV => Db.NhanVien;
    static HopDongDAO HD => Db.HopDong;
    static ChiTietHopDongDAO CT => Db.ChiTiet;
    static LoaiBaoHiemDAO LBH => Db.LoaiBaoHiem;
    static LichSuDongTienDAO LS => Db.LichSu;
    static YeuCauBaoHiemDAO YC => Db.YeuCau;
    static QuyenLoiDAO QL => Db.QuyenLoi;
    static HoaHongDAO HH => Db.HoaHong;

    // Query 11: Liệt kê quyền lợi của một loại bảo hiểm (dùng Dictionary gom sẵn theo MaLoaiBaoHiem).
    public static List<QuyenLoi> Query11(string maLoai) =>
        (from q in QL.GetByLoaiBaoHiem(maLoai) orderby q.MaQuyenLoi select q).ToList();

    // Query 12: Loại bảo hiểm có số tiền bảo hiểm tối đa cao nhất.
    public static LoaiBaoHiem? Query12() =>
        (from l in LBH.GetAll() orderby l.SoTienBaoHiem descending select l).FirstOrDefault();

    // Query 13: Tổng số tiền đã đóng của từng hợp đồng (HopDong -> ChiTiet -> LichSu).
    public static IEnumerable<object> Query13() =>
        (from h in HD.GetAll()
         select new
         {
             h.SoHopDong,
             TongTienDaDong = (from c in CT.GetByHopDong(h.SoHopDong)
                               from l in LS.GetByChiTiet(c.MaChiTietHopDong)
                               select l.SoTienDong).Sum()
         }).ToList();

    // Query 14: Đếm giao dịch theo phương thức, cho biết phương thức dùng nhiều nhất.
    public static object Query14()
    {
        var thongKe = (from l in LS.GetAll()
                       group l by l.PhuongThuc into g
                       orderby g.Count() descending
                       select new { PhuongThuc = g.Key.ToString(), SoGiaoDich = g.Count() }).ToList();
        return new { ThongKe = thongKe, DungNhieuNhat = thongKe.FirstOrDefault() };
    }

    // Query 15: Tổng tiền đóng bằng chuyển khoản trong một năm (mặc định 2024).
    public static long Query15(int nam = 2024) =>
        (from l in LS.GetAll()
         where l.PhuongThuc == PhuongThuc.CHUYEN_KHOAN && l.NgayDongTien.Year == nam
         select l.SoTienDong).Sum();

    // Query 16: Đếm yêu cầu bảo hiểm theo từng trạng thái (gồm cả trạng thái có 0 yêu cầu).
    public static IEnumerable<object> Query16() =>
        (from t in Enum.GetValues<TrangThaiYeuCau>()
         select new { TrangThai = t.ToString(), SoYeuCau = YC.GetAll().Count(y => y.TrangThai == t) }).ToList();

    // Query 17: Tổng số tiền đã duyệt chi cho từng khách hàng thụ hưởng.
    public static IEnumerable<object> Query17() =>
        (from c in CT.GetAll()
         group c by c.MaKhachHangThuHuong into g
         select new
         {
             MaKhachHang = g.Key,
             HoTen = KH.GetById(g.Key)?.HoTen,
             TongDuyetChi = (from c in g
                             join y in YC.GetAll() on c.MaChiTietHopDong equals y.MaChiTietHopDong
                             select y.SoTienDuyetChi).Sum()
         }).OrderBy(x => x.MaKhachHang).ToList();

    // Query 18: Yêu cầu có số tiền yêu cầu lớn nhất, kèm tên khách hàng thụ hưởng và tên loại bảo hiểm.
    public static object? Query18()
    {
        var y = YC.GetAll().MaxBy(x => x.SoTienYeuCau);
        if (y == null) return null;
        var ct = CT.GetById(y.MaChiTietHopDong);
        return new
        {
            YeuCau = y,
            TenKhachHangThuHuong = ct == null ? null : KH.GetById(ct.MaKhachHangThuHuong)?.HoTen,
            TenLoaiBaoHiem = ct == null ? null : LBH.GetById(ct.MaLoaiBaoHiem)?.TenLoaiBaoHiem
        };
    }

    // Query 19: Tổng hoa hồng của từng nhân viên và nhân viên có tổng cao nhất.
    public static object Query19()
    {
        var thongKe = (from n in NV.GetAll()
                       select new
                       {
                           n.MaNhanVien,
                           n.HoTen,
                           TongHoaHong = HH.GetByNhanVien(n.MaNhanVien).Sum(h => h.SoTienHoaHong)
                       }).OrderByDescending(x => x.TongHoaHong).ToList();
        return new { ThongKe = thongKe, CaoNhat = thongKe.FirstOrDefault() };
    }

    // Query 20: Chi tiết hợp đồng chưa có lần đóng tiền nào.
    public static List<ChiTietHopDong> Query20() =>
        (from c in CT.GetAll() where LS.GetByChiTiet(c.MaChiTietHopDong).Count == 0 select c).ToList();
}
