using BaoHiem.Data;
using BaoHiem.DAO;
using BaoHiem.Models;
namespace BaoHiem.Queries;

/// <summary>Thành viên 1: KhachHang, HopDong, ChiTietHopDong — 10 câu truy vấn viết bằng LINQ.</summary>
public static class TruyVanThanhVien1
{
    static KhachHangDAO KH => Db.KhachHang;
    static NhanVienDAO NV => Db.NhanVien;
    static HopDongDAO HD => Db.HopDong;
    static ChiTietHopDongDAO CT => Db.ChiTiet;
    static LoaiBaoHiemDAO LBH => Db.LoaiBaoHiem;

    // Query 1: Liệt kê toàn bộ khách hàng.
    public static List<KhachHang> Query1() =>
        (from k in KH.GetAll() orderby k.MaKhachHang select k).ToList();

    // Query 2: Tìm khách hàng theo số CCCD.
    public static KhachHang? Query2(string cccd) =>
        (from k in KH.GetAll() where k.SoCanCuocCongDan == cccd select k).FirstOrDefault();

    // Query 3: Đếm số hợp đồng mỗi khách hàng đại diện ký (group join -> gồm cả khách có 0 hợp đồng).
    public static IEnumerable<object> Query3() =>
        (from k in KH.GetAll()
         join h in HD.GetAll() on k.MaKhachHang equals h.MaKhachHangDaiDien into g
         select new { k.MaKhachHang, k.HoTen, SoHopDongDaiDienKy = g.Count() }).ToList();

    // Query 4: Tổng trị giá tất cả hợp đồng.
    public static long Query4() => (from h in HD.GetAll() select h.TriGia).Sum();

    // Query 5: Hợp đồng trị giá cao nhất, kèm tên khách hàng đại diện và nhân viên phụ trách.
    public static object? Query5()
    {
        var hd = HD.GetAll().MaxBy(h => h.TriGia);
        if (hd == null) return null;
        return new
        {
            HopDong = hd,
            TenKhachHangDaiDien = KH.GetById(hd.MaKhachHangDaiDien)?.HoTen,   // tra O(1) bằng Dictionary
            TenNhanVienPhuTrach = NV.GetById(hd.MaNhanVien)?.HoTen
        };
    }

    // Query 6: Trị giá trung bình các hợp đồng ký trong một năm (mặc định 2024).
    public static double Query6(int nam = 2024) =>
        (from h in HD.GetAll() where h.NgayKyHopDong.Year == nam select (double)h.TriGia)
            .DefaultIfEmpty(0).Average();

    // Query 7: Sắp xếp hợp đồng theo ngày hết hạn tăng dần, lấy 3 hợp đồng sắp hết hạn nhất.
    public static object Query7()
    {
        var sapXep = (from h in HD.GetAll() orderby h.NgayHetHan select h).ToList();
        return new { DanhSachTangDan = sapXep, Top3SapHetHan = sapXep.Take(3).ToList() };
    }

    // Query 8: Đếm chi tiết hợp đồng theo loại bảo hiểm, cho biết loại được mua nhiều nhất.
    public static object Query8()
    {
        var thongKe = (from c in CT.GetAll()
                       group c by c.MaLoaiBaoHiem into g
                       orderby g.Count() descending
                       select new
                       {
                           MaLoaiBaoHiem = g.Key,
                           TenLoaiBaoHiem = LBH.GetById(g.Key)?.TenLoaiBaoHiem,
                           SoChiTiet = g.Count()
                       }).ToList();
        return new { ThongKe = thongKe, MuaNhieuNhat = thongKe.FirstOrDefault() };
    }

    // Query 9: Khách hàng cụ thể có là người thụ hưởng của hợp đồng do người KHÁC đại diện ký không?
    public static object Query9(string maKhachHang)
    {
        var cacChiTiet = (from c in CT.GetAll()
                          join h in HD.GetAll() on c.SoHopDong equals h.SoHopDong
                          where c.MaKhachHangThuHuong == maKhachHang && h.MaKhachHangDaiDien != maKhachHang
                          select new
                          {
                              c.MaChiTietHopDong,
                              c.SoHopDong,
                              NguoiDaiDienKy = KH.GetById(h.MaKhachHangDaiDien)?.HoTen
                          }).ToList();
        return new
        {
            MaKhachHang = maKhachHang,
            HoTen = KH.GetById(maKhachHang)?.HoTen,
            LaNguoiThuHuongHopDongCuaNguoiKhac = cacChiTiet.Any(),
            ChiTiet = cacChiTiet
        };
    }

    // Query 10: Khách hàng chưa đại diện ký hợp đồng nào VÀ chưa là người thụ hưởng chi tiết nào.
    public static List<KhachHang> Query10()
    {
        var daiDienKy = HD.GetAll().Select(h => h.MaKhachHangDaiDien).ToHashSet();
        var thuHuong = CT.GetAll().Select(c => c.MaKhachHangThuHuong).ToHashSet();
        return (from k in KH.GetAll()
                where !daiDienKy.Contains(k.MaKhachHang) && !thuHuong.Contains(k.MaKhachHang)
                select k).ToList();
    }
}
