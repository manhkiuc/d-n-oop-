using BaoHiem.Models;
namespace BaoHiem.DAO;

public class KhachHangDAO : MapDao<KhachHang>
{
    public KhachHangDAO() : base(x => x.MaKhachHang) { }
    public KhachHang? FindByCccd(string cccd) => Map.Values.FirstOrDefault(k => k.SoCanCuocCongDan == cccd);
}
