namespace BaoHiem.Models;

public class KhachHang
{
    public string MaKhachHang { get; set; } = "";
    public string HoTen { get; set; } = "";
    public DateOnly NgaySinh { get; set; }
    public string SoCanCuocCongDan { get; set; } = "";
    public string NgheNghiep { get; set; } = "";

    public KhachHang() { }
    public KhachHang(string maKhachHang, string hoTen, DateOnly ngaySinh, string soCanCuocCongDan, string ngheNghiep)
    {
        MaKhachHang = maKhachHang; HoTen = hoTen; NgaySinh = ngaySinh;
        SoCanCuocCongDan = soCanCuocCongDan; NgheNghiep = ngheNghiep;
    }
    public override string ToString() =>
        $"KhachHang[{MaKhachHang}, {HoTen}, {NgaySinh:yyyy-MM-dd}, CCCD={SoCanCuocCongDan}, {NgheNghiep}]";
}
