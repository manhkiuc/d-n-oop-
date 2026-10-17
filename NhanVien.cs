using BaoHiem.Enums;
namespace BaoHiem.Models;

public class NhanVien
{
    public string MaNhanVien { get; set; } = "";
    public string HoTen { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public string Email { get; set; } = "";
    public ChucVu ChucVu { get; set; }

    public NhanVien() { }
    public NhanVien(string ma, string hoTen, string sdt, string email, ChucVu chucVu)
    {
        MaNhanVien = ma; HoTen = hoTen; SoDienThoai = sdt; Email = email; ChucVu = chucVu;
    }
    public override string ToString() => $"NhanVien[{MaNhanVien}, {HoTen}, {SoDienThoai}, {Email}, {ChucVu}]";
}
