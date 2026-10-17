using BaoHiem.Enums;
using BaoHiem.Models;
namespace BaoHiem.Data;

/// <summary>Nạp dữ liệu mẫu (Mục 10 của đặc tả).</summary>
public static class DataSeeder
{
    private static DateOnly D(string s) => DateOnly.ParseExact(s, "yyyy-MM-dd");

    public static void Seed()
    {
        Db.KhachHang.Add(new("KH001", "Nguyễn Văn An", D("1985-03-12"), "079085001234", "Kỹ sư"));
        Db.KhachHang.Add(new("KH002", "Trần Thị Bình", D("1990-07-25"), "079190005678", "Giáo viên"));
        Db.KhachHang.Add(new("KH003", "Lê Hoàng Cường", D("1978-11-02"), "079078009012", "Kinh doanh"));
        Db.KhachHang.Add(new("KH004", "Phạm Thu Dung", D("1995-01-18"), "079195003456", "Nhân viên văn phòng"));
        Db.KhachHang.Add(new("KH005", "Trần Minh Khang", D("2016-08-14"), "079216001111", "Học sinh"));
        Db.KhachHang.Add(new("KH006", "Võ Quốc Em", D("1982-05-30"), "079082007890", "Bác sĩ"));

        Db.LoaiBaoHiem.Add(new("LBH01", "Bảo hiểm nhân thọ trọn đời", 1_000_000_000, 12_000_000, KyThanhToan.HANG_NAM));
        Db.LoaiBaoHiem.Add(new("LBH02", "Bảo hiểm tử kỳ 20 năm", 500_000_000, 3_000_000, KyThanhToan.HANG_QUY));
        Db.LoaiBaoHiem.Add(new("LBH03", "Bảo hiểm sức khỏe cao cấp", 300_000_000, 1_200_000, KyThanhToan.HANG_THANG));
        Db.LoaiBaoHiem.Add(new("LBH04", "Bảo hiểm giáo dục", 400_000_000, 6_000_000, KyThanhToan.NUA_NAM));

        Db.NhanVien.Add(new("NV01", "Hoàng Minh Tuấn", "0901111111", "tuan.hm@baohiem.vn", ChucVu.TU_VAN_VIEN));
        Db.NhanVien.Add(new("NV02", "Đỗ Thị Lan", "0902222222", "lan.dt@baohiem.vn", ChucVu.TRUONG_NHOM));
        Db.NhanVien.Add(new("NV03", "Bùi Quang Huy", "0903333333", "huy.bq@baohiem.vn", ChucVu.QUAN_LY));

        Db.HopDong.Add(new("HD001", D("2023-01-10"), D("2023-01-15"), D("2043-01-15"), 1_300_000_000, "KH001", "NV01"));
        Db.HopDong.Add(new("HD002", D("2023-06-01"), D("2023-06-10"), D("2043-06-10"), 500_000_000, "KH003", "NV01"));
        Db.HopDong.Add(new("HD003", D("2024-02-20"), D("2024-03-01"), D("2044-03-01"), 700_000_000, "KH002", "NV02"));
        Db.HopDong.Add(new("HD004", D("2024-09-05"), D("2024-09-15"), D("2034-09-15"), 500_000_000, "KH004", "NV02"));
        Db.HopDong.Add(new("HD005", D("2025-04-12"), D("2025-04-20"), D("2045-04-20"), 300_000_000, "KH001", "NV01"));

        Db.ChiTiet.Add(new("CT001", "HD001", "KH002", "LBH01"));
        Db.ChiTiet.Add(new("CT002", "HD001", "KH001", "LBH03"));
        Db.ChiTiet.Add(new("CT003", "HD002", "KH003", "LBH02"));
        Db.ChiTiet.Add(new("CT004", "HD003", "KH005", "LBH04"));
        Db.ChiTiet.Add(new("CT005", "HD003", "KH002", "LBH03"));
        Db.ChiTiet.Add(new("CT006", "HD004", "KH004", "LBH02"));
        Db.ChiTiet.Add(new("CT007", "HD005", "KH005", "LBH03"));

        Db.LichSu.Add(new("GD001", D("2023-01-15"), 12_000_000, PhuongThuc.CHUYEN_KHOAN, "CT001"));
        Db.LichSu.Add(new("GD002", D("2024-01-15"), 12_000_000, PhuongThuc.CHUYEN_KHOAN, "CT001"));
        Db.LichSu.Add(new("GD003", D("2023-01-15"), 1_200_000, PhuongThuc.THE, "CT002"));
        Db.LichSu.Add(new("GD004", D("2023-02-15"), 1_200_000, PhuongThuc.THE, "CT002"));
        Db.LichSu.Add(new("GD005", D("2023-06-10"), 3_000_000, PhuongThuc.TIEN_MAT, "CT003"));
        Db.LichSu.Add(new("GD006", D("2023-09-10"), 3_000_000, PhuongThuc.TIEN_MAT, "CT003"));
        Db.LichSu.Add(new("GD007", D("2024-03-01"), 6_000_000, PhuongThuc.VI_DIEN_TU, "CT004"));
        Db.LichSu.Add(new("GD008", D("2024-09-15"), 3_000_000, PhuongThuc.CHUYEN_KHOAN, "CT006"));
        Db.LichSu.Add(new("GD009", D("2025-04-20"), 1_200_000, PhuongThuc.VI_DIEN_TU, "CT007"));

        Db.YeuCau.Add(new("YC001", 15_000_000, 15_000_000, D("2024-05-10"), TrangThaiYeuCau.DA_DUYET, "CT002"));
        Db.YeuCau.Add(new("YC002", 200_000_000, 0, D("2024-08-01"), TrangThaiYeuCau.TU_CHOI, "CT003"));
        Db.YeuCau.Add(new("YC003", 20_000_000, 18_000_000, D("2025-01-12"), TrangThaiYeuCau.DA_DUYET, "CT005"));
        Db.YeuCau.Add(new("YC004", 10_000_000, 0, D("2025-06-20"), TrangThaiYeuCau.DANG_THAM_DINH, "CT004"));
        Db.YeuCau.Add(new("YC005", 5_000_000, 0, D("2025-09-01"), TrangThaiYeuCau.CHO_XU_LY, "CT006"));

        Db.QuyenLoi.Add(new("QL01", "Tử vong tự nhiên", "Chi trả toàn bộ số tiền bảo hiểm khi tử vong", 100, "LBH01"));
        Db.QuyenLoi.Add(new("QL02", "Thương tật toàn bộ vĩnh viễn", "Chi trả khi mất khả năng lao động vĩnh viễn", 100, "LBH01"));
        Db.QuyenLoi.Add(new("QL03", "Tử vong do tai nạn", "Chi trả gấp đôi nếu tử vong do tai nạn", 200, "LBH02"));
        Db.QuyenLoi.Add(new("QL04", "Nằm viện nội trú", "Chi trả chi phí điều trị nội trú", 10, "LBH03"));
        Db.QuyenLoi.Add(new("QL05", "Phẫu thuật", "Chi trả chi phí phẫu thuật", 30, "LBH03"));
        Db.QuyenLoi.Add(new("QL06", "Hỗ trợ học phí", "Hỗ trợ học phí khi người đóng phí gặp rủi ro", 25, "LBH04"));

        Db.HoaHong.Add(new("HH001", 20, 5_280_000, D("2023-02-01"), "HD001", "NV01"));
        Db.HoaHong.Add(new("HH002", 20, 2_400_000, D("2023-07-01"), "HD002", "NV01"));
        Db.HoaHong.Add(new("HH003", 25, 6_600_000, D("2024-04-01"), "HD003", "NV02"));
        Db.HoaHong.Add(new("HH004", 25, 3_000_000, D("2024-10-01"), "HD004", "NV02"));
        Db.HoaHong.Add(new("HH005", 20, 2_880_000, D("2025-05-01"), "HD005", "NV01"));
    }
}
