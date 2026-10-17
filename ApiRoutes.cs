using BaoHiem.DAO;
using BaoHiem.Data;
using BaoHiem.Queries;
namespace BaoHiem;

/// <summary>Các endpoint REST của server: CRUD 9 thực thể + 20 truy vấn + tổng quan.</summary>
public static class ApiRoutes
{
    // Trả về thông báo lỗi của quy tắc đầu tiên bị vi phạm (null nếu hợp lệ).
    static string? Chk(params (bool ok, string msg)[] rules) => rules.FirstOrDefault(r => !r.ok).msg;

    public static void Map(WebApplication app)
    {
        // ---- CRUD cho 9 thực thể (kiểm tra ràng buộc khóa ngoại khi thêm/sửa, ràng buộc khi xóa) ----
        Crud(app, "khachhang", Db.KhachHang, x => x.MaKhachHang, null,
            id => Db.HopDong.GetAll().Any(h => h.MaKhachHangDaiDien == id)
               || Db.ChiTiet.GetAll().Any(c => c.MaKhachHangThuHuong == id)
                ? "Khách hàng đang được dùng trong hợp đồng/chi tiết hợp đồng" : null);

        Crud(app, "loaibaohiem", Db.LoaiBaoHiem, x => x.MaLoaiBaoHiem,
            x => Chk((x.SoTienBaoHiem > 0, "Số tiền bảo hiểm phải > 0"), (x.SoTienDongDinhKy > 0, "Số tiền đóng định kỳ phải > 0")),
            id => Db.ChiTiet.GetAll().Any(c => c.MaLoaiBaoHiem == id) || Db.QuyenLoi.GetByLoaiBaoHiem(id).Count > 0
                ? "Loại bảo hiểm đang được sử dụng" : null);

        Crud(app, "nhanvien", Db.NhanVien, x => x.MaNhanVien, null,
            id => Db.HopDong.GetAll().Any(h => h.MaNhanVien == id) || Db.HoaHong.GetByNhanVien(id).Count > 0
                ? "Nhân viên đang phụ trách hợp đồng/hoa hồng" : null);

        Crud(app, "hopdong", Db.HopDong, x => x.SoHopDong,
            x => Chk((Db.KhachHang.GetById(x.MaKhachHangDaiDien) != null, "Khách hàng đại diện không tồn tại"),
                     (Db.NhanVien.GetById(x.MaNhanVien) != null, "Nhân viên không tồn tại"),
                     (x.NgayHieuLuc >= x.NgayKyHopDong, "Ngày hiệu lực phải sau hoặc bằng ngày ký"),
                     (x.NgayHetHan > x.NgayHieuLuc, "Ngày hết hạn phải sau ngày hiệu lực"),
                     (x.TriGia > 0, "Trị giá phải > 0")),
            id => Db.ChiTiet.GetByHopDong(id).Count > 0 || Db.HoaHong.GetAll().Any(h => h.SoHopDong == id)
                ? "Hợp đồng còn chi tiết/hoa hồng liên quan" : null);

        Crud(app, "chitiethopdong", Db.ChiTiet, x => x.MaChiTietHopDong,
            x => Chk((Db.HopDong.GetById(x.SoHopDong) != null, "Hợp đồng không tồn tại"),
                     (Db.KhachHang.GetById(x.MaKhachHangThuHuong) != null, "Khách hàng thụ hưởng không tồn tại"),
                     (Db.LoaiBaoHiem.GetById(x.MaLoaiBaoHiem) != null, "Loại bảo hiểm không tồn tại")),
            id => Db.LichSu.GetByChiTiet(id).Count > 0 || Db.YeuCau.GetAll().Any(y => y.MaChiTietHopDong == id)
                ? "Chi tiết hợp đồng còn lịch sử đóng tiền/yêu cầu liên quan" : null);

        Crud(app, "lichsudongtien", Db.LichSu, x => x.MaGiaoDich,
            x => Chk((Db.ChiTiet.GetById(x.MaChiTietHopDong) != null, "Chi tiết hợp đồng không tồn tại"),
                     (x.SoTienDong > 0, "Số tiền đóng phải > 0")), null);

        Crud(app, "yeucaubaohiem", Db.YeuCau, x => x.MaYeuCau,
            x => Chk((Db.ChiTiet.GetById(x.MaChiTietHopDong) != null, "Chi tiết hợp đồng không tồn tại"),
                     (x.SoTienYeuCau > 0, "Số tiền yêu cầu phải > 0"),
                     (x.SoTienDuyetChi >= 0 && x.SoTienDuyetChi <= x.SoTienYeuCau, "Số tiền duyệt chi phải từ 0 đến số tiền yêu cầu")), null);

        Crud(app, "quyenloi", Db.QuyenLoi, x => x.MaQuyenLoi,
            x => Chk((Db.LoaiBaoHiem.GetById(x.MaLoaiBaoHiem) != null, "Loại bảo hiểm không tồn tại"),
                     (x.TyLeChiTra > 0, "Tỷ lệ chi trả phải > 0")), null);

        Crud(app, "hoahong", Db.HoaHong, x => x.MaHoaHong,
            x => Chk((Db.HopDong.GetById(x.SoHopDong) != null, "Hợp đồng không tồn tại"),
                     (Db.NhanVien.GetById(x.MaNhanVien) != null, "Nhân viên không tồn tại"),
                     (x.SoTienHoaHong >= 0, "Số tiền hoa hồng không âm")), null);

        // ---- 20 câu truy vấn ----
        app.MapGet("/api/queries", () =>
            QueryCatalog.All.Select(q => new { q.Id, q.ThanhVien, q.MoTa, q.ThamSo, q.MacDinh }));

        app.MapGet("/api/queries/{id:int}", (int id, string? p) =>
        {
            var q = QueryCatalog.All.FirstOrDefault(x => x.Id == id);
            if (q == null) return Results.NotFound(new { loi = "Không có truy vấn này" });
            return Results.Ok(q.Chay(string.IsNullOrWhiteSpace(p) ? q.MacDinh : p));
        });

        // ---- Tổng quan cho dashboard ----
        app.MapGet("/api/tongquan", () => new
        {
            SoKhachHang = Db.KhachHang.GetAll().Count(),
            SoHopDong = Db.HopDong.GetAll().Count(),
            TongTriGiaHopDong = Db.HopDong.GetAll().Sum(h => h.TriGia),
            TongTienDaThu = Db.LichSu.GetAll().Sum(l => l.SoTienDong),
            TongTienDaChi = Db.YeuCau.GetAll().Sum(y => y.SoTienDuyetChi),
            TongHoaHong = Db.HoaHong.GetAll().Sum(h => h.SoTienHoaHong),
            YeuCauChoXuLy = Db.YeuCau.GetAll().Count(y => y.TrangThai == Enums.TrangThaiYeuCau.CHO_XU_LY
                                                       || y.TrangThai == Enums.TrangThaiYeuCau.DANG_THAM_DINH)
        });
    }

    /// <summary>Đăng ký 5 endpoint CRUD chuẩn REST cho một thực thể.</summary>
    static void Crud<T>(WebApplication app, string route, IDao<T> dao, Func<T, string> key,
                        Func<T, string?>? validate, Func<string, string?>? deleteCheck) where T : class
    {
        var path = $"/api/{route}";

        app.MapGet(path, () => dao.GetAll());

        app.MapGet(path + "/{id}", (string id) =>
            dao.GetById(id) is { } x ? Results.Ok(x) : Results.NotFound(new { loi = "Không tìm thấy" }));

        app.MapPost(path, (T item) =>
        {
            if (string.IsNullOrWhiteSpace(key(item))) return Results.BadRequest(new { loi = "Mã/khóa chính không được để trống" });
            var err = validate?.Invoke(item);
            if (err != null) return Results.BadRequest(new { loi = err });
            return dao.Add(item)
                ? Results.Created($"{path}/{key(item)}", item)
                : Results.Conflict(new { loi = "Mã đã tồn tại" });
        });

        app.MapPut(path + "/{id}", (string id, T item) =>
        {
            if (key(item) != id) return Results.BadRequest(new { loi = "Không được đổi khóa chính" });
            var err = validate?.Invoke(item);
            if (err != null) return Results.BadRequest(new { loi = err });
            return dao.Update(id, item) ? Results.Ok(item) : Results.NotFound(new { loi = "Không tìm thấy" });
        });

        app.MapDelete(path + "/{id}", (string id) =>
        {
            var err = deleteCheck?.Invoke(id);
            if (err != null) return Results.Conflict(new { loi = err });
            return dao.Delete(id) ? Results.NoContent() : Results.NotFound(new { loi = "Không tìm thấy" });
        });
    }
}
