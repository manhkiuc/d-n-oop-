namespace BaoHiem.Queries;

public record QueryInfo(int Id, int ThanhVien, string MoTa, string? ThamSo, string? MacDinh, Func<string?, object?> Chay);

/// <summary>Danh bạ 20 truy vấn: dùng chung cho Console (Main) và Web API.</summary>
public static class QueryCatalog
{
    static int Nam(string? p, int macDinh) => int.TryParse(p, out var n) ? n : macDinh;

    public static readonly List<QueryInfo> All = new()
    {
        new(1, 1, "Liệt kê toàn bộ khách hàng", null, null, _ => TruyVanThanhVien1.Query1()),
        new(2, 1, "Tìm khách hàng theo số CCCD", "cccd", "079085001234", p => TruyVanThanhVien1.Query2(p ?? "")),
        new(3, 1, "Đếm số hợp đồng mỗi khách hàng đại diện ký", null, null, _ => TruyVanThanhVien1.Query3()),
        new(4, 1, "Tổng trị giá tất cả hợp đồng", null, null, _ => TruyVanThanhVien1.Query4()),
        new(5, 1, "Hợp đồng trị giá cao nhất + khách hàng đại diện + nhân viên phụ trách", null, null, _ => TruyVanThanhVien1.Query5()),
        new(6, 1, "Trị giá trung bình các hợp đồng ký trong năm", "nam", "2024", p => TruyVanThanhVien1.Query6(Nam(p, 2024))),
        new(7, 1, "Sắp xếp hợp đồng theo ngày hết hạn tăng dần + 3 hợp đồng sắp hết hạn nhất", null, null, _ => TruyVanThanhVien1.Query7()),
        new(8, 1, "Đếm chi tiết hợp đồng theo loại bảo hiểm + loại được mua nhiều nhất", null, null, _ => TruyVanThanhVien1.Query8()),
        new(9, 1, "Khách hàng có là người thụ hưởng hợp đồng do người khác ký không", "maKhachHang", "KH002", p => TruyVanThanhVien1.Query9(p ?? "")),
        new(10, 1, "Khách hàng chưa ký hợp đồng và chưa là người thụ hưởng nào", null, null, _ => TruyVanThanhVien1.Query10()),

        new(11, 2, "Liệt kê quyền lợi của một loại bảo hiểm", "maLoaiBaoHiem", "LBH01", p => TruyVanThanhVien2.Query11(p ?? "")),
        new(12, 2, "Loại bảo hiểm có số tiền bảo hiểm tối đa cao nhất", null, null, _ => TruyVanThanhVien2.Query12()),
        new(13, 2, "Tổng số tiền đã đóng của từng hợp đồng", null, null, _ => TruyVanThanhVien2.Query13()),
        new(14, 2, "Đếm giao dịch theo phương thức + phương thức dùng nhiều nhất", null, null, _ => TruyVanThanhVien2.Query14()),
        new(15, 2, "Tổng tiền đóng bằng chuyển khoản trong năm", "nam", "2024", p => TruyVanThanhVien2.Query15(Nam(p, 2024))),
        new(16, 2, "Đếm yêu cầu bảo hiểm theo từng trạng thái", null, null, _ => TruyVanThanhVien2.Query16()),
        new(17, 2, "Tổng tiền đã duyệt chi cho từng khách hàng thụ hưởng", null, null, _ => TruyVanThanhVien2.Query17()),
        new(18, 2, "Yêu cầu có số tiền lớn nhất + khách hàng thụ hưởng + loại bảo hiểm", null, null, _ => TruyVanThanhVien2.Query18()),
        new(19, 2, "Tổng hoa hồng từng nhân viên + nhân viên cao nhất", null, null, _ => TruyVanThanhVien2.Query19()),
        new(20, 2, "Chi tiết hợp đồng chưa có lần đóng tiền nào", null, null, _ => TruyVanThanhVien2.Query20()),
    };
}
